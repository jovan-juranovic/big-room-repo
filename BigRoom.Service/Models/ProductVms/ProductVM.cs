using System.Collections.Generic;
using BigRoom.Model;

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
        public decimal ShippingPrice { get; set; }
        public string AverigeRating { get; set; }
        public string Status { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }

        public List<ProductDetailVM> ProductDetails { get; set; }
        public List<ProductReviewVM> ProductReviews { get; set; }
    }
}