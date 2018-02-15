using System;
using ProjectDelivery.Domain.Core.Entitys;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Entitys
{
    public class IngredienteOpc : Entity
    {
        private List<Guid> _Ids_ingredienteOpc_Opcoes;

        public IngredienteOpc(string descricao, Guid id_produtoTipo , List<Guid> ids_ingredienteOpc_Opcoes)
        {
            Descricao = descricao;
            Id_produtoTipo = id_produtoTipo;
            _Ids_ingredienteOpc_Opcoes = ids_ingredienteOpc_Opcoes ?? new List<Guid> ();
        }

        public string Descricao { get; private set; }
        public Guid Id_produtoTipo { get; private set; }
        public List<Guid> Ids_ingredienteOpc_Opcoes { get { return _Ids_ingredienteOpc_Opcoes; } }

        public void AcrescentarOpcao(Guid ids_ingredienteOpc_Opcoes)
        {
            _Ids_ingredienteOpc_Opcoes.Add(ids_ingredienteOpc_Opcoes);
        }

    }

    public static class IngredienteOpcFactory
    {
        public static IngredienteOpc IngredienteOpcFull(Guid id,string descricao, Guid id_produtoTipo, List<Guid> ids_ingredienteOpc_Opcoes)
        {
            return new IngredienteOpc(descricao, id_produtoTipo, ids_ingredienteOpc_Opcoes) { Id = id };
        }
    }
}
