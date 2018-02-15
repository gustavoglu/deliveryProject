using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class IngredienteOpc_OpcaoRepository : Repository<IngredienteOpc_Opcao>, IIngredienteOpc_OpcaoRepository
    {
        public IngredienteOpc_OpcaoRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
