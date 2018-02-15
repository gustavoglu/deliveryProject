using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Context;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class PagamentoTipoRepository : Repository<PagamentoTipo>, IPagamentoTipoRepository
    {
        public PagamentoTipoRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
