using ProjectDelivery.Domain.Validations.Periodos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Periodos
{
    public class AtualizarPeriodoCommand : PeriodoCommand
    {
        public AtualizarPeriodoCommand(Guid id,string descricao, bool segunda, bool terca, bool quarta, bool quinta, bool sexta, bool sabado,
                                        bool domingo, bool todosOsDias, bool repetirSempre, DateTime? dataRepeticaoIni, DateTime? dataRepeticaoFim,
                                        TimeSpan? horaIni, TimeSpan? horaFim)
        {
            Id = id;
            Descricao = descricao;
            Segunda = segunda;
            Terca = terca;
            Quarta = quarta;
            Quinta = quinta;
            Sexta = sexta;
            Sabado = sabado;
            Domingo = domingo;
            TodosOsDias = todosOsDias;
            RepetirSempre = repetirSempre;
            DataRepeticaoIni = dataRepeticaoIni;
            DataRepeticaoFim = dataRepeticaoFim;
            HoraIni = horaIni;
            HoraFim = horaFim;
        }

        public override bool IsValid()
        {
            return new AtualizarPeriodoValidation().Validate(this).IsValid;
        }
    }
}
