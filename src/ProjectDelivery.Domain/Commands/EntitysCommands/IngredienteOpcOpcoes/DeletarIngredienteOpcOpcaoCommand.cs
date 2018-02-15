using ProjectDelivery.Domain.Validations.IngredienteOpcOpcoes;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcOpcoes
{
    public class DeletarIngredienteOpcOpcaoCommand : IngredienteOpcOpcaoCommand
    {
        public DeletarIngredienteOpcOpcaoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return new DeletarIngredienteOpcOpcaoValidation().Validate(this).IsValid;
        }
    }
}
