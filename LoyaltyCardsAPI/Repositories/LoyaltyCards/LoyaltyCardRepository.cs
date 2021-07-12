using LoyaltyCardsAPI.Database;
using LoyaltyCardsAPI.Dtos.LoyaltyCard;
using LoyaltyCardsAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Repositories.LoyaltyCards
{
    public class LoyaltyCardRepository : ILoyaltyCardRepository
    {
        private readonly ApplicationDbContext _context;

        public LoyaltyCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<LoyaltyCard> GetAll()
        {
            var loyaltyCards = _context.LoyaltyCards.Include(x => x.Client);
            return loyaltyCards;
        }

        public async Task<LoyaltyCard> AddAsync(CreateLoyaltyCardDto loyaltyCardDto)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == loyaltyCardDto.ClientId);
            var loyaltyCard = new LoyaltyCard()
            {
                IssuingDate = DateTime.Now,
                ValidUntil = loyaltyCardDto.ValidUntil,
                ClientId = loyaltyCardDto.ClientId,
                Client = client
            };

            await _context.LoyaltyCards.AddAsync(loyaltyCard);
            await _context.SaveChangesAsync();
            return loyaltyCard;
        }
    }
}
