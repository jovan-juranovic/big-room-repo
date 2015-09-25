using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("CartItem")]
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal ShippingPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public string Comment { get; set; }

        // Foreign keys
        public int CartId { get; set; }
        public int ProductId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
