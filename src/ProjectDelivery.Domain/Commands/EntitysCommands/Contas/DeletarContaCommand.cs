using System;
using ProjectDelivery.Domain.Validations.Contas;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Contas
{
    public class DeletarContaCommand : ContaCommand
    {
        public DeletarContaCommand(Guid id)
        {
            this._id = id;
        }

        public override bool IsValid()
        {
            return new DeletarContaValidation().Validate(this).IsValid;
        }
    }
}
