using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("Cart")]
    public class Cart
    {
        public Cart()
        {
            this.CartItems = new List<CartItem>();
        }

        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? ShippingTotal { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Comment { get; set; }
        public Guid OrderNumber { get; set; }

        [Required]
        public CartStatus Status { get; set; }

        // Foreign key
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ShippingDetail ShippingDetail { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }

    public enum CartStatus
    {
        None = 0,
        Open = 1,
        Cancelled = 2,
        Rejected = 3,
        Closed = 4
    }
}
