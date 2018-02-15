using System;
using ProjectDelivery.Domain.Core.Entitys;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Entitys
{
    public class ProdutoTipo : Entity
    {
        private List<Guid> _ids_adicional;

        public ProdutoTipo(string descricao, int qtdSaboresLimite = 1, Guid? id_tamanhoPadrao = null, List<Guid> id_adicionais = null)
        {
            Descricao = descricao;
            QtdSaboresLimite = qtdSaboresLimite;
            Id_tamanhoPadrao = id_tamanhoPadrao;
            _ids_adicional = id_adicionais;
        }

        public string Descricao { get; private set; }
        public int QtdSaboresLimite { get; private set; } = 1;
        public Guid? Id_tamanhoPadrao{ get; private set; }
        public List<Guid> Ids_Adicional { get { return _ids_adicional; } }

        public void AdicionarAdicional(Guid id_adicional)
        {
            _ids_adicional.Add(id_adicional);
        }
    }

    public static class ProdutoTipoFactory
    {
        public static ProdutoTipo ProdutoTipoFull(Guid id,string descricao, int qtdSaboresLimite = 1, Guid? id_tamanhoPadrao = null, List<Guid> id_adicionais = null)
        {
            return new ProdutoTipo(descricao, qtdSaboresLimite, id_tamanhoPadrao, id_adicionais) { Id = id };
        }
    }
}
