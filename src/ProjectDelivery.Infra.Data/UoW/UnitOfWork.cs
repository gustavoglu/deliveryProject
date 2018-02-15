using ProjectDelivery.Domain.Core.Commands;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoDbContext _context;

        public UnitOfWork(IMongoDbContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            return new CommandResponse(_context.SaveChanges().Success);
        }
    }
}
