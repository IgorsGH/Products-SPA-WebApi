using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ServerPart.Domein;
using ServerPart.Models;

namespace ServerPart.Tools
{
    public class MyAutomapper
    {
        public void SetMyAutoMapper()
        {
            Mapper.Initialize(cfg => 
                {
                    cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember("ProductId", opt => opt.MapFrom(z => z.Id))
                    .ForMember("ProductTypeName", opt => opt.MapFrom(x => x.ProductType.ProductTypeName));
                    cfg.CreateMap<ProductViewModel, Product>()
                    .ForMember("Id", opt => opt.MapFrom(z => z.ProductId))
                    .ForMember("ProductTypeId", opt => opt.MapFrom(x => x.ProductTypeId));
                    cfg.CreateMap<ProductType, ProductTypeViewModel>();
                    cfg.CreateMap<ProductType, ProductTypeViewModel>().ReverseMap();
                    cfg.CreateMap<ProductType, ProductTypeQuantityViewModel>();
                    cfg.CreateMap<ProductViewModel, ProductType>().ForMember("Id", opt => opt.MapFrom(f => f.ProductTypeId)); // Возможно не стоит мапать ИД т.к. в нег очто то может прийти, а эта карта для добавления нового продута
                }
            );
        }
    }
}