using ProjectDelivery.Domain.Core.Commands;

namespace ProjectDelivery.Domain.Core.UoW
{
    public interface  IUnitOfWork
    {
        CommandResponse Commit();
    }
}
