using ProjectDelivery.Domain.Commands.EntitysCommands.ProdutoTipos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class ProdutoTipoCommandHandler : CommandHandler, IHandler<CriarProdutoTipoCommand>, IHandler<AtualizarProdutoTipoCommand>, IHandler<DeletarProdutoTipoCommand>
    {
        private readonly IProdutoTipoRepository _produtoTipoRepository;
        public ProdutoTipoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IProdutoTipoRepository produtoTipoRepository) : base(uow, bus, notifications)
        {
            _produtoTipoRepository = produtoTipoRepository;
        }

        public void Handle(CriarProdutoTipoCommand message)
        {
            if (!CommandValido(message)) return;
            ProdutoTipo produtoTipo = new ProdutoTipo(message.Descricao, message.QtdSaboresLimite, message.Id_tamanhoPadrao, message.Ids_Adicional);
            _produtoTipoRepository.Criar(produtoTipo);
            if (!Commit()) return;
        }

        public void Handle(AtualizarProdutoTipoCommand message)
        {
            if (!CommandValido(message)) return;
            ProdutoTipo produtoTipo =  ProdutoTipoFactory.ProdutoTipoFull(message.Id,message.Descricao, message.QtdSaboresLimite, message.Id_tamanhoPadrao, message.Ids_Adicional);
            _produtoTipoRepository.Atualizar(produtoTipo);
            if (!Commit()) return;
        }

        public void Handle(DeletarProdutoTipoCommand message)
        {
            if (!CommandValido(message)) return;
            _produtoTipoRepository.Deletar(message.Id);
            if (!Commit()) return;
        }
    }
}
