using Repositories;
using Repositories.Models;
using SecureSoftware.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SecureSoftware.Controllers
{
    //[Authorize]
    public class ShoppingController : ApiController
    {
        [HttpGet]
        [Route("api/Shopping/Transaction/Get")]
        public async Task<dynamic> Get()
        {
            return await ShoppingRepository.Get();
        }

        [HttpGet]
        [Route("api/Shopping/Transaction/GetById")]
        public async Task<dynamic> GetById(string id)
        {
            return await ShoppingRepository.GetById(id);
        }

        [HttpGet]
        [Route("api/Shopping/Transaction/GetByCustomerId")]
        public async Task<dynamic> GetByCustomerId(string customerId)
        {
            return await ShoppingRepository.GetByCustomerId(customerId);
        }

        [HttpPost]
        [Route("api/Shopping/Transaction/Create")]
        [RequestModelValidation]
        public async Task<int> Create(Shopping shopping)
        {
            return await ShoppingRepository.Create(shopping);
        }

        /// <summary>
        /// Sql Injection Barındırır
        /// </summary>
        /// <param name="id">Id tek tırnak içinde gönderilmelidir.</param>
        [HttpGet]
        [Route("api/Shopping/Transaction/Delete")]
        [RequestModelValidation]
        public void Create(string id)
        {
            ShoppingRepository.Delete(id);
        }
    }
}
