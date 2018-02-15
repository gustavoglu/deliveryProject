using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.Periodos;

namespace ProjectDelivery.Domain.Validations.Periodos
{
    public class PeriodoValidation<T> : AbstractValidator<T> where T : PeriodoCommand
    {
    }
}
