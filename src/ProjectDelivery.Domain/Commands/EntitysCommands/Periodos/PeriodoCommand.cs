using ProjectDelivery.Domain.Core.Commands;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Periodos
{
    public abstract class PeriodoCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Segunda { get; set; } = false;
        public bool Terca { get; set; } = false;
        public bool Quarta { get; set; } = false;
        public bool Quinta { get; set; } = false;
        public bool Sexta { get; set; } = false;
        public bool Sabado { get; set; } = false;
        public bool Domingo { get; set; } = false;
        public bool TodosOsDias { get; set; } = false;
        public bool RepetirSempre { get; set; } = false;
        public DateTime? DataRepeticaoIni { get; set; }
        public DateTime? DataRepeticaoFim { get; set; }
        public TimeSpan? HoraIni { get; set; }
        public TimeSpan? HoraFim { get; set; }
    }
}
