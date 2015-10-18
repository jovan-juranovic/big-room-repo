using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("ProductReview")]
    public class ProductReview
    {
        public int Id { get; set; }

        [Required]
        public DateTime PostingDate { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Comment { get; set; }

        public int? Rating { get; set; }

        [Required]
        public bool Approved { get; set; }

        // Foreign Keys
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
