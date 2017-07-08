using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class CustomerUpdateRequestModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
    }
}
