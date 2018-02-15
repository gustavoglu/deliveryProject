using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface IProdutoTipoService : IDisposable
    {
        void Criar(ProdutoTipo produtoTipo);
        void Atualizar(ProdutoTipo produtoTipo);
        void Deletar(Guid id);
        ProdutoTipo TrazerPorId(Guid id);
        IEnumerable<ProdutoTipo> TrazerTodos();
        IEnumerable<ProdutoTipo> TrazerTodosAtivos();
        IEnumerable<ProdutoTipo> TrazerTodosDeletados();
        IEnumerable<ProdutoTipo> Pesquisar(Expression<Func<ProdutoTipo,bool>> predicate);
    }
}
