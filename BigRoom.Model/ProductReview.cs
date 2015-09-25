using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("ProductReview")]
    public class ProductReview
    {
        public ProductReview()
        {
            this.HelpfullReviews = new List<HelpfullReview>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime PostingDate { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Comment { get; set; }

        public int? Grade { get; set; }

        // Foreign Keys
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<HelpfullReview> HelpfullReviews { get; set; }
    }
}
