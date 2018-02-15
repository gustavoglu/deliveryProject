using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class TamanhoRepository : Repository<Tamanho>, ITamanhoRepository
    {
        public TamanhoRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
