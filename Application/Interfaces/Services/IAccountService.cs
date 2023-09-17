using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task <IEnumerable<AccountDto>> GetAccountsAsync();
        Task<AccountDto> GetAccountByIdAsync(Guid id);
        Task<AccountDto> CreateAccountAsync(CreateAccountDto account);
        Task<string> CheckLimitAsync(Guid id, double transactionValue);
        Task<string> CheckNameAsync(Guid id);
        Task<bool> IsCardActiveAsync(Guid id);
        Task UpdateCardStatusAsync(Guid id);
        Task<IEnumerable<TransactionDto>> GettransactionsAsync(Guid id);
    }
}
