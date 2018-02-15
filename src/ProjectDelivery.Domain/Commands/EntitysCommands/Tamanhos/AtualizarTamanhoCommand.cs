using ProjectDelivery.Domain.Validations.Tamanhos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Tamanhos
{
    public class AtualizarTamanhoCommand : TamanhoCommand
    {
        public AtualizarTamanhoCommand(Guid id,string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }
        public override bool IsValid()
        {
            return new AtualizarTamanhoValidation().Validate(this).IsValid;
        }
    }
}
