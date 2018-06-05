using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerPart.Models
{
    public class ProductTypeQuantityViewModel
    {
        public int Id { get; set; }

        public string ProductTypeName { get; set; }

        public int ProductTypeQuantity { get; set; }
    }
}