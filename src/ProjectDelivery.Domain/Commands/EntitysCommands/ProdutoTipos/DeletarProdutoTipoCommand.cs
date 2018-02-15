using ProjectDelivery.Domain.Validations.ProdutoTipos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.ProdutoTipos
{
    public class DeletarProdutoTipoCommand : ProdutoTipoCommand
    {
        public DeletarProdutoTipoCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            return new DeletarProdutoTipoValidation().Validate(this).IsValid;
        }
    }
}
