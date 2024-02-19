using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> GetUserByUsernameAndPasswordAsync(string username, string password);
    }
}
