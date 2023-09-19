using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<string> CreateTransactionAsync( double value, Guid accountId, Guid sellerId);
        Task<IEnumerable<TransactionDto>> GetTransactionsAsync();
        Task<string> CheckDuplicatedTransactionAsync(TransactionDto transaction);
        Task<string> CheckHighFrequencyTransactionAsync(TransactionDto transaction);
    }
}
