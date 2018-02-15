using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.Contas;

namespace ProjectDelivery.Domain.Validations.Contas
{
    public class ContaValidation<T> : AbstractValidator<T> where T : ContaCommand
    {
    }
}
