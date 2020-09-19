using AccountMicroservice.Domain;
using System.Collections.Generic;

namespace AccountMicroservice.Repository
{
  public interface IAccountRepository
  {
    IEnumerable<Account> GetAccounts();
    Account GetAccountByID(int account);
    void InsertAccount(Account account);
    void UpdateAccount(Account account);
    void Save();
  }
}
