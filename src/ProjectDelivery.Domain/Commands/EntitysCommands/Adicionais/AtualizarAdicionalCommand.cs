using System;
using ProjectDelivery.Domain.Validations.Adicionais;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Adicionais
{
    public class AtualizarAdicionalCommand : AdicionalCommand
    {
        public AtualizarAdicionalCommand(Guid id,string descricao, decimal valorDiferenca, Guid? id_Produto)
        {
            Id = id;
            Descricao = descricao;
            ValorDiferenca = valorDiferenca;
            Id_Produto = id_Produto;
        }

        public override bool IsValid()
        {
            return new AtualizarAdicionalValidation().Validate(this).IsValid;
        }
    }
}
