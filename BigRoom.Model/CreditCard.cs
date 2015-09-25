using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigRoom.Model
{
    [Table("CreditCard")]
    public class CreditCard
    {
        public int Id { get; set; }

        [Required]
        public long CardNumber { get; set; }

        [Required, MaxLength(50)]
        public string NameOnCard { get; set; }

        [Required]
        public DateTime Expiration { get; set; }

        // Foreign key
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
