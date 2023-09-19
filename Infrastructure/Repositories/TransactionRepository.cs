using Application.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private WebApiContext _context { get; set; }

        public TransactionRepository(WebApiContext context)
        {
            _context = context;
        }
        public async Task<string> CreateTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChanges();
            return transaction.TransactionStatus;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            var result = await _context.Transactions.ToListAsync();
            return result;
        }
    }
}
