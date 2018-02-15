using System;
using ProjectDelivery.Domain.Core.Commands;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Adicionais
{
    public abstract class AdicionalCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get;  set; }
        public decimal ValorDiferenca { get;  set; } = 0;
        public Guid? Id_Produto { get;  set; }
    }
}
