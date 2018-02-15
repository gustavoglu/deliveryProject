using ProjectDelivery.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Interfaces
{
    public interface IIngredienteOpc_OpcaoService
    {
        void Criar(IngredienteOpc_Opcao ingredienteOpc_Opcao);
        void Atualizar(IngredienteOpc_Opcao ingredienteOpc_Opcao);
        void Deletar(Guid id);
        IngredienteOpc_Opcao TrazerPorId(Guid id);
        IEnumerable<IngredienteOpc_Opcao> TrazerTodos();
        IEnumerable<IngredienteOpc_Opcao> TrazerTodosAtivos();
        IEnumerable<IngredienteOpc_Opcao> TrazerTodosDeletados();
        IEnumerable<IngredienteOpc_Opcao> Pesquisar(Expression<Func<IngredienteOpc_Opcao, bool>> predicate);
    }
}
