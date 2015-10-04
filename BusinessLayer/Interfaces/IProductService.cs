using System.Collections.Generic;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int? categoryId);
        Product GetProductWithDetails(int productId);
        Product FindProduct(int productId);
    }
}