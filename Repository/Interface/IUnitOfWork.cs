using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        PizzaStoreContext StoreContext { get; }
        IGenericRepository<Customer> CustomersRepository { get; }
        IGenericRepository<Order> OrdersRepository { get; }
        IGenericRepository<Product> ProductsRepository { get; }
        IGenericRepository<Supplier> SuppliersRepository { get; }
        IGenericRepository<Category> CategoriesRepository { get; }
        IGenericRepository<Account> AccountsRepository { get; }

        Task<Account> GetUserByUsernameAndPasswordAsync(string username, string password);
        int Save();
    }
}
