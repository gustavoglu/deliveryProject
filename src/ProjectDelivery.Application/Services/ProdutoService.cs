using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.Produtos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IBus _bus;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IBus bus, IProdutoRepository produtoRepository)
        {
            _bus = bus;
            _produtoRepository = produtoRepository;
        }

        public void Atualizar(Produto produto)
        {
            AtualizarProdutoCommand command = new AtualizarProdutoCommand(produto.Id, produto.Nome, produto.Descricao, produto.Valor, produto.ImagemUri, produto.Sabor, produto.Id_produtoTipo, produto.Ids_tamanhos, produto.Ids_produto_valorExcecoes);
            _bus.SendCommand(command);
        }

        public void Criar(Produto produto)
        {
            CriarProdutoCommand command = new CriarProdutoCommand(produto.Nome, produto.Descricao, produto.Valor, produto.ImagemUri, produto.Sabor, produto.Id_produtoTipo, produto.Ids_tamanhos, produto.Ids_produto_valorExcecoes);
            _bus.SendCommand(command);
        }

        public void Deletar(Guid id)
        {
            DeletarProdutoCommand command = new DeletarProdutoCommand(id);
            _bus.SendCommand(command);
        }

        public IEnumerable<Produto> Pesquisar(Expression<Func<Produto, bool>> predicate)
        {
            return _produtoRepository.Pesquisar(predicate);
        }

        public Produto TrazerPorId(Guid id)
        {
            return _produtoRepository.TrazerPorId(id);
        }

        public IEnumerable<Produto> TrazerTodos()
        {
            return _produtoRepository.TrazerTodos();
        }

        public IEnumerable<Produto> TrazerTodosAtivos()
        {
            return _produtoRepository.TrazerTodosAtivos();
        }

        public IEnumerable<Produto> TrazerTodosDeletados()
        {
            return _produtoRepository.TrazerTodosDeletados();
        }
    }
}
