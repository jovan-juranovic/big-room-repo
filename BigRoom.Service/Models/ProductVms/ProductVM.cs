using System.Collections.Generic;

namespace BigRoom.Service.Models.ProductVms
{
    public class ProductVM
    {
        public ProductVM()
        {
            this.ProductDetails = new List<ProductDetailVM>();
            this.ProductReviews = new List<ProductReviewVM>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AverigeRating { get; set; }

        public List<ProductDetailVM> ProductDetails { get; set; }
        public List<ProductReviewVM> ProductReviews { get; set; }
    }
}