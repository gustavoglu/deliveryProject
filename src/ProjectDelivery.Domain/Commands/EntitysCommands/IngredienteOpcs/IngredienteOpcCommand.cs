using ProjectDelivery.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcs
{
    public abstract class IngredienteOpcCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid Id_produtoTipo { get; set; }
        public List<Guid> Ids_ingredienteOpc_Opcoes { get; set; }
    }
}
