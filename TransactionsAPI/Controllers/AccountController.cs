using Application.Dto;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionsAPI.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

		/// <summary>
		/// Consulta usuário
		/// </summary>
		/// <param name="id">Identificação do usuário</param>
		/// <returns code="200">usuário</returns>
		/// <response code="404">Nenhuma conta encontrada</response> 
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(AccountDto), 200)]
		public async Task<IActionResult> GetAccountByIdAsync(Guid id)
		{
			return Ok(await _accountService.GetAccountByIdAsync(id));
		}


		/// <summary>
		/// Consulta todas as contas
		/// </summary>
		/// <returns code="200">Todas as contas encontradas</returns>
		[HttpGet]
		[ProducesResponseType(typeof(List<AccountDto>), 200)]
		public async Task<IActionResult> GetAccountsAsync()
		{
			return Ok(await _accountService.GetAccountsAsync());
		}
		/// <summary>
		/// Cadastro de uma nova Account
		/// </summary>
		/// <param name="account">Dados do consumidor a serem cadastrados</param>
		/// <response code="201">Cadastrado com sucesso</response>  
		[ProducesResponseType(201)]
		[HttpPost()]
		public async Task<IActionResult> PostCustomerAsync([FromBody] CreateAccountDto account)
		{
			var result = await _accountService.CreateAccountAsync(account);

			return Created("", result);
		}

	}
}
