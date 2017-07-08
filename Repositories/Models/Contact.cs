using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Models
{
    public class Contact
    {
        public int countryId { get; set; }
        public int cityId { get; set; }
        public int districtId { get; set; }
        public string address { get; set; }
        public string phone { get; set; } 
        public string description { get; set; } //olmamalı
    }
}