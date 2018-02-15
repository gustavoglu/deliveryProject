using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProjectDelivery.Domain.Core.Entitys;
using ProjectDelivery.Domain.Interfaces;
using ProjectDelivery.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectDelivery.Infra.Data.Context
{
    public class ProjectDeliveryContext : IMongoDbContext
    {
        protected IMongoDatabase _database;
        private readonly IUser _user;
        private List<Action> actionsInDatabase;

        public ProjectDeliveryContext(IUser user)
        {
            _user = user;
            actionsInDatabase = new List<Action>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IMongoDatabase GetConnection()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var server = config.GetSection("MongoConnectionStrings:Host").Value;
            var database = config.GetSection("MongoConnectionStrings:Database").Value;

            var client = new MongoClient(server);
            _database = client.GetDatabase(database);
            return _database;
        }

        public bool ExecuteActionInDatabase(Action actionRepository)
        {
            if (actionRepository == null) return false;
            try { actionRepository.Invoke(); return true; }
            catch { return false; }
        }

        public void ActionInDatabase(Action actionInDatabase)
        {
            actionsInDatabase.Add(actionInDatabase);
        }

        public SaveChangesResponse SaveChanges()
        {
            if (actionsInDatabase == null) return new SaveChangesResponse(false,"Actions in Database Null");
            if (!actionsInDatabase.Any()) return new SaveChangesResponse();

            try
            {
                foreach (var action in actionsInDatabase)
                {
                    action.Invoke();
                }
                actionsInDatabase.Clear();
                return new SaveChangesResponse();
            }
            catch(Exception e)
            {
                return new SaveChangesResponse(false,e.Message);
            }
        }

        public void DeletaEntity<T>(T entity) where T : Entity
        {
            entity.Deletado = true;
            entity.DeletadoEm = DateTime.Now;
            entity.DeletadoPor = _user.GetUserName();
        }

        public void CriaEntity<T>(T entity) where T : Entity
        {
            entity.CriadoEm = DateTime.Now;
            entity.CriadoPor = _user.GetUserName();
        }

        public void AtualizaEntity<T>(T entity) where T : Entity
        {

            entity.AtualizadoEm = DateTime.Now;
            entity.AtualizadoPor = _user.GetUserName();
        }

    }
}
