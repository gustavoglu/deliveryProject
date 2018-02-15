using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class ProdutoTipoRepository : Repository<ProdutoTipo>, IProdutoTipoRepository
    {
        public ProdutoTipoRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
