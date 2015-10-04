using System.Collections.Generic;
using System.Linq;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.DataAccessLayer.UnitOfWork;
using BigRoom.Model;

namespace BigRoom.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetProducts(int? categoryId)
        {
            using (var uow = new UnitOfWork())
            {
                if (categoryId.HasValue)
                {
                    return uow.ProductRepository.GetAll(product => product.CategoryId == categoryId);
                }

                return uow.ProductRepository.GetAll();
            }
        }

        public Product GetProductWithDetails(int productId)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.ProductRepository.GetAll(
                    filter: product => product.Id == productId,
                    orderBy: null,
                    includeProperties: "ProductDetails"
                    ).SingleOrDefault();
            }
        }

        public Product FindProduct(int productId)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.ProductRepository.Find(productId);
            }
        }
    }
}
