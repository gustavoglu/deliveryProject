using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcOpcoes;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Services
{
    public class IngredienteOpc_OpcaoService : IIngredienteOpc_OpcaoService
    {
        private readonly IIngredienteOpc_OpcaoRepository _ingredienteOpc_OpcaoRepository;
        private readonly IBus _bus;
        public IngredienteOpc_OpcaoService(IIngredienteOpc_OpcaoRepository ingredienteOpc_OpcaoRepository, IBus bus)
        {
            _ingredienteOpc_OpcaoRepository = ingredienteOpc_OpcaoRepository;
            _bus = bus;
        }

        public void Atualizar(IngredienteOpc_Opcao ingredienteOpc_Opcao)
        {
            AtualizarIngredienteOpcOpcaoCommand command = new AtualizarIngredienteOpcOpcaoCommand(ingredienteOpc_Opcao.Id, ingredienteOpc_Opcao.Descricao, ingredienteOpc_Opcao.ValorDiferenca, ingredienteOpc_Opcao.Id_produto);
            _bus.SendCommand(command);
        }

        public void Criar(IngredienteOpc_Opcao ingredienteOpc_Opcao)
        {
            CriarIngredienteOpcOpcaoCommand command = new CriarIngredienteOpcOpcaoCommand( ingredienteOpc_Opcao.Descricao, ingredienteOpc_Opcao.ValorDiferenca, ingredienteOpc_Opcao.Id_produto);
            _bus.SendCommand(command);
        }

        public void Deletar(Guid id)
        {
            DeletarIngredienteOpcOpcaoCommand command = new DeletarIngredienteOpcOpcaoCommand(id);
            _bus.SendCommand(command);
        }

        public IEnumerable<IngredienteOpc_Opcao> Pesquisar(Expression<Func<IngredienteOpc_Opcao, bool>> predicate)
        {
            return _ingredienteOpc_OpcaoRepository.Pesquisar(predicate);
        }

        public IngredienteOpc_Opcao TrazerPorId(Guid id)
        {
           return _ingredienteOpc_OpcaoRepository.TrazerPorId(id);
        }

        public IEnumerable<IngredienteOpc_Opcao> TrazerTodos()
        {
            return _ingredienteOpc_OpcaoRepository.TrazerTodos();
        }

        public IEnumerable<IngredienteOpc_Opcao> TrazerTodosAtivos()
        {
            return _ingredienteOpc_OpcaoRepository.TrazerTodosAtivos();
        }

        public IEnumerable<IngredienteOpc_Opcao> TrazerTodosDeletados()
        {
            return _ingredienteOpc_OpcaoRepository.TrazerTodosDeletados();
        }
    }
}
