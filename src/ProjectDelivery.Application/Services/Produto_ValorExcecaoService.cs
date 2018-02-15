using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.Produto_ValorExcecoes;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Services
{
    public class Produto_ValorExcecaoService : IProduto_ValorExcecaoService
    {
        private readonly IBus _bus;
        private readonly IProduto_ValorExcecaoRepository _produto_ValorExcecaoRepository;
        public Produto_ValorExcecaoService(IBus bus, IProduto_ValorExcecaoRepository produto_ValorExcecaoRepository)
        {
            _produto_ValorExcecaoRepository = produto_ValorExcecaoRepository;
            _bus = bus;
        }
        public void Atualizar(Produto_ValorExcecao produto_ValorExcecao)
        {
            AtualizarProduto_ValorExcecaoCommand command = new AtualizarProduto_ValorExcecaoCommand(produto_ValorExcecao.Id, produto_ValorExcecao.Id_produto, produto_ValorExcecao.Id_produtoTipo, produto_ValorExcecao.Valor,
                                                                                                    produto_ValorExcecao.Id_periodo, produto_ValorExcecao.Promocao, produto_ValorExcecao.Porcentagem);

            _bus.SendCommand(command);
        }

        public void Criar(Produto_ValorExcecao produto_ValorExcecao)
        {
            CriarProduto_ValorExcecaoCommand command = new CriarProduto_ValorExcecaoCommand(produto_ValorExcecao.Id_produto, produto_ValorExcecao.Id_produtoTipo, produto_ValorExcecao.Valor,
                                                                                                   produto_ValorExcecao.Id_periodo, produto_ValorExcecao.Promocao, produto_ValorExcecao.Porcentagem);

            _bus.SendCommand(command);
        }

        public void Deletar(Guid id)
        {
            DeletarProduto_ValorExcecaoCommand command = new DeletarProduto_ValorExcecaoCommand(id);

            _bus.SendCommand(command);
        }

        public IEnumerable<Produto_ValorExcecao> Pesquisar(Expression<Func<Produto_ValorExcecao, bool>> predicate)
        {
            return _produto_ValorExcecaoRepository.Pesquisar(predicate);
        }

        public Produto_ValorExcecao TrazerPorId(Guid id)
        {
            return _produto_ValorExcecaoRepository.TrazerPorId(id);
        }

        public IEnumerable<Produto_ValorExcecao> TrazerTodos()
        {
            return _produto_ValorExcecaoRepository.TrazerTodos();
        }

        public IEnumerable<Produto_ValorExcecao> TrazerTodosAtivos()
        {
            return _produto_ValorExcecaoRepository.TrazerTodosAtivos();
        }

        public IEnumerable<Produto_ValorExcecao> TrazerTodosDeletados()
        {
            return _produto_ValorExcecaoRepository.TrazerTodosDeletados();
        }
    }
}
