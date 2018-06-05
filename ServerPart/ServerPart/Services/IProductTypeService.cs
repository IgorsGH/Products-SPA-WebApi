using System.Collections.Generic;
using System.Linq;
using ServerPart.Models;

namespace ServerPart.Services
{
    public interface IProductTypeService : IService<ProductTypeViewModel>
    {
        IEnumerable<ProductTypeQuantityViewModel> GetProductTypesAndQuantity();
    }
}
