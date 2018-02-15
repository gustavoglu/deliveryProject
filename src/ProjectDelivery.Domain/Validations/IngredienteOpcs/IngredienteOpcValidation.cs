using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcs;

namespace ProjectDelivery.Domain.Validations.IngredienteOpcs
{
    public class IngredienteOpcValidation<T> : AbstractValidator<T> where T : IngredienteOpcCommand
    {
    }
}
