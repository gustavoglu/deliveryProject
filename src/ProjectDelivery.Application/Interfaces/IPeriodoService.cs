using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectDelivery.Application.Interfaces
{
    public interface IPeriodoService
    {
        void Criar(Periodo periodo);
        void Atualizar(Periodo periodo);
        void Deletar(Guid id);
        Periodo TrazerPorId(Guid id);
        IEnumerable<Periodo> TrazerTodos();
        IEnumerable<Periodo> TrazerTodosAtivos();
        IEnumerable<Periodo> TrazerTodosDeletados();
        IEnumerable<Periodo> Pesquisar(Expression<Func<Periodo, bool>> predicate);
    }
}
