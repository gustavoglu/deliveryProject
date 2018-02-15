using ProjectDelivery.Domain.Core.Commands;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcOpcoes
{
    public abstract class IngredienteOpcOpcaoCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorDiferenca { get; set; } = 0;
        public Guid? Id_produto { get; set; }
    }
}
