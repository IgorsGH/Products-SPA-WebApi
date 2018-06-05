using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServerPart.Domein;

namespace ServerPart.DBData.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductRepository()
        {
            _context = new AppDbContext();
        }


        public void Create(Product model)
        {
            _context.Products.Add(model);
            _context.SaveChanges();
        }

        public Product Get(int id)
        {
            var result = _context.Products.Include("ProductType").Where(x => x.Id == id).SingleOrDefault();
            return result;
        }

        public IEnumerable<Product> Get()
        {
            var result = _context.Products.Include("ProductType").AsEnumerable();
            return result;
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            var result = _context.Products.Where(predicate).ToList();
            return result;
        }

        public void Update(Product product)
        {
            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var temp = _context.Products.Where(x => x.Id == id).SingleOrDefault();
            if (temp != null)
            {
                _context.Products.Remove(temp);
                _context.SaveChanges();
            }
        }

        public int IsExists(Product model)
        {
            var product = _context.Products.Where(x => x.Id == model.Id && x.ProductName.ToLower() == model.ProductName.ToLower()).SingleOrDefault();
            if (product != null)
            {
                return product.Id;
            }
            else
                return -1; // Doesn't exists
        }

        public int IsExists(int id)
        {
            var product = _context.Products.Where(x => x.Id == id).SingleOrDefault();
            if (product != null)
            {
                return product.Id;
            }
            else
                return -1; // Doesn't exists
        }
    }
}