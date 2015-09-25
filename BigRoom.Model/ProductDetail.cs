using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("ProductDetail")]
    public class ProductDetail
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        // Foreign key
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
