using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.Tamanhos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectDelivery.Application.Services
{
    public class TamanhoService : ITamanhoService
    {
        private readonly ITamanhoRepository _tamanhoRepository;
        private readonly IBus _bus;
        public TamanhoService(ITamanhoRepository tamanhoRepository, IBus bus)
        {
            _tamanhoRepository = tamanhoRepository;
            _bus = bus;
        }
        public void Atualizar(Tamanho tamanho)
        {
            AtualizarTamanhoCommand atualizarTamanhoCommand = new AtualizarTamanhoCommand(tamanho.Id,tamanho.Descricao);
            _bus.SendCommand(atualizarTamanhoCommand);
        }

        public void Criar(Tamanho tamanho)
        {

            CriarTamanhoCommand criaTamanhoCommand = new CriarTamanhoCommand(tamanho.Descricao);
            _bus.SendCommand(criaTamanhoCommand);
        }

        public void Deletar(Guid id)
        {
            DeletarTamanhoCommand deletarTamanhoCommand = new DeletarTamanhoCommand(id);
            _bus.SendCommand(deletarTamanhoCommand);
        }

        public void Dispose()
        {
            _tamanhoRepository.Dispose();
        }

        public IEnumerable<Tamanho> Pesquisar(Expression<Func<Tamanho, bool>> predicate)
        {
            return _tamanhoRepository.Pesquisar(predicate);
        }

        public void Reativar(Guid id)
        {
            return;
        }

        public Tamanho TrazerPorId(Guid id)
        {
            return _tamanhoRepository.TrazerPorId(id);
        }

        public IEnumerable<Tamanho> TrazerTodos()
        {
            return _tamanhoRepository.TrazerTodos();
        }

        public IEnumerable<Tamanho> TrazerTodosAtivos()
        {
            return _tamanhoRepository.TrazerTodosAtivos();

        }

        public IEnumerable<Tamanho> TrazerTodosDeletados()
        {
            return _tamanhoRepository.TrazerTodosDeletados();

        }
    }
}
