using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface IAdicionalService : IDisposable
    {
        void Criar(Adicional adicional);
        void Atualizar(Adicional adicional);
        void Deletar(Guid id);
        void Reativar(Guid id);
        Adicional TrazerPorId(Guid id);
        IEnumerable<Adicional> TrazerTodos();
        IEnumerable<Adicional> TrazerTodosAtivos();
        IEnumerable<Adicional> TrazerTodosDeletados();
        IEnumerable<Adicional> Pesquisar(Expression<Func<Adicional, bool>> predicate);
    }
}
