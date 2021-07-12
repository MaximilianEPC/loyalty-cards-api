using LoyaltyCardsAPI.Dtos.LoyaltyCard;
using LoyaltyCardsAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Repositories.LoyaltyCards
{
    public interface ILoyaltyCardRepository
    {
        IEnumerable<LoyaltyCard> GetAll();

        Task<LoyaltyCard> AddAsync(CreateLoyaltyCardDto loyaltyCardDto);
    }
}
