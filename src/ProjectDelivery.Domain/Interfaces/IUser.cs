using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectDelivery.Domain.Interfaces
{
    public interface IUser
    {
        IEnumerable<Claim> GetClaimsUser();
        string GetUserName();
        string GetUserId();
        bool IsAuthenticated();
    }
}
