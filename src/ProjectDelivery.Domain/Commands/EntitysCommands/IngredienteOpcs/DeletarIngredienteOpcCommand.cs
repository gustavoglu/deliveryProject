using ProjectDelivery.Domain.Validations.IngredienteOpcs;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcs
{
    public class DeletarIngredienteOpcCommand : IngredienteOpcCommand
    {
        public DeletarIngredienteOpcCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            return new DeletarIngredienteOpcValidation().Validate(this).IsValid;
        }
    }
}
