using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SecureSoftware.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/Category")]
        public async Task<List<Categories>> Get()
        {
            return await CategoryRepository.Get();
        }

        [HttpGet]
        [Route("api/Category/{id}")]
        public async Task<Categories> Get(int id)
        {
            return CategoryRepository.Get().Result.ToList().Find(f => f.id == id);
        }
    }
}
