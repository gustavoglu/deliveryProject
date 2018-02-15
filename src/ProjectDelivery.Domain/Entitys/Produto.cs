using System;
using ProjectDelivery.Domain.Core.Entitys;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Entitys
{
    public class Produto : Entity
    {
        private List<Guid> _ids_tamanhos;
        private List<Guid> _ids_produto_ValorExcecao;

        public Produto(string nome, string descricao, decimal valor, string imagemUri = null, bool sabor = false, Guid id_produtoTipo = default(Guid), 
                        List<Guid> ids_tamanho = null, List<Guid> ids_produto_ValorExcecao = null)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            ImagemUri = imagemUri;
            Sabor = sabor;
            _ids_tamanhos = ids_tamanho ?? new List<Guid> ();
            _ids_produto_ValorExcecao = ids_produto_ValorExcecao ?? new List<Guid> ();
            Id_produtoTipo = id_produtoTipo;
            
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public string ImagemUri { get; private set; } = null;
        public bool Sabor { get; private set; } = false;
        public Guid Id_produtoTipo { get; private set; }
        public List<Guid> Ids_tamanhos { get { return _ids_tamanhos; } }
        public List<Guid> Ids_produto_valorExcecoes { get { return _ids_produto_ValorExcecao; } }

        public void AdicionarTamanho(Guid id_tamanho)
        {
            _ids_tamanhos.Add(id_tamanho);
        }

        public void AdicionarValorExcecao(Guid id_produto_ValorExcecao)
        {
            _ids_produto_ValorExcecao.Add(id_produto_ValorExcecao);
        }
    }

    public static class ProdutoFactory
    {
        public static Produto ProdutoFull(Guid id, string nome, string descricao, decimal valor, string imagemUri = null, bool sabor = false, 
                                            Guid id_produtoTipo = default(Guid), List<Guid> ids_tamanho = null, List<Guid> ids_produto_ValorExcecao = null)
        {
            return new Produto(nome,descricao,valor,imagemUri,sabor,id_produtoTipo,ids_tamanho,ids_produto_ValorExcecao) { Id = id };
        }
    }
}
