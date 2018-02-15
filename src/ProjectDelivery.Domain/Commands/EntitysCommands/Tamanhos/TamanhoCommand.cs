using ProjectDelivery.Domain.Core.Commands;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Tamanhos
{
    public abstract class TamanhoCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
