using LoyaltyCardsAPI.Entities;
using System.Collections.Generic;

namespace LoyaltyCardsAPI.Repositories.Clients
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
    }
}
