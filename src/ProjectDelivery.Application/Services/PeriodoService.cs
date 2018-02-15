using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Commands.EntitysCommands.Periodos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectDelivery.Application.Services
{
    public class PeriodoService : IPeriodoService
    {
        private readonly IPeriodoRepository _periodoRepository;
        private readonly IBus _bus;
        public PeriodoService(IPeriodoRepository periodoRepository, IBus bus)
        {
            _bus = bus;
            _periodoRepository = periodoRepository;
        }
        public void Atualizar(Periodo periodo)
        {
            AtualizarPeriodoCommand command = new AtualizarPeriodoCommand(periodo.Id, periodo.Descricao, periodo.Segunda, periodo.Terca, periodo.Quarta,
                                                                           periodo.Quinta,periodo.Sexta, periodo.Sabado, periodo.Domingo, periodo.TodosOsDias, periodo.RepetirSempre,
                                                                           periodo.DataRepeticaoIni, periodo.DataRepeticaoFim, periodo.HoraIni, periodo.HoraFim);

            _bus.SendCommand(command);
        }

        public void Criar(Periodo periodo)
        {
            CriarPeriodoCommand command = new CriarPeriodoCommand(periodo.Descricao, periodo.Segunda, periodo.Terca, periodo.Quarta,
                                                                           periodo.Quinta, periodo.Sexta, periodo.Sabado, periodo.Domingo, periodo.TodosOsDias, periodo.RepetirSempre,
                                                                           periodo.DataRepeticaoIni, periodo.DataRepeticaoFim, periodo.HoraIni, periodo.HoraFim);

            _bus.SendCommand(command);
        }

        public void Deletar(Guid id)
        {
            DeletarPeriodoCommand command = new DeletarPeriodoCommand(id);
            _bus.SendCommand(command);
        }

        public IEnumerable<Periodo> Pesquisar(Expression<Func<Periodo, bool>> predicate)
        {
            return _periodoRepository.Pesquisar(predicate);
        }

        public Periodo TrazerPorId(Guid id)
        {
            return _periodoRepository.TrazerPorId(id);
        }

        public IEnumerable<Periodo> TrazerTodos()
        {
            return _periodoRepository.TrazerTodos();
        }

        public IEnumerable<Periodo> TrazerTodosAtivos()
        {
            return _periodoRepository.TrazerTodosAtivos();
        }

        public IEnumerable<Periodo> TrazerTodosDeletados()
        {
            return _periodoRepository.TrazerTodosDeletados();
        }
    }
}
