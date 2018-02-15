using ProjectDelivery.Domain.Commands.EntitysCommands.Pedidos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class PedidoCommandHandler : CommandHandler, IHandler<CriarPedidoCommand>, IHandler<AtualizarPedidoCommand>, IHandler<DeletarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPedidoRepository pedidoRepository) : base(uow, bus, notifications)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void Handle(CriarPedidoCommand message)
        {
            if (!CommandValido(message)) return;
            Pedido pedido = new Pedido(message.Status, message.Entregue, message.Cancelado, message.Total, message.Id_loja, message.Id_pagamentoTipo, message.Cliente, message.Pedido_Produtos);
            _pedidoRepository.Criar(pedido);
            if (!Commit()) return;
        }

        public void Handle(AtualizarPedidoCommand message)
        {
            if (!CommandValido(message)) return;
            Pedido pedido = Pedido_ProdutoFactory.PedidoFull(message.Id,message.Status, message.Entregue, message.Cancelado, message.Total, message.Id_loja, message.Id_pagamentoTipo, message.Cliente, message.Pedido_Produtos);
            _pedidoRepository.Atualizar(pedido);
            if (!Commit()) return;
        }

        public void Handle(DeletarPedidoCommand message)
        {
            if (!CommandValido(message)) return;
            _pedidoRepository.Deletar(message.Id);
            if (!Commit()) return;
        }
    }
}
