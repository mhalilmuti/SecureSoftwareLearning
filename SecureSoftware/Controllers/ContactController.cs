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
    //Authentication iptal ettim bu ksım sign up tan çağırılacağı için bu modüller anonim olarak erişilebilir olmalı
    public class ContactController : ApiController
    {
        [HttpGet]
        [Route("api/Contact/GetCountries")]
        public async Task<List<Countries>> GetCountries()
        {
            return await ContactRepository.GetCountries();
        }

        [HttpGet]
        [Route("api/Contact/GetCities")]
        public async Task<List<Cities>> GetCities(int countryId)
        {
            return await ContactRepository.GetCities(countryId);
        }

        [HttpGet]
        [Route("api/Contact/GetDistricts")]
        public async Task<List<Districts>> GetDistricts(int cityId)
        {
            return await ContactRepository.GetDistricts(cityId);
        }
    }
}
