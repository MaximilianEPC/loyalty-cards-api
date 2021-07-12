using LoyaltyCardsAPI.Dtos.Client;
using LoyaltyCardsAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Repositories.Clients
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();

        Task<Client> AddAsync(CreateClientDto clientDto);
    }
}
