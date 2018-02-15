using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDelivery.Domain.Interfaces;
using ProjectDelivery.Infra.Data.Interfaces;

namespace ProjectDelivery.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IUser _user;
        IMongoDbContext _context;
        public ValuesController(IUser user, IMongoDbContext context)
        {
            _user = user;
            _context = context;
        }
        // GET api/values
        //[Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var conn = _context.GetConnection();
            return new string[] { "value1", "value2", _user.IsAuthenticated().ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
