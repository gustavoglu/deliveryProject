using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface IIngredienteOpcService
    {
        void Criar(IngredienteOpc ingredienteOpc);
        void Atualizar(IngredienteOpc ingredienteOpc);
        void Deletar(Guid id);
        IngredienteOpc TrazerPorId(Guid id);
        IEnumerable<IngredienteOpc> TrazerTodos();
        IEnumerable<IngredienteOpc> TrazerTodosAtivos();
        IEnumerable<IngredienteOpc> TrazerTodosDeletados();
        IEnumerable<IngredienteOpc> Pesquisar(Expression<Func<IngredienteOpc, bool>> predicate);
    }
}
