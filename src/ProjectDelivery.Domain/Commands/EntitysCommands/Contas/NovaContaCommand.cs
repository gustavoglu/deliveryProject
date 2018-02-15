using ProjectDelivery.Domain.Validations.Contas;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Contas
{
    public class NovaContaCommand : ContaCommand
    {
        public NovaContaCommand(string responsavel, string documento, string nomeFantasia, string logoUri, string sobre, string informacoes, string ajuda)
        {
            Responsavel = responsavel;
            Documento = documento;
            NomeFantasia = nomeFantasia;
            LogoUri = logoUri;
            Sobre = sobre;
            Informacoes = informacoes;
            Ajuda = ajuda;
        }

        public override bool IsValid()
        {
            return new NovaContaValidation().Validate(this).IsValid;
        }
    }
}
