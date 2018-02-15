using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface IProduto_ValorExcecaoService
    {
        void Criar(Produto_ValorExcecao produto_ValorExcecao);
        void Atualizar(Produto_ValorExcecao produto_ValorExcecao);
        void Deletar(Guid id);
        Produto_ValorExcecao TrazerPorId(Guid id);
        IEnumerable<Produto_ValorExcecao> TrazerTodos();
        IEnumerable<Produto_ValorExcecao> TrazerTodosAtivos();
        IEnumerable<Produto_ValorExcecao> TrazerTodosDeletados();
        IEnumerable<Produto_ValorExcecao> Pesquisar(Expression<Func<Produto_ValorExcecao, bool>> predicate);
    }
}
