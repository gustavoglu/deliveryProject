using System;
using MongoDB.Driver;
using ProjectDelivery.Domain.Core.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Infra.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IMongoDbContext _context;
        private readonly IMongoDatabase database;
        protected readonly IMongoCollection<T> collectionEntity;

        public Repository(IMongoDbContext context)
        {
            _context = context;
            database = _context.GetConnection();
            collectionEntity = database.GetCollection<T>(typeof(T).Name);
        }

        public void Atualizar(T entidade)
        {
            var entity = TrazerPorId(entidade.Id);

            entidade.CriadoPor = entity.CriadoPor;
            entidade.CriadoEm = entity.CriadoEm;
            entidade.DeletadoEm = entity.DeletadoEm;
            entidade.DeletadoPor = entity.DeletadoPor;

            _context.AtualizaEntity(entidade);
            _context.ActionInDatabase(() => collectionEntity.ReplaceOne(e => e.Id == entidade.Id, entidade));
        }

        public void Criar(T entidade)
        {
            _context.CriaEntity(entidade);
            _context.ActionInDatabase(() => collectionEntity.InsertOne(entidade));
        }

        public void Deletar(Guid id)
        {
            var entity = collectionEntity.Find(e => e.Id == id).FirstOrDefault();
            _context.DeletaEntity(entity);
            _context.ActionInDatabase(() => collectionEntity.ReplaceOne(e => e.Id == id, entity));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return collectionEntity.Find(predicate).ToList();
        }

        public void Reativar(Guid id)
        {
            _context.ActionInDatabase(() => collectionEntity
                .FindOneAndUpdate(e => e.Id == id, Builders<T>.Update.Set(e => e.Deletado, true)));
        }

        public T TrazerPorId(Guid id)
        {
            return collectionEntity.Find(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> TrazerTodos()
        {
            return collectionEntity.AsQueryable();
        }

        public IEnumerable<T> TrazerTodosAtivos()
        {
            return collectionEntity.Find(e => e.Deletado == false).ToList();
        }

        public IEnumerable<T> TrazerTodosDeletados()
        {
            return collectionEntity.Find(e => e.Deletado == true).ToList();
        }

        private void AtualizaPropertysBaseEntity(T entity, bool update, bool delete)
        {
            var oldEntity = this.TrazerPorId(entity.Id);
            entity.CriadoPor = oldEntity.CriadoPor;
            entity.CriadoEm = oldEntity.CriadoEm;
            if (!delete)
            {
                entity.DeletadoPor = oldEntity.DeletadoPor;
                entity.DeletadoEm = oldEntity.DeletadoEm;
            }
            entity.AtualizadoPor = oldEntity.AtualizadoPor;
            entity.AtualizadoEm = oldEntity.AtualizadoEm;
        }
    }
}
