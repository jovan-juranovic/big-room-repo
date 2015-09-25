using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("HelpfullReview")]
    public class HelpfullReview
    {
        public int Id { get; set; }

        // Foreign keys
        public int ProductReviewId { get; set; }

        public virtual ProductReview ProductReview { get; set; }
    }
}
