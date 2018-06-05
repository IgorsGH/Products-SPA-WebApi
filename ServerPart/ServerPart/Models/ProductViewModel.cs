using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServerPart.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }
    }
}