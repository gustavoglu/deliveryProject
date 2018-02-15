using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.Pedidos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IBus _bus;
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository, IBus bus)
        {
            _bus = bus;
            _pedidoRepository = pedidoRepository;
        }

        public void Atualizar(Pedido pedido)
        {
            AtualizarPedidoCommand command = new AtualizarPedidoCommand(pedido.Id, pedido.Status, pedido.Entregue, pedido.Cancelado, pedido.Total, pedido.Id_loja, pedido.Id_pagamentoTipo, pedido.Cliente, pedido.Pedido_Produtos);
            _bus.SendCommand(command);
        }

        public void Criar(Pedido pedido)
        {
            CriarPedidoCommand command = new CriarPedidoCommand(pedido.Status, pedido.Entregue, pedido.Cancelado, pedido.Total, pedido.Id_loja, pedido.Id_pagamentoTipo, pedido.Cliente, pedido.Pedido_Produtos);
            _bus.SendCommand(command);
        }

        public void Deletar(Guid id)
        {
            DeletarPedidoCommand command = new DeletarPedidoCommand(id);
            _bus.SendCommand(command);
        }

        public IEnumerable<Pedido> Pesquisar(Expression<Func<Pedido, bool>> predicate)
        {
            return _pedidoRepository.Pesquisar(predicate);
        }

        public Pedido TrazerPorId(Guid id)
        {
            return _pedidoRepository.TrazerPorId(id);
        }

        public IEnumerable<Pedido> TrazerTodos()
        {
            return _pedidoRepository.TrazerTodos();
        }

        public IEnumerable<Pedido> TrazerTodosAtivos()
        {
            return _pedidoRepository.TrazerTodosAtivos();
        }

        public IEnumerable<Pedido> TrazerTodosDeletados()
        {
            return _pedidoRepository.TrazerTodosDeletados();
        }
    }
}
