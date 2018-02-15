using ProjectDelivery.Domain.Commands.EntitysCommands.Periodos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class PeriodoCommandHandler : CommandHandler,IHandler<CriarPeriodoCommand>, IHandler<AtualizarPeriodoCommand>, IHandler<DeletarPeriodoCommand>
    {
        private readonly IPeriodoRepository _periodoRepository;
        public PeriodoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPeriodoRepository periodoRepository) : base(uow, bus, notifications)
        {
            _periodoRepository = periodoRepository;
        }

        public void Handle(CriarPeriodoCommand message)
        {
            if (!CommandValido(message)) return ;
            Periodo periodo = new Periodo(message.Descricao, message.Segunda, message.Terca, message.Quarta, message.Quinta, message.Sexta,
                                            message.Sabado, message.Domingo, message.TodosOsDias, message.DataRepeticaoIni, message.DataRepeticaoFim,
                                            message.HoraIni, message.HoraFim, message.RepetirSempre);

            _periodoRepository.Criar(periodo);
            if (!Commit()) return;
        }

        public void Handle(AtualizarPeriodoCommand message)
        {
            if (!CommandValido(message)) return;
            Periodo periodo = PeriodoFactory.PeriodoFull(message.Id,message.Descricao, message.Segunda, message.Terca, message.Quarta, message.Quinta, message.Sexta,
                                            message.Sabado, message.Domingo, message.TodosOsDias, message.DataRepeticaoIni, message.DataRepeticaoFim,
                                            message.HoraIni, message.HoraFim, message.RepetirSempre);

            _periodoRepository.Atualizar(periodo);
            if (!Commit()) return;
        }

        public void Handle(DeletarPeriodoCommand message)
        {
            if (!CommandValido(message)) return;
            _periodoRepository.Deletar(message.Id);
            if (!Commit()) return;
        }
    }
}
