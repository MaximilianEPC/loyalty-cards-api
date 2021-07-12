using LoyaltyCardsAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyCardsAPI.Repositories.Transactions
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddAsync(int cardNumber, int pointsEarned);
    }
}
