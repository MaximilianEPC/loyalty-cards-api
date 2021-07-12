using System;
using System.Collections.Generic;
using System.Linq;
using LoyaltyCardsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyCardsAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
