using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Validation
{
    public class MustBeGreaterThanCurrentDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;
            if(dt < DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "This date cannot be later than the current one.");
            }

            return ValidationResult.Success;
        }
    }
}
