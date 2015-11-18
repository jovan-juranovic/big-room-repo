using System.Collections.Generic;
using System.Linq;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.Model;
using BigRoom.Service.Common;
using BigRoom.Service.Models.ProductVms;

namespace BigRoom.Service.Controllers.API
{
    public class IndexController : BaseApiController
    {
        private readonly IProductService productService;

        public IndexController()
        {
            this.productService = new ProductService();
        }

        public IEnumerable<ProductVM> Get()
        {
            return this.productService.GetProducts(null)
                .OrderBy(p => p.ProductReviews.Count)
                .Take(5).Select(product => new ProductVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price.Value,
                    Description = product.Description,
                    ReviewCount = product.ProductReviews.Count,
                    AverigeRating = GetAvgRating(product.ProductReviews.ToList())
                }).ToList();
        }

        private static string GetAvgRating(IReadOnlyCollection<ProductReview> reviews)
        {
            decimal sum = reviews.Sum(review => review.Rating.GetValueOrDefault());
            decimal avg = sum / reviews.Count;
            return avg.ToString("F1");
        }
    }
}
