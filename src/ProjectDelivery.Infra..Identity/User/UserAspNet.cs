using Microsoft.AspNetCore.Http;
using ProjectDelivery.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectDelivery.Infra.Identity.User
{
    public class UserAspNet : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public UserAspNet(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public IEnumerable<Claim> GetClaimsUser()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public string GetUserId()
        {
            return _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "IdUser").Value;
        }

        public string GetUserName()
        {
            return _accessor.HttpContext.User.Identity.Name;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
