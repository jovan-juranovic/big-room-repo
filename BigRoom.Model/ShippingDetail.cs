using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("ShippingDetail")]
    public class ShippingDetail
    {
        [Key, ForeignKey("Cart"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        public string Region { get; set; }

        [Required, MaxLength(20)]
        public string ZipCode { get; set; }

        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }

        // Foreign keys
        public int CountryId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Country Country { get; set; }
    }
}
