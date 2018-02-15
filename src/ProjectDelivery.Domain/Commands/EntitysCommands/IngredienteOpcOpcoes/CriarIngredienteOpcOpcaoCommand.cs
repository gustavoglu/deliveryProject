using ProjectDelivery.Domain.Validations.IngredienteOpcOpcoes;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcOpcoes
{
    public class CriarIngredienteOpcOpcaoCommand : IngredienteOpcOpcaoCommand
    {
        public CriarIngredienteOpcOpcaoCommand(string descricao, decimal valorDiferenca, Guid? id_produto)
        {
            Descricao = descricao;
            ValorDiferenca = valorDiferenca;
            Id_produto = id_produto;
        }
        public override bool IsValid()
        {
            return new CriarIngredienteOpcOpcaoValidation().Validate(this).IsValid;
        }
    }
}
