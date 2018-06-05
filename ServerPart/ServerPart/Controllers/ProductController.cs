using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ServerPart.Domein;
using ServerPart.Models;
using ServerPart.Services;

namespace ServerPart.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;

        public ProductController(IProductService prodServ, IProductTypeService prodTypeServ)
        {
            _productService = prodServ;
            _productTypeService = prodTypeServ;
        }


        // GET: api/Product
        public IEnumerable<ProductViewModel> GetProducts()
        {
            var result = _productService.Get();//.AsQueryable();
            return result;
        }

        // PUT: api/Product/5
        //[HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, [FromBody] ProductViewModel productModel)
        {
            if (id != productModel.ProductId)
            {
                return BadRequest();
            }
            _productService.Update(productModel);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Product
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(ProductViewModel productModel)
        {
            _productService.Add(productModel);
            var tempProd = _productService.Get().Where(x => x.ProductName == productModel.ProductName && x.ProductTypeName == productModel.ProductTypeName).FirstOrDefault();
            return CreatedAtRoute("DefaultApi", new { id = tempProd.ProductId }, tempProd);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            int isProductExists = _productService.IsExists(id);
            if (isProductExists > 0)
            {
                var deletedProduct = _productService.Get(id);
                _productService.Delete(id);
                return Ok(deletedProduct);
            }
            else
                return NotFound();
        }
    }
}