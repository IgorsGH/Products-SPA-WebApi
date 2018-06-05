using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServerPart.Domein
{
    public class Product : IBaseItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
    }
}