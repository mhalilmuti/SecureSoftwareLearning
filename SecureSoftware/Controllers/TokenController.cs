using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecureSoftware.Attributes;
using System.Threading.Tasks;
using System.Web.Http;
using Repositories;
using Repositories.Models;

namespace SecureSoftware.Controllers
{
   
    [Authorizee]
    public class TokenController : ApiController
    {
        [HttpGet]
        [Route("api/Token")]
        public async Task<dynamic> Get()
        {
            return true;
        }
    }
}
