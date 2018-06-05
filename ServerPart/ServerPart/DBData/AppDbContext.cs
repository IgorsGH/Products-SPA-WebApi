using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServerPart.Domein;
using System.Data.Entity;

namespace ServerPart.DBData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("SQLiteDBConStr")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}