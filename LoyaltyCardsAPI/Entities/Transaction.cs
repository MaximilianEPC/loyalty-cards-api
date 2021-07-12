using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoyaltyCardsAPI.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("LoyaltyCard")]
        public int LoyaltyCardNumber { get; set; }
        [JsonIgnore]
        public virtual LoyaltyCard LoyaltyCard { get; set; }

        public int LoyaltyPointsEarned { get; set; }
        public DateTime TimeOfTransaction { get; set; }
    }
}
