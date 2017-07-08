using Repositories;
using Repositories.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SecureSoftware.Controllers
{

    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/Product")]
        public async Task<List<Products>> Get()
        {
            return await ProductRepository.Get();
        }

        [HttpGet]
        [Route("api/Product/{id}")]
        public async Task<List<Products>> Get(int id)
        {
            return ProductRepository.Get().Result.ToList().FindAll(f => f.category.id == id);
        }
    }
}
