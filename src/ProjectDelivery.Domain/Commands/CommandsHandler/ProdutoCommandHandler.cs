using ProjectDelivery.Domain.Commands.EntitysCommands.Produtos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class ProdutoCommandHandler : CommandHandler, IHandler<CriarProdutoCommand>, IHandler<AtualizarProdutoCommand>, IHandler<DeletarProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IProdutoRepository produtoRepository) 
            : base(uow, bus, notifications)
        {
            _produtoRepository = produtoRepository;
        }

        public void Handle(CriarProdutoCommand message)
        {
            if (!CommandValido(message)) return;

            Produto produto = new Produto(message.Nome,message.Descricao,message.Valor,message.ImagemUri,message.Sabor,message.Id_produtoTipo,message.Ids_tamanhos,message.Ids_produto_valorExcecoes);
            _produtoRepository.Criar(produto);
            if (!Commit()) return;
        }

        public void Handle(AtualizarProdutoCommand message)
        {
            if (!CommandValido(message)) return;
            Produto produto = new Produto(message.Nome, message.Descricao, message.Valor, message.ImagemUri, message.Sabor,message.Id_produtoTipo, message.Ids_tamanhos, message.Ids_produto_valorExcecoes);
            _produtoRepository.Atualizar(produto);
            if (!Commit()) return;
        }

        public void Handle(DeletarProdutoCommand message)
        {
            if (!CommandValido(message)) return;
            _produtoRepository.Deletar(message.Id);
            if (!Commit()) return;
        }
    }
}
