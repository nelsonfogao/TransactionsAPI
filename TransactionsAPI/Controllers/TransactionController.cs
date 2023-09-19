using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionsAPI.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Cadastro de uma nova Transaction
        /// </summary>
        /// <param name="value">valor da transação</param>
        /// <param name="accountId">Id do comprador</param>
        /// <param name="sellerId">Id do vendedor</param>
        /// <response code="201">Transação com sucesso</response>  
        [ProducesResponseType(201)]
        [HttpPost()]
        public async Task<IActionResult> CreateTransactionAsync(double value, Guid accountId, Guid sellerId)
        {
            var result = await _transactionService.CreateTransactionAsync(value, accountId, sellerId);

            return Created("", result);
        }
    }
}
