using ProjectDelivery.Domain.Core.Entitys;
using System;

namespace ProjectDelivery.Domain.Entitys
{
    public class Periodo : Entity
    {
        public Periodo(string descricao,bool segunda = false, bool terca = false, bool quarta = false, bool quinta = false, bool sexta = false, bool sabado = false, bool domingo = false, bool todosOsDias = false, 
                        DateTime? dataRepeticaoIni = null, DateTime? dataRepeticaoFim = null, TimeSpan? horaIni = null, TimeSpan? horaFim = null,bool repetirSempre = false)
        {
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
            Descricao = descricao;
        }

        public string Descricao { get; private set; }
        public bool Segunda { get; private set; } = false;
        public bool Terca { get; private set; } = false;
        public bool Quarta { get; private set; } = false;
        public bool Quinta { get; private set; } = false;
        public bool Sexta { get; private set; } = false;
        public bool Sabado { get; private set; } = false;
        public bool Domingo { get; private set; } = false;
        public bool TodosOsDias { get; private set; } = false;
        public bool RepetirSempre { get; private set; } = false;
        public DateTime? DataRepeticaoIni { get; private set; }
        public DateTime? DataRepeticaoFim { get; private set; }
        public TimeSpan? HoraIni { get; private set; }
        public TimeSpan? HoraFim { get; private set; }
    }

    public static class PeriodoFactory
    {
        public static Periodo PeriodoFull(Guid id,string descricao, bool segunda = false, bool terca = false, bool quarta = false, bool quinta = false, bool sexta = false, bool sabado = false, bool domingo = false, bool todosOsDias = false,
                        DateTime? dataRepeticaoIni = null, DateTime? dataRepeticaoFim = null, TimeSpan? horaIni = null, TimeSpan? horaFim = null, bool repetirSempre = false)
        {
            return new Periodo(descricao, segunda, terca, quarta, quinta, sexta, sabado, domingo, todosOsDias, 
                                dataRepeticaoIni, dataRepeticaoFim, horaIni, horaFim, repetirSempre) { Id = id };
        }
    }
}
