using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BigRoom.BusinessLayer;
using BigRoom.Model;
using BigRoom.Service.Common;
using BigRoom.Service.Models.ProductVms;

namespace BigRoom.Service.Controllers
{
    public class ProductsController : BaseApiController
    {
        private ProductService productService = new ProductService();
        private ProductReviewService reviewService = new ProductReviewService();

        public IEnumerable<ProductVM> Get(int? categoryId = null)
        {
            return productService.GetProducts(categoryId)
                .Select(product => new ProductVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.GetValueOrDefault()
                }).ToList();
        }

        public ProductVM Get(int id)
        {
            Product product = productService.GetProductWithDetails(id);
            List<ProductReview> reviews = reviewService.GetReviewsByProduct(id).ToList();
            return new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.GetValueOrDefault(),
                AverigeRating = GetAvgRating(reviews),
                ProductDetails = GetProductDetails(product),
                ProductReviews = GetProductReviews(reviews)
            };
        }

        private static List<ProductReviewVM> GetProductReviews(IEnumerable<ProductReview> reviews)
        {
            return reviews.Select(review => new ProductReviewVM
            {
                Title = review.Title,
                Comment = review.Comment,
                PostingDate = review.PostingDate.ToLongDateString(),
                Rating = review.Rating.GetValueOrDefault(),
                UserEmail = review.User.Email
            }).ToList();
        }

        private static List<ProductDetailVM> GetProductDetails(Product product)
        {
            return product.ProductDetails.Select(pd => new ProductDetailVM
            {
                Name = pd.Name,
                Content = pd.Content
            }).ToList();
        }

        private static string GetAvgRating(IReadOnlyCollection<ProductReview> reviews)
        {
            decimal sum = reviews.Sum(review => review.Rating.GetValueOrDefault());
            decimal avg = sum/reviews.Count;
            return avg.ToString("F1");
        }

        // POST api/products
        public void Post([FromBody]string value)
        {
        }

        // PUT api/products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
        }
    }
}
