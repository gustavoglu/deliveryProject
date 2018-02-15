using ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class PagamentoTipoCommandHandler : CommandHandler, IHandler<CriarPagamentoTipoCommand>, IHandler<AtualizarPagamentoTipoCommand>, IHandler<DeletarPagamentoTipoCommand>
    {
        private readonly IPagamentoTipoRepository _pagamentoTipoRepository;
        public PagamentoTipoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPagamentoTipoRepository pagamentoTipoRepository) : base(uow, bus, notifications)
        {
            _pagamentoTipoRepository = pagamentoTipoRepository;
        }

        public void Handle(CriarPagamentoTipoCommand message)
        {
            if (!CommandValido(message)) return;
            PagamentoTipo PagamentoTipo = new PagamentoTipo(message.Descricao);
            _pagamentoTipoRepository.Criar(PagamentoTipo);
            if (!Commit()) return;
        }

        public void Handle(AtualizarPagamentoTipoCommand message)
        {
            if (!CommandValido(message)) return;
            PagamentoTipo PagamentoTipo =  PagamentoTipoFactory.PagamentoTipoFull(message.Id,message.Descricao);
            _pagamentoTipoRepository.Criar(PagamentoTipo);
            if (!Commit()) return;
        }

        public void Handle(DeletarPagamentoTipoCommand message)
        {
            if (!CommandValido(message)) return;
            _pagamentoTipoRepository.Deletar(message.Id);
            if (!Commit()) return;
        }
    }
}
