using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ServerPart.Domein;

namespace ServerPart.DBData.Repositories
{
    public class ProductTypeRepository : IRepository<ProductType>
    {
        private AppDbContext _context;

        public ProductTypeRepository()
        {
            _context = new AppDbContext();
        }


        public void Create(ProductType model)
        {
            _context.ProductTypes.Add(model);
            _context.SaveChanges();
        }

        public IEnumerable<ProductType> Find(Func<ProductType, bool> predicate)
        {
            var result = _context.ProductTypes.Where(predicate).AsEnumerable();
            return result;
        }

        public ProductType Get(int id)
        {
            var result = _context.ProductTypes.Where(x => x.Id == id).SingleOrDefault();
            return result;
        }

        public IEnumerable<ProductType> Get()
        {
            var result = _context.ProductTypes.AsEnumerable();
            return result;
        }

        public void Update(ProductType model)
        {
            _context.ProductTypes.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var temp = _context.ProductTypes.Where(x => x.Id == id).SingleOrDefault();
            if (temp != null)
            {
                _context.ProductTypes.Remove(temp);
                _context.SaveChanges();
            }
        }

        public int IsExists(ProductType model)
        {
            var prodType = _context.ProductTypes.Where(x => x.Id == model.Id && x.ProductTypeName.ToLower() == x.ProductTypeName.ToLower()).SingleOrDefault();
            if (prodType != null)
            {
                return prodType.Id;
            }
            else
                return -1; // Doesn't exists
        }

        public int IsExists(int id)
        {
            var product = _context.ProductTypes.Where(x => x.Id == id).SingleOrDefault();
            if (product != null)
            {
                return product.Id;
            }
            else
                return -1; // Doesn't exists
        }
    }
}