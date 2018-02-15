using ProjectDelivery.Domain.Validations.Tamanhos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Tamanhos
{
    public class DeletarTamanhoCommand : TamanhoCommand
    {
        public DeletarTamanhoCommand(Guid id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            return new DeletarTamanhoValidation().Validate(this).IsValid;
        }
    }
}
