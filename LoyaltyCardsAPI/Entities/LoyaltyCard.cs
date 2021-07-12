using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoyaltyCardsAPI.Entities
{
    public class LoyaltyCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }
        public DateTime IssuingDate { get; set; }
        public DateTime ValidUntil { get; set; }

        [ForeignKey("Client")]
        [JsonIgnore]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [JsonIgnore]
        public virtual List<Transaction> Transactions { get; set; }
    }
}
