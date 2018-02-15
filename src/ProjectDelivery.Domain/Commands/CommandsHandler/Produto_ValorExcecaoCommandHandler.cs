using ProjectDelivery.Domain.Commands.EntitysCommands.Produto_ValorExcecoes;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class Produto_ValorExcecaoCommandHandler : CommandHandler,IHandler<CriarProduto_ValorExcecaoCommand>, IHandler<AtualizarProduto_ValorExcecaoCommand>, IHandler<DeletarProduto_ValorExcecaoCommand>
    {
        private readonly IProduto_ValorExcecaoRepository _produto_ValorExcecaoRepository;
        public Produto_ValorExcecaoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IProduto_ValorExcecaoRepository produto_ValorExcecaoRepository) : base(uow, bus, notifications)
        {
            _produto_ValorExcecaoRepository = produto_ValorExcecaoRepository;
        }

        public void Handle(CriarProduto_ValorExcecaoCommand message)
        {
            if (!CommandValido(message)) return;
            Produto_ValorExcecao produto_ValorExcecao = new Produto_ValorExcecao(message.Id_produto, message.Id_produtoTipo, message.Valor, message.Id_periodo, message.Promocao, message.Porcentagem);
            _produto_ValorExcecaoRepository.Criar(produto_ValorExcecao);
            if (!Commit()) return;
        }

        public void Handle(AtualizarProduto_ValorExcecaoCommand message)
        {
            if (!CommandValido(message)) return;
            Produto_ValorExcecao produto_ValorExcecao = Produto_ValorExcecaoFactory.Produto_ValorExcecaoFull(message.Id,message.Id_produto, message.Id_produtoTipo, message.Valor, message.Id_periodo, message.Promocao, message.Porcentagem);
            _produto_ValorExcecaoRepository.Atualizar(produto_ValorExcecao);
            if (!Commit()) return;
        }

        public void Handle(DeletarProduto_ValorExcecaoCommand message)
        {
            if (!CommandValido(message)) return;
            _produto_ValorExcecaoRepository.Deletar(message.Id);
            if (!Commit()) return;
        }
    }
}
