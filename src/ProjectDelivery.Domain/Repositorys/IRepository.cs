using System;
using ProjectDelivery.Domain.Core.Entitys;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Domain.Repositorys
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        void Criar(T entidade);
        void Atualizar(T entidade);
        void Deletar(Guid id);
        void Reativar(Guid id);
        T TrazerPorId(Guid id);
        IEnumerable<T> TrazerTodos();
        IEnumerable<T> TrazerTodosAtivos();
        IEnumerable<T> TrazerTodosDeletados();
        IEnumerable<T> Pesquisar(Expression<Func<T,bool>> predicate);
    }
}
