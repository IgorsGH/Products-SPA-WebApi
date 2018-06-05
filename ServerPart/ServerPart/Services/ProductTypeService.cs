using System.Collections.Generic;
using System.Linq;
using ServerPart.DBData.Repositories;
using ServerPart.Domein;
using ServerPart.Models;
using AutoMapper;

namespace ServerPart.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<Product> _productRepository;

        public ProductTypeService(IRepository<Product> productRepository, IRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public void Add(ProductTypeViewModel prodTViewModel)
        {
            var prodType = Mapper.Map<ProductTypeViewModel, ProductType>(prodTViewModel);
            _productTypeRepository.Create(prodType);
        }

        public ProductTypeViewModel Get(int id)
        {
            var productType = Mapper.Map<ProductType, ProductTypeViewModel>(_productTypeRepository.Get(id));
            return productType;
        }

        public IEnumerable<ProductTypeViewModel> Get()
        {
            var productTypes = Mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeViewModel>>(_productTypeRepository.Get());
            return productTypes;
        }

        public IEnumerable<ProductTypeQuantityViewModel> GetProductTypesAndQuantity()
        {
            var allProductTypes = _productTypeRepository.Get();
            var allProductTypesQuantityViewModels = Mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeQuantityViewModel>>(allProductTypes);
            var allProducts = _productRepository.Get();

            foreach (ProductTypeQuantityViewModel prodTQVM in allProductTypesQuantityViewModels)
            {
                foreach (Product prod in allProducts)
                {
                    if (prodTQVM.Id == prod.ProductTypeId)
                    {
                        prodTQVM.ProductTypeQuantity++;
                    }
                }
            }
            return allProductTypesQuantityViewModels;
        }

        public void Update(ProductTypeViewModel prodTViewModel)
        {
            var prodType = Mapper.Map<ProductTypeViewModel, ProductType>(prodTViewModel); 

            _productTypeRepository.Update(prodType);
        }

        public void Delete(int id)
        {
            _productTypeRepository.Delete(id);
        }

        public int IsExists(ProductTypeViewModel prodTViewModel)
        {
            var prodType = Mapper.Map<ProductTypeViewModel, ProductType>(prodTViewModel);

            int result = _productTypeRepository.IsExists(prodType);
            return result;
        }

        public int IsExists(int id)
        {
            int result = _productTypeRepository.IsExists(id);
            return result;
        }
    }
}
