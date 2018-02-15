using ProjectDelivery.Domain.Validations.Periodos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Periodos
{
    public class CriarPeriodoCommand : PeriodoCommand
    {
        public CriarPeriodoCommand(string descricao, bool segunda, bool terca, bool quarta, bool quinta, bool sexta, bool sabado, bool domingo, 
                                    bool todosOsDias, bool repetirSempre, DateTime? dataRepeticaoIni, DateTime? dataRepeticaoFim, 
                                    TimeSpan? horaIni, TimeSpan? horaFim)
        {
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
            return new CriarPeriodoValidation().Validate(this).IsValid;
        }
    }
}
