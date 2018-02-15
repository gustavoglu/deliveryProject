using ProjectDelivery.Domain.Validations.Produto_ValorExcecoes;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Produto_ValorExcecoes
{
    public class DeletarProduto_ValorExcecaoCommand : Produto_ValorExcecaoCommand
    {
        public DeletarProduto_ValorExcecaoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return new DeletarProduto_ValorExcecaoValidation().Validate(this).IsValid;
        }
    }
}
