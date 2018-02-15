using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Context;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class AdicionalRepository : Repository<Adicional>, IAdicionalRepository
    {
        public AdicionalRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
