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

namespace Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountService _accountService;
        public TransactionService(ITransactionRepository transactionRepository, IAccountService accountService)
        {
            _transactionRepository = transactionRepository;
            _accountService = accountService;
        }

        public async Task<string> CreateTransactionAsync(double value, Guid accountId, Guid sellerId)
        {
            if (!await _accountService.IsCardActiveAsync(accountId))
                return Util.CompraNegada();
            if (Util.CompraAprovada() != await _accountService.CheckLimitAsync(accountId, value))
                return Util.CompraNegada();
            var transactionDto = new TransactionDto
            {
                TransactionId = Guid.NewGuid(),
                AccountId = accountId,
                SellerId = sellerId,
                Value = value,
                TransactionStatus = Util.CompraAprovada(),
                Timestamp = DateTime.Now
            };
            if (Util.CompraAprovada() != await CheckHighFrequencyTransactionAsync(transactionDto))
                return Util.CompraComAltaFrequencia();
            if (Util.CompraAprovada() != await CheckDuplicatedTransactionAsync(transactionDto))
                return Util.CompraDuplicada();
            await _transactionRepository.CreateTransactionAsync(new Transaction()
            {
                TransactionId = transactionDto.TransactionId,
                AccountId = transactionDto.AccountId,
                SellerId = transactionDto.SellerId,
                Value = transactionDto.Value,
                TransactionStatus = transactionDto.TransactionStatus,
                Timestamp = transactionDto.Timestamp
            });
            return Util.CompraAprovada();
        }
        public async Task<IEnumerable<TransactionDto>> GetTransactionsAsync()
        {
            var transactions = await _transactionRepository.GetTransactionsAsync();
            var transactionsDto = transactions.Select(x => new TransactionDto()
            {
                TransactionId = x.TransactionId,
                AccountId = x.AccountId,
                SellerId = x.SellerId,
                Value = x.Value,
                TransactionStatus = x.TransactionStatus,
                Timestamp = x.Timestamp
            }).ToList();
            return transactionsDto;
        }

        public async Task<string> CheckDuplicatedTransactionAsync(TransactionDto transaction)
        {
            var transactions = await _transactionRepository.GetTransactionsAsync();
            if(transactions == null)
                return Util.CompraAprovada();
            var duplicada = transactions.LastOrDefault();
            var teste = (duplicada.AccountId == transaction.AccountId) && (duplicada.Value == transaction.Value) && (Math.Abs((duplicada.Timestamp - transaction.Timestamp).TotalMinutes) <= 2);
            if (teste)
                return Util.CompraDuplicada();
            return Util.CompraAprovada();
        }

        public async Task<string> CheckHighFrequencyTransactionAsync(TransactionDto transaction)
        {
            var transactions = await _transactionRepository.GetTransactionsAsync();
            var matchingTransactions = transactions
              .Where(x => x.AccountId == transaction.AccountId)
           .Where(x => Math.Abs((x.Timestamp - transaction.Timestamp).TotalMinutes) <= 2)
           .ToList();
            if (matchingTransactions.Count > 1)
                return Util.CompraComAltaFrequencia();
            return Util.CompraAprovada();
        }
    }
}
