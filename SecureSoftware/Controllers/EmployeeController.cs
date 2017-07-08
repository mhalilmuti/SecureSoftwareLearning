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

    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/Employee")]
        public async Task<dynamic> GetEmployee(string Id)
        {
            return await EmployeeRepository.GetEmployeeUnSafe(Id);
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public async Task<int> CreateEmployee(Employees employee)
        {
            return await EmployeeRepository.CreateUnsafe(employee);
        }
    }
}

