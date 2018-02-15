using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface  IPagamentoTipoService 
    {
        void Criar(PagamentoTipo pagamentoTipo);
        void Atualizar(PagamentoTipo pagamentoTipo);
        void Deletar(Guid id);
        PagamentoTipo TrazerPorId(Guid id);
        IEnumerable<PagamentoTipo> TrazerTodos();
        IEnumerable<PagamentoTipo> TrazerTodosAtivos();
        IEnumerable<PagamentoTipo> TrazerTodosDeletados();
        IEnumerable<PagamentoTipo> Pesquisar(Expression<Func<PagamentoTipo, bool>> predicate);
    }
}
