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
    public class AccountRepository : IAccountRepository
    {
        private WebApiContext _context { get; set; }

        public AccountRepository(WebApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            var result = await _context.Accounts.ToListAsync();
            return result;
        }
        public async Task<Account>GetAccountByIdAsync(Guid id)
        {
            var result =  await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);
            return result;
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
             await _context.Accounts.AddAsync(account);
             _context.SaveChanges();
            var result = await GetAccountByIdAsync(account.AccountId);
            return result;
        }

        public async Task UpdateCardStatusAsync(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }
        
    }
}
