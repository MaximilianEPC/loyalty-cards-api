using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Dtos.Transaction
{
    public class LoyaltyPointsBalance
    {
        public int LoyaltyCardNumber { get; set; }
        public int TotalPoints { get; set; }
    }
}
