using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcs;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Services
{
    public class IngredienteOpcService : IIngredienteOpcService
    {
        private readonly IIngredienteOpcRepository _ingredienteOpcRepository;
        private readonly IBus _bus;

        public IngredienteOpcService(IIngredienteOpcRepository ingredienteOpcRepository, IBus bus)
        {
            _bus = bus;
            _ingredienteOpcRepository = ingredienteOpcRepository;
        }
        public void Atualizar(IngredienteOpc ingredienteOpc)
        {
            AtualizarIngredienteOpcCommand command = new AtualizarIngredienteOpcCommand(ingredienteOpc.Id,ingredienteOpc.Descricao,ingredienteOpc.Id_produtoTipo,ingredienteOpc.Ids_ingredienteOpc_Opcoes);
            _bus.SendCommand(command);
        }

        public void Criar(IngredienteOpc ingredienteOpc)
        {
            CriarIngredienteOpcCommand command = new CriarIngredienteOpcCommand(ingredienteOpc.Descricao, ingredienteOpc.Id_produtoTipo, ingredienteOpc.Ids_ingredienteOpc_Opcoes);
            _bus.SendCommand(command);
        }

        public void Deletar(Guid id)
        {
            DeletarIngredienteOpcCommand command = new DeletarIngredienteOpcCommand(id);
            _bus.SendCommand(command);
        }

        public IEnumerable<IngredienteOpc> Pesquisar(Expression<Func<IngredienteOpc, bool>> predicate)
        {
            return _ingredienteOpcRepository.Pesquisar(predicate);
        }

        public IngredienteOpc TrazerPorId(Guid id)
        {
            return _ingredienteOpcRepository.TrazerPorId(id);
        }

        public IEnumerable<IngredienteOpc> TrazerTodos()
        {
            return _ingredienteOpcRepository.TrazerTodos();
        }

        public IEnumerable<IngredienteOpc> TrazerTodosAtivos()
        {
            return _ingredienteOpcRepository.TrazerTodosAtivos();
                 
        }

        public IEnumerable<IngredienteOpc> TrazerTodosDeletados()
        {
            return _ingredienteOpcRepository.TrazerTodosDeletados();
        }
    }
}
