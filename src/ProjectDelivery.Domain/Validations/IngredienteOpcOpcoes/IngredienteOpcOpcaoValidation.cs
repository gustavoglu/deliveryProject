using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcOpcoes;

namespace ProjectDelivery.Domain.Validations.IngredienteOpcOpcoes
{
    public class IngredienteOpcOpcaoValidation<T> : AbstractValidator<T> where T : IngredienteOpcOpcaoCommand
    {
        public IngredienteOpcOpcaoValidation()
        {

        }
    }
}
