using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.Pedidos;

namespace ProjectDelivery.Domain.Validations.Pedidos
{
    public class PedidoValidation<T> : AbstractValidator<T> where T : PedidoCommand
    {
    }
}
