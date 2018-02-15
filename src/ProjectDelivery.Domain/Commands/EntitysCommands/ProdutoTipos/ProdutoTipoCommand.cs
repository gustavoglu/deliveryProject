using ProjectDelivery.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.ProdutoTipos
{
    public abstract class ProdutoTipoCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int QtdSaboresLimite { get; set; } = 1;
        public Guid? Id_tamanhoPadrao { get; set; }
        public List<Guid> Ids_Adicional { get; set; }
    }
}
