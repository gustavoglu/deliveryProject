using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.ProdutoTipos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Services
{
    public class ProdutoTipoService : IProdutoTipoService
    {
        private readonly IBus _bus;
        private readonly IProdutoTipoRepository _produtoTipoRepository;

        public ProdutoTipoService(IBus bus, IProdutoTipoRepository produtoTipoRepository)
        {
            _bus = bus;
            _produtoTipoRepository = produtoTipoRepository;
        }
        public void Atualizar(ProdutoTipo produtoTipo)
        {
            AtualizarProdutoTipoCommand atualizarProdutoTipoCommand = new AtualizarProdutoTipoCommand(produtoTipo.Id, produtoTipo.Descricao, produtoTipo.QtdSaboresLimite, produtoTipo.Id_tamanhoPadrao, produtoTipo.Ids_Adicional);
            _bus.SendCommand(atualizarProdutoTipoCommand);
        }

        public void Criar(ProdutoTipo produtoTipo)
        {
            CriarProdutoTipoCommand criarProdutoTipoCommand = new CriarProdutoTipoCommand(produtoTipo.Descricao, produtoTipo.QtdSaboresLimite, produtoTipo.Id_tamanhoPadrao, produtoTipo.Ids_Adicional);
            _bus.SendCommand(criarProdutoTipoCommand);
        }

        public void Deletar(Guid id)
        {
            DeletarProdutoTipoCommand command = new DeletarProdutoTipoCommand(id);
            _bus.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ProdutoTipo> Pesquisar(Expression<Func<ProdutoTipo, bool>> predicate)
        {
            return _produtoTipoRepository.Pesquisar(predicate);
        }

        public ProdutoTipo TrazerPorId(Guid id)
        {
            return _produtoTipoRepository.TrazerPorId(id);
        }

        public IEnumerable<ProdutoTipo> TrazerTodos()
        {
            return _produtoTipoRepository.TrazerTodos();
        }

        public IEnumerable<ProdutoTipo> TrazerTodosAtivos()
        {
            return _produtoTipoRepository.TrazerTodosAtivos();

        }

        public IEnumerable<ProdutoTipo> TrazerTodosDeletados()
        {
            return _produtoTipoRepository.TrazerTodosDeletados();

        }
    }
}
