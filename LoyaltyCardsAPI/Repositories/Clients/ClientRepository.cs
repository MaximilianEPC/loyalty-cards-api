using LoyaltyCardsAPI.Database;
using LoyaltyCardsAPI.Dtos.Client;
using LoyaltyCardsAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Repositories.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.AsEnumerable();
        }

        public async Task<Client> AddAsync(CreateClientDto clientDto)
        {
            var client = new Client()
            {
                Name = clientDto.Name,
                Surname = clientDto.Surname,
                Email = clientDto.Email,
                PhoneNumber = clientDto.PhoneNumber,
                Gender = clientDto.Gender,
                RegistrationDate = DateTime.Now
            };

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
