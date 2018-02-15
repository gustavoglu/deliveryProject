using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface  ITamanhoService : IDisposable
    {
        void Criar(Tamanho tamanho);
        void Atualizar(Tamanho tamanho);
        void Deletar(Guid id);
        void Reativar(Guid id);
        Tamanho TrazerPorId(Guid id);
        IEnumerable<Tamanho> TrazerTodos();
        IEnumerable<Tamanho> TrazerTodosAtivos();
        IEnumerable<Tamanho> TrazerTodosDeletados();
        IEnumerable<Tamanho> Pesquisar(Expression<Func<Tamanho, bool>> predicate);
    }
}
