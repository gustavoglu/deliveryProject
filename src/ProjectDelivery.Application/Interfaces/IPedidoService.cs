using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface  IPedidoService
    {
        void Criar(Pedido pedido);
        void Atualizar(Pedido pedido);
        void Deletar(Guid id);
        Pedido TrazerPorId(Guid id);
        IEnumerable<Pedido> TrazerTodos();
        IEnumerable<Pedido> TrazerTodosAtivos();
        IEnumerable<Pedido> TrazerTodosDeletados();
        IEnumerable<Pedido> Pesquisar(Expression<Func<Pedido, bool>> predicate);
    }
}
