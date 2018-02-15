using ProjectDelivery.Domain.Validations.Pedidos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Pedidos
{
    public class DeletarPedidoCommand : PedidoCommand
    {
        public DeletarPedidoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return new DeletarPedidoValidation().Validate(this).IsValid;
        }
    }
}
