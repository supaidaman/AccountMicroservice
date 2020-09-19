using Microsoft.AspNetCore.Mvc;
using AccountMicroservice.Domain;
using AccountMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Transactions;
using AccountMicroservice.Service;

namespace AccountMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountRepository accountRepository;
        private readonly AccountService accountService;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
            this.accountService = new AccountService();
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var account = accountService.GetAccounts(accountRepository);
            return new OkObjectResult(account);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var account = accountService.GetAccountByID(accountRepository,id);
            return new OkObjectResult(account);
        }

        [HttpGet("Add")]
        public IActionResult Add(int id, decimal value)
        {
            var account = accountService.Add(accountRepository,id,value);
            account.Balance += value;
            return new OkObjectResult(account);
        }

        [HttpGet("Subtract")]
        public IActionResult Subtract(int id, decimal value)
        {
            var account = accountService.Subtract(accountRepository, id, value);
            account.Balance -= value;
            return new OkObjectResult(account);
        }


        [HttpGet("Transfer")]
        public IActionResult Transfer(int giver, int receiver, decimal value)
        {
            var accounts = accountService.Transfer(accountRepository, giver, receiver, value);

            return new OkObjectResult(accounts);
        }
    }
}
