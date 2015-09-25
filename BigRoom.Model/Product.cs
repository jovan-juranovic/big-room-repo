using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            this.ProductDetails = new List<ProductDetail>();
            this.ProductReviews = new List<ProductReview>();
            this.CartItems = new List<CartItem>();
        }

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? ShippingPrice { get; set; }

        [Required]
        public ProductStatus Status { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }

    public enum ProductStatus
    {
        None = 0,
        Active = 1,
        Inactive = 2
    }
}
