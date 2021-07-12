using LoyaltyCardsAPI.Entities;
using System.Collections.Generic;

namespace LoyaltyCardsAPI.Repositories.LoyaltyCards
{
    public interface ILoyaltyCardRepository
    {
        IEnumerable<LoyaltyCard> GetAll();
    }
}
