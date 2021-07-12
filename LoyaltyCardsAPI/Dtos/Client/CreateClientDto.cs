using LoyaltyCardsAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Dtos.Client
{
    public class CreateClientDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "The input doesn't match the email expression.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\+[0-9]{10,15}$", ErrorMessage = "The input doesn't match the phone number expression (international format, starts with a +).")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }
    }
}
