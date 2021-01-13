using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WA.Repositories.Contract;


namespace WA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        private ILogger<AccountsController> _logger;

        public AccountsController(
            IAccountRepository accountRepository,
            ILogger<AccountsController> logger)
        {
            _accountRepository = accountRepository ?? throw new Exception(nameof(accountRepository));
            _logger = logger ?? throw new Exception(nameof(logger));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                return Ok(await _accountRepository.GetAllAccountsAsync());
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.ToString(), "failed to load all accounts");

                return StatusCode(500, "Ops something vent wrong!");
            }
        }

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            if (accountId == 0 || accountId < 0)
            {
                return BadRequest("accoutnId has to be larger than 0");
            }

            try
            {
                return Ok(await _accountRepository.GetAccountByIdAsync(accountId));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.ToString(), "failed to specific account");

                return StatusCode(500, "Ops something vent wrong!");
            }
        }
    }
}
