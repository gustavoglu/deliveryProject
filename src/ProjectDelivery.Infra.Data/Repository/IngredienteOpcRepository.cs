using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Context;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class IngredienteOpcRepository : Repository<IngredienteOpc>, IIngredienteOpcRepository
    {
        public IngredienteOpcRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
