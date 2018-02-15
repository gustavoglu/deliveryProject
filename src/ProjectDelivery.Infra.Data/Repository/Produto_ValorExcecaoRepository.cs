using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.Repository
{
    public class Produto_ValorExcecaoRepository : Repository<Produto_ValorExcecao>, IProduto_ValorExcecaoRepository
    {
        public Produto_ValorExcecaoRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
