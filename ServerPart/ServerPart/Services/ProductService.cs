using System.Collections.Generic;
using System.Linq;
using ServerPart.DBData.Repositories;
using ServerPart.Domein;
using ServerPart.Models;
using AutoMapper;

namespace ServerPart.Services
{

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductType> _productTypeRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }


        public void Add(ProductViewModel prodViewModel)
        {
            int prodTypeId = _productTypeRepository.Find(x => x.ProductTypeName.ToLower() == prodViewModel.ProductTypeName.ToLower()).Select(v => v.Id).FirstOrDefault();
            if (prodTypeId > 0)
            {
                prodViewModel.ProductTypeId = prodTypeId;
            }
            if (prodTypeId <= 0) //no such Product Type, we need to add new one
            {
                var newProdType = Mapper.Map<ProductViewModel, ProductType>(prodViewModel);
                _productTypeRepository.Create(newProdType);
                prodTypeId = _productTypeRepository.Find(x => x.ProductTypeName.ToLower() == prodViewModel.ProductTypeName.ToLower()).Select(v => v.Id).FirstOrDefault();
                prodViewModel.ProductTypeId = prodTypeId;
            }
            var product = Mapper.Map<ProductViewModel, Product>(prodViewModel);
            _productRepository.Create(product);
        }

        public ProductViewModel Get(int productId)
        {
            var product = _productRepository.Get(productId);
            var productVM = Mapper.Map<Product, ProductViewModel>(product);
            return productVM;
        }

        public IEnumerable<ProductViewModel> Get()
        {
            var allProducts = _productRepository.Get();
            var allProductsVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(allProducts);
            return allProductsVM;
        }

        public void Update(ProductViewModel prodViewModel)
        {
            var product = Mapper.Map<ProductViewModel, Product>(prodViewModel);
            int productTypeId = _productTypeRepository.Find(x => x.ProductTypeName.ToLower() == prodViewModel.ProductTypeName.ToLower()).Select(x => x.Id).FirstOrDefault();
            product.ProductTypeId = productTypeId;
            _productRepository.Update(product);
        }

        public void Delete(int productId)
        {
            _productRepository.Delete(productId);
        }

        public int IsExists(ProductViewModel prodViewModel)
        {
            var productModel = Mapper.Map<ProductViewModel, Product>(prodViewModel);
            int result = _productRepository.IsExists(productModel);
            return result;
        }

        public int IsExists(int id)
        {
            int result = _productRepository.IsExists(id);
            return result;
        }
    }
}