using LoyaltyCardsAPI.Database;
using LoyaltyCardsAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Repositories.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Transaction> AddAsync(int cardNumber, int pointsEarned)
        {
            var loyaltyCard = await _context.LoyaltyCards.Include(x => x.Client).FirstOrDefaultAsync(x => x.Number == cardNumber);
            var transaction = new Transaction()
            {
                LoyaltyCardNumber = cardNumber,
                LoyaltyCard = loyaltyCard,
                LoyaltyPointsEarned = pointsEarned,
                TimeOfTransaction = DateTime.Now
            };

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
