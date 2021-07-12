using LoyaltyCardsAPI.Database;
using LoyaltyCardsAPI.Dtos.Transaction;
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

        public LoyaltyPointsBalance GetPointsBalance(int cardNumber)
        {
            LoyaltyPointsBalance result = _context.Transactions.Where(x => x.LoyaltyCardNumber == cardNumber).GroupBy(x => x.LoyaltyCardNumber).Select(x => new LoyaltyPointsBalance()
            {
                LoyaltyCardNumber = x.Key,
                TotalPoints = x.Sum(s => s.LoyaltyPointsEarned),
            }).SingleOrDefault<LoyaltyPointsBalance>();
            return result;
        }

        public IEnumerable<Transaction> GetAll()
        {
            //var transactions = _context.Transactions.Include(x => x.LoyaltyCard).OrderByDescending(x => x.TimeOfTransaction).ToList();
            var transactions = _context.Transactions.AsEnumerable().ToList();
            return transactions;
        }
    }
}
