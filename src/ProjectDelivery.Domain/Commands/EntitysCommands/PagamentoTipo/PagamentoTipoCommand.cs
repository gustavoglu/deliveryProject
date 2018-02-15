using ProjectDelivery.Domain.Core.Commands;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo
{
    public abstract class PagamentoTipoCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
