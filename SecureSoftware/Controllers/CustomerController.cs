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
   
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("api/Customer/Get")]
        public async Task<dynamic> Get(string id)
        {
            return await CustomerRepository.GetUnsafe(id);
        }

        [HttpPost]
        [Route("api/Customer/Create")]
        public async Task<int> Create(Customers customer)
        {
            return await CustomerRepository.CreateUnsafe(customer);
        }

        [HttpPost]
        [Route("api/Customer/Update")]
        public async Task<int> Update(CustomerUpdateRequestModel customer)
        {
            return await CustomerRepository.UpdateUnsafe(customer);
        }


    }
}
