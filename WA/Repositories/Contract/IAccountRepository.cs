using System.Collections.Generic;
using System.Threading.Tasks;
using WA.DatabaseLayer.Models;

namespace WA.Repositories.Contract
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int accountId);
    }
}
