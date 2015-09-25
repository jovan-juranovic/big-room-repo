using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("User")]
    public class User
    {
        public User()
        {
            this.ShippingDetails = new List<ShippingDetail>();
            this.CreditCards = new List<CreditCard>();
            this.ProductReviews = new List<ProductReview>();
            this.Carts = new List<Cart>();
        }

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<ShippingDetail> ShippingDetails { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
