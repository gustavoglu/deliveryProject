using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Services
{
    public class PagamentoTipoService : IPagamentoTipoService
    {
        private readonly IBus _bus;
        private readonly IPagamentoTipoRepository _pagamentoTipoRepository;
        public PagamentoTipoService(IBus bus, IPagamentoTipoRepository pagamentoTipoRepository)
        {
            _pagamentoTipoRepository = pagamentoTipoRepository;
            _bus = bus;
        }
        public void Atualizar(PagamentoTipo pagamentoTipo)
        {
            AtualizarPagamentoTipoCommand command = new AtualizarPagamentoTipoCommand(pagamentoTipo.Id, pagamentoTipo.Descricao);
            _bus.SendCommand(command);
        }

        public void Criar(PagamentoTipo pagamentoTipo)
        {
            CriarPagamentoTipoCommand command = new CriarPagamentoTipoCommand(pagamentoTipo.Descricao);
            _bus.SendCommand(command);
        }

        public void Deletar(Guid id)
        {
            DeletarPagamentoTipoCommand command = new DeletarPagamentoTipoCommand(id);
            _bus.SendCommand(command);
        }

        public IEnumerable<PagamentoTipo> Pesquisar(Expression<Func<PagamentoTipo, bool>> predicate)
        {
            return _pagamentoTipoRepository.Pesquisar(predicate);
        }

        public PagamentoTipo TrazerPorId(Guid id)
        {
            return _pagamentoTipoRepository.TrazerPorId(id);
        }

        public IEnumerable<PagamentoTipo> TrazerTodos()
        {
            return _pagamentoTipoRepository.TrazerTodos();
        }

        public IEnumerable<PagamentoTipo> TrazerTodosAtivos()
        {
            return _pagamentoTipoRepository.TrazerTodosAtivos();
        }


        public IEnumerable<PagamentoTipo> TrazerTodosDeletados()
        {
            return _pagamentoTipoRepository.TrazerTodosDeletados();
        }
    }
}
