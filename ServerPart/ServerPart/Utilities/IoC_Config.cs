using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Autofac;
using ServerPart.Services;
using ServerPart.DBData.Repositories;
using ServerPart.Domein;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace ServerPart.Utilities
{
    public class IoC_Config
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
            builder.RegisterType<ProductTypeService>().As<IProductTypeService>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IRepository<Product>>();
            builder.RegisterType<ProductTypeRepository>().As<IRepository<ProductType>>();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}