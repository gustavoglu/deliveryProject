using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
