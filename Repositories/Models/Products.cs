using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Models
{
    public class Products
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
        public Categories category { get; set; } //Category modeli oluşturulmalı
    }
}