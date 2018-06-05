using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServerPart.Domein
{
    public class ProductType : IBaseItem
    {
        public int Id { get; set; }

        [Required]
        public string ProductTypeName { get; set; }
    }
}