using AccountMicroservice.Domain;
using AccountMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Service
{
    public class AccountService
    {

        public IEnumerable<Account> GetAccounts(IAccountRepository accountRepository)
        {
            return accountRepository.GetAccounts();
        }

        public Account GetAccountByID(IAccountRepository accountRepository, int id)
        {
            return  accountRepository.GetAccountByID(id);
        }


        public Account Add(IAccountRepository accountRepository, int id,decimal value)
        {
            var account = accountRepository.GetAccountByID(id);
            account.Balance += value;
            return account;
        }

        public Account Subtract(IAccountRepository accountRepository, int id, decimal value)
        {
            var account = accountRepository.GetAccountByID(id);
            account.Balance -= value;
            return account;
        }

        public List<Account> Transfer(IAccountRepository accountRepository, int giver, int receiver, decimal value)
        {
            var accountGiver = accountRepository.GetAccountByID(giver);
            var accountReceiver = accountRepository.GetAccountByID(receiver);

            accountGiver.Balance -= value;
            accountReceiver.Balance += value;
            List<Account> accounts = new List<Account>();
            accounts.Add(accountGiver);
            accounts.Add(accountReceiver);
            return accounts;
        }

    }
}
