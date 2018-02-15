using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.Tamanhos;

namespace ProjectDelivery.Domain.Validations.Tamanhos
{
    public class TamanhoValidation<T> : AbstractValidator<T> where T : TamanhoCommand
    {
    }
}
