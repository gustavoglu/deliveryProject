
using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface IProdutoService
    {
        void Criar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(Guid id);
        Produto TrazerPorId(Guid id);
        IEnumerable<Produto> TrazerTodos();
        IEnumerable<Produto> TrazerTodosAtivos();
        IEnumerable<Produto> TrazerTodosDeletados();
        IEnumerable<Produto> Pesquisar(Expression<Func<Produto, bool>> predicate);
    }
}
