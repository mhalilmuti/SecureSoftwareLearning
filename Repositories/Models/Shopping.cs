using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repositories.Models
{
    public class Shopping
    {
        [Required]
        public string customerId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public string totalAmount { get; set; }
    }
}