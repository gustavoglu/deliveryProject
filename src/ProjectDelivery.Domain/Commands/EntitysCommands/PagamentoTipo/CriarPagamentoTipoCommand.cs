using ProjectDelivery.Domain.Validations.PagamentoTipos;
namespace ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo
{
    public class CriarPagamentoTipoCommand : PagamentoTipoCommand
    {
        public CriarPagamentoTipoCommand(string descricao)
        {
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            return new CriarPagamentoTipoValidation().Validate(this).IsValid;
        }
    }
}
