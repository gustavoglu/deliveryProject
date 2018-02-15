using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.Adicionais;

namespace ProjectDelivery.Domain.Validations.Adicionais
{
    public class AdicionalValidation<T> : AbstractValidator<T> where T : AdicionalCommand
    {
    }
}
