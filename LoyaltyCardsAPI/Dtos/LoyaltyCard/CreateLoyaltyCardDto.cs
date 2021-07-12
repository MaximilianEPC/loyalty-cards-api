using LoyaltyCardsAPI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Dtos.LoyaltyCard
{
    public class CreateLoyaltyCardDto
    {
        [Required(ErrorMessage = "Client ID is required.")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Expiration date is required.")]
        [MustBeGreaterThanCurrentDate(ErrorMessage = "Expiration date must be later than today.")]
        public DateTime ValidUntil { get; set; }
    }
}
