using ProjectDelivery.Domain.Validations.Tamanhos;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Tamanhos
{
    public class CriarTamanhoCommand : TamanhoCommand
    {
        public CriarTamanhoCommand(string descricao)
        {
            this.Descricao = descricao;
        }

        public override bool IsValid()
        {
            return new CriarTamanhoValidation().Validate(this).IsValid;
        }
    }
}
