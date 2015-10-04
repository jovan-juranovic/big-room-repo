using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BigRoom.BusinessLayer.Interfaces;
using BigRoom.BusinessLayer.Services;
using BigRoom.BusinessLayer.Util;
using BigRoom.Model;
using BigRoom.Service.Common;
using BigRoom.Service.Models.ProductVms;

namespace BigRoom.Service.Controllers.API
{
    public class ProductsController : BaseApiController
    {
        #region Fields

        private readonly IProductService productService;
        private readonly IProductReviewService reviewService;

        #endregion

        #region Ctor's

        public ProductsController()
        {
            this.productService = new ProductService();
            this.reviewService = new ProductReviewService();
        }

        public ProductsController(IProductService productService, IProductReviewService reviewService)
        {
            this.productService = productService;
            this.reviewService = reviewService;
        }

        #endregion

        #region API

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
            Product product = GetProduct(id);
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

        #endregion

        #region Helpers

        private Product GetProduct(int id)
        {
            Product product = productService.GetProductWithDetails(id);
            if (product.IsNull())
            {
                this.ReportError("No such product, please check again.");
            }

            return product;
        }

        private static List<ProductReviewVM> GetProductReviews(IEnumerable<ProductReview> reviews)
        {
            return reviews.Select(review => new ProductReviewVM
            {
                Title = review.Title,
                Comment = review.Comment,
                PostingDate = review.PostingDate.Date.ToString("g"),
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
            decimal avg = sum / reviews.Count;
            return avg.ToString("F1");
        }

        #endregion
    }
}
