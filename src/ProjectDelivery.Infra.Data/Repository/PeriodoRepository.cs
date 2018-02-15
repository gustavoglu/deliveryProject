using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Context;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class PeriodoRepository : Repository<Periodo>, IPeriodoRepository
    {
        public PeriodoRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
