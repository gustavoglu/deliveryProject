using System;
using ProjectDelivery.Domain.Validations.Adicionais;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Adicionais
{
    public class DeletarAdicionalCommand : AdicionalCommand
    {
        public DeletarAdicionalCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            return new DeletarAdicionalValidation().Validate(this).IsValid;
        }
    }
}
