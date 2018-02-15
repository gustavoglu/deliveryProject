using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
