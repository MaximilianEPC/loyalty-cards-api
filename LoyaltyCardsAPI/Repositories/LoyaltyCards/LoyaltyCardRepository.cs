using LoyaltyCardsAPI.Database;
using LoyaltyCardsAPI.Entities;
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
            return _context.LoyaltyCards.AsEnumerable();
        }
    }
}
