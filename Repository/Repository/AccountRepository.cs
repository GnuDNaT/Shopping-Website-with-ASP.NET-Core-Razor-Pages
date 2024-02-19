using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly PizzaStoreContext _dbContext;
        public AccountRepository(PizzaStoreContext context) : base(context)
        {
            this._dbContext = context;
        }
        async Task<Account> IAccountRepository.GetUserByUsernameAndPasswordAsync(string userName, string password)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(a => a.UserName == userName && a.Password == password);
        }
    }
}
