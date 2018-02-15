using ProjectDelivery.Domain.Validations.IngredienteOpcs;
using System;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcs
{
    public class CriarIngredienteOpcCommand : IngredienteOpcCommand
    {
        public CriarIngredienteOpcCommand(string descricao, Guid id_produtoTipo, List<Guid> ids_ingredienteOpc_Opcoes)
        {
            Descricao = descricao;
            Id_produtoTipo = id_produtoTipo;
            Ids_ingredienteOpc_Opcoes = ids_ingredienteOpc_Opcoes ?? new List<Guid>();
        }

        public override bool IsValid()
        {
            return new CriarIngredienteOpcValidation().Validate(this).IsValid;
        }
    }
}
