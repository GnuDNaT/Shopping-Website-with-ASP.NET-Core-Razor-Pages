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
        ICustomerRepository Customers { get; }
        IOderRepository Orders { get; }
        IProductRepository Products { get; }
        IAccountRepository Accounts { get; }
        ISupplierRepository Suppliers { get; }
        ICategoryRepository Categories { get; }
        int Save();
    }
}
