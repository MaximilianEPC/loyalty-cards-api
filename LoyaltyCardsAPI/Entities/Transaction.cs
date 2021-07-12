using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoyaltyCardsAPI.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int LoyaltyCardNumber { get; set; }
        [ForeignKey("LoyaltyCardNumber")]
        public virtual LoyaltyCard LoyaltyCard { get; set; }

        public int LoyaltyPointsEarned { get; set; }
        public DateTime TimeOfTransaction { get; set; }
    }
}
