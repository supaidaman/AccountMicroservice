using Microsoft.EntityFrameworkCore;
using AccountMicroservice.DBContexts;
using AccountMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountMicroservice.Repository
{
  public class AccountRepository : IAccountRepository
  {
    private readonly AccountContext _dbContext;

    public AccountRepository(AccountContext dbContext)
    {
      _dbContext = dbContext;
    }
   

    public Account GetAccountByID(int accountID)
    {
      return _dbContext.Accounts.Where(c => c.Id  == accountID).FirstOrDefault();
    }

    public IEnumerable<Account> GetAccounts()
    {
      return _dbContext.Accounts.ToList();
    }

    public void InsertAccount(Account product)
    {
      _dbContext.Add(product);
      Save();    }

    public void Save()
    {
      _dbContext.SaveChanges();
    }

    public void UpdateAccount(Account product)
    {
      _dbContext.Entry(product).State = EntityState.Modified;
      Save();
    }
  }
}
