using ProjectDelivery.Domain.Validations.IngredienteOpcOpcoes;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcOpcoes
{
    public class AtualizarIngredienteOpcOpcaoCommand : IngredienteOpcOpcaoCommand
    {
        public AtualizarIngredienteOpcOpcaoCommand(Guid id,string descricao, decimal valorDiferenca, Guid? id_produto)
        {
            Id = id;
            Descricao = descricao;
            ValorDiferenca = valorDiferenca;
            Id_produto = id_produto;
        }
        public override bool IsValid()
        {
            return new AtualizarIngredienteOpcOpcaoValidation().Validate(this).IsValid;
        }
    }
}
