using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProjectDelivery.Domain.Core.Entitys
{
    public class Entity
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        [BsonId]
        public Guid Id { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? CriadoEm { get; set; }
        public string AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string DeletadoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public bool Deletado { get; set; } = false;
    }
}
