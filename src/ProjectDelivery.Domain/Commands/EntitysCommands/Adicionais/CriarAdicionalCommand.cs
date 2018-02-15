using System;
using ProjectDelivery.Domain.Validations.Adicionais;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Adicionais
{
    public class CriarAdicionalCommand : AdicionalCommand
    {
        public  CriarAdicionalCommand(string descricao, decimal valorDiferenca, Guid? id_Produto)
        {
            Descricao = descricao;
            ValorDiferenca = valorDiferenca;
            Id_Produto = id_Produto;
        }
        public override bool IsValid()
        {
            return new CriarAdicionalValidation().Validate(this).IsValid;
        }
    }
}
