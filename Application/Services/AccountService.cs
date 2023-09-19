using Application.Dto;
using Application.Entities;
using Application.Helper;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        double MIN_LIMIT = 500.00;
        public AccountService(IAccountRepository accountRepository){
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsAsync()
        {
            var accounts = await _accountRepository.GetAccountsAsync();
            var accountsDto = accounts.Select(x => new AccountDto()
            {
                AccountId = x.AccountId,
                Name = x.Name,
                AvailableLimit = x.AvailableLimit,
                ActiveCard = x.ActiveCard,
                Transactions = x.Transactions != null ?
                x.Transactions.Select(y => new TransactionDto()
                {
                    TransactionId = y.TransactionId,
                    AccountId = y.AccountId,
                    SellerId = y.SellerId,
                    Value = y.Value,
                    TransactionStatus = y.TransactionStatus,
                    Timestamp = y.Timestamp,
                }).ToList() : new List<TransactionDto>()

            }).ToList();
            return accountsDto;
        }
        public async Task<AccountDto> GetAccountByIdAsync(Guid id)
        {
            var account = await _accountRepository.GetAccountByIdAsync(id);

            return new AccountDto()
            {
                AccountId = account.AccountId,
                Name = account.Name,
                AvailableLimit = account.AvailableLimit,
                ActiveCard = account.ActiveCard,
                Transactions = account.Transactions != null ?  
                account.Transactions.Select(x => new TransactionDto()
                {
                    TransactionId = x.TransactionId,
                    AccountId = x.AccountId,
                    SellerId = x.SellerId,
                    Value = x.Value,
                    TransactionStatus = x.TransactionStatus,
                    Timestamp = x.Timestamp,
                }).ToList() : new List<TransactionDto>()
            };
        }

        public async Task<AccountDto> CreateAccountAsync(CreateAccountDto nameAccount)
        {
            var account = await _accountRepository.CreateAccountAsync(new Account()
            {
                AccountId = new Guid(),
                Name = nameAccount.Name,
                AvailableLimit = MIN_LIMIT,
                ActiveCard = true,
                Transactions = new List<Transaction>()
            });
            return new AccountDto()
            {
                AccountId = account.AccountId,
                Name = account.Name,
                AvailableLimit = account.AvailableLimit,
                ActiveCard = account.ActiveCard,
                Transactions = account.Transactions != null ?
                account.Transactions.Select(x => new TransactionDto()
                {
                    TransactionId = x.TransactionId,
                    AccountId = x.AccountId,
                    SellerId = x.SellerId,
                    Value = x.Value,
                    TransactionStatus = x.TransactionStatus,
                    Timestamp = x.Timestamp,
                }).ToList() : new List<TransactionDto>()
            };
        }
        public async Task<string> CheckLimitAsync(Guid id, double transactionValue)
        {
            var account = await GetAccountByIdAsync(id);
            if(account.AvailableLimit < transactionValue)
                return Util.CompraNegada();
            return Util.CompraAprovada();
        }
        public async Task<string> CheckNameAsync(Guid id)
        {
            var account = await GetAccountByIdAsync(id);
            return account.Name;
        }
        public async Task<bool> IsCardActiveAsync(Guid id)
        {
            var account = await GetAccountByIdAsync(id);
            return account.ActiveCard;
        }
        public async Task UpdateCardStatusAsync(Guid id)
        {
            var account = await GetAccountByIdAsync(id);
            account.ActiveCard = !account.ActiveCard;
            await _accountRepository.UpdateCardStatusAsync(new Account()
            {
                AccountId = account.AccountId,
                Name = account.Name,
                AvailableLimit = account.AvailableLimit,
                ActiveCard = account.ActiveCard,
                Transactions = account.Transactions != null ?
                account.Transactions.Select(x => new Transaction()
                {
                    TransactionId = x.TransactionId,
                    AccountId = x.AccountId,
                    SellerId = x.SellerId,
                    Value = x.Value,
                    TransactionStatus = x.TransactionStatus,
                    Timestamp = x.Timestamp,
                }).ToList() : new List<Transaction>()
            });
        }
        public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync(Guid id)
        {
            var account = await _accountRepository.GetAccountByIdAsync(id);

            var transactionList = account.Transactions != null ?
                account.Transactions.Select(x => new TransactionDto()
                {
                    TransactionId = x.TransactionId,
                    AccountId = x.AccountId,
                    SellerId = x.SellerId,
                    Value = x.Value,
                    TransactionStatus = x.TransactionStatus,
                    Timestamp = x.Timestamp,
                }).ToList() : new List<TransactionDto>();
            return transactionList;
        }
    }
}
