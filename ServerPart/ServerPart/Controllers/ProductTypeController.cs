using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServerPart.DBData;
using ServerPart.Domein;
using ServerPart.Models;
using ServerPart.Services;

namespace ServerPart.Controllers
{
    public class ProductTypeController : ApiController
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }


        //GET: api/ProductType
        public IEnumerable<ProductTypeQuantityViewModel> GetProductTypes()
        {
                var result = _productTypeService.GetProductTypesAndQuantity(); ;
                return result;
        }
    }
}