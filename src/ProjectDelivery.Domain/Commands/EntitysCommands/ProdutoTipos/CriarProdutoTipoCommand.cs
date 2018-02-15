using ProjectDelivery.Domain.Validations.ProdutoTipos;
using System;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.ProdutoTipos
{
    public class CriarProdutoTipoCommand : ProdutoTipoCommand
    {
        public CriarProdutoTipoCommand(string descricao, int qtdSaboresLimite = 1, Guid? id_tamanhoPadrao = null, List<Guid> id_adicionais = null)
        {
            Descricao = descricao;
            QtdSaboresLimite = qtdSaboresLimite;
            Id_tamanhoPadrao = id_tamanhoPadrao;
            Ids_Adicional = id_adicionais;
        }

        public override bool IsValid()
        {
            return new CriarProdutoTipoValidation().Validate(this).IsValid;
        }
    }
}
