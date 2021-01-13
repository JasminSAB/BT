using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA.DatabaseLayer.Context;
using WA.DatabaseLayer.Models;
using WA.Repositories.Contract;

namespace WA.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _dbContext;

        public AccountRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext ?? throw new Exception(nameof(dbContext));
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            // I could also use an auto mapper in this case and have separate layer of entities to handle data transfer objects, but not much time left 

            return await _dbContext.Accounts
                .Include(x => x.ContactInfo)
                .AsNoTracking()
                .Select(x => new Account
                {
                    AccountId = x.AccountId,
                    Address = x.Address,
                    Name = x.Name,
                    ContactInfo = x.ContactInfo,
                    NumberOfContacts = x.ContactInfo != null ? x.ContactInfo.Count : 0
                }).ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await _dbContext.Accounts
                .FirstOrDefaultAsync(x => x.AccountId == accountId);
        }
    }
}
