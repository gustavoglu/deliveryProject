using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.Adicionais;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectDelivery.Application.Services
{
    public class AdicionalService : IAdicionalService
    {
        private readonly IAdicionalRepository _adicionalRepository;
        private readonly IBus _bus;
        public AdicionalService(IAdicionalRepository adicionalRepository, IBus bus)
        {
            _adicionalRepository = adicionalRepository;
            _bus = bus;
        }
        public void Atualizar(Adicional adicional)
        {
            AtualizarAdicionalCommand atualizarAdicionalCommand = new AtualizarAdicionalCommand(adicional.Id, adicional.Descricao, adicional.ValorDiferenca, adicional.Id_Produto);
            _bus.SendCommand(atualizarAdicionalCommand);
        }

        public void Criar(Adicional adicional)
        {
            CriarAdicionalCommand criarAdicionalCommand = new CriarAdicionalCommand(adicional.Descricao, adicional.ValorDiferenca, adicional.Id_Produto);
            _bus.SendCommand(criarAdicionalCommand);
        }

        public void Deletar(Guid id)
        {
            DeletarAdicionalCommand deletarAdicionalCommand = new DeletarAdicionalCommand(id);
            _bus.SendCommand(deletarAdicionalCommand);
        }

        public void Dispose()
        {
            _adicionalRepository.Dispose();
        }

        public IEnumerable<Adicional> Pesquisar(Expression<Func<Adicional, bool>> predicate)
        {
            return _adicionalRepository.Pesquisar(predicate);
        }

        public void Reativar(Guid id)
        {
            return;
        }

        public Adicional TrazerPorId(Guid id)
        {
            return _adicionalRepository.TrazerPorId(id);
        }

        public IEnumerable<Adicional> TrazerTodos()
        {
            return _adicionalRepository.TrazerTodos();
        }

        public IEnumerable<Adicional> TrazerTodosAtivos()
        {
            return _adicionalRepository.TrazerTodosAtivos();
        }

        public IEnumerable<Adicional> TrazerTodosDeletados()
        {
            return _adicionalRepository.TrazerTodosDeletados();
        }
    }
}
