using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Commands;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _uow = uow;
            _notifications = notifications;
        }

        public void AdicionarNotificacoes(Command command)
        {
            foreach (var error in command.Validations.Errors)
                AdicionarNovaNotificacao(command.MessageType, error.ErrorMessage);
        }

        public bool Commit()
        {
            if (_notifications.HasNotification()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;
            AdicionarNovaNotificacao("Commit", "Erro ao atualizar o banco de dados ");
            return false;
        }

        protected bool CommandValido(Command command)
        {
            if (!command.IsValid())
            {
                AdicionarNotificacoes(command);
                return false;
            }

            return true;
        }

        protected void AdicionarNovaNotificacao(string key, string value)
        {
            _bus.RaizeEvent(new DomainNotification(key, value));
        }
    }
}
