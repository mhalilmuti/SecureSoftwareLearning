using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Models
{
    public class Cities
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int countryId { get; set; }
    }
}