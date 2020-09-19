using Microsoft.EntityFrameworkCore;
using AccountMicroservice.Domain;
using System.Collections.Generic;

namespace AccountMicroservice.DBContexts
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }


        public List<Account> Accounts = new List<Account>()
        {
             new Account(1, "José Almeida", "Conta Pessoal", 20000, "Poupança"),
             new Account(2, "Maria Silva", "Conta Empresarial", 200, "Corrente")
        };
    }; 
}
