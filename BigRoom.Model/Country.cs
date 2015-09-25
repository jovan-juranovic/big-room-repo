using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("Country")]
    public class Country
    {
        public Country()
        {
            this.ShippingDetails = new List<ShippingDetail>();
        }

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string IsoCountryCode { get; set; }

        public virtual ICollection<ShippingDetail> ShippingDetails { get; set; }
    }
}
