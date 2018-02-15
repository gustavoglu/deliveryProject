using ProjectDelivery.Domain.Validations.Produtos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Produtos
{
    public class DeletarProdutoCommand : ProdutoCommand
    {
        public DeletarProdutoCommand(Guid id)
        {
            this.Id = id;
        }
        public override bool IsValid()
        {
            return new DeletarProdutoValidation().Validate(this).IsValid;
        }
    }
}
