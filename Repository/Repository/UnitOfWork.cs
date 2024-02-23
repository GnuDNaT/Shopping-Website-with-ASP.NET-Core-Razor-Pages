using Repository.Interface;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzaStoreContext _context;
        public ICustomerRepository Customers { get; private set; }
        public IOderRepository Orders { get; private set; }
        public IAccountRepository Accounts { get; private set; }

        public PizzaStoreContext StoreContext { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public UnitOfWork(PizzaStoreContext context)
        {
            _context = context;
            StoreContext = context;
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
            Accounts = new AccountRepository(_context);
            Products = new ProductRepository(_context);
            Suppliers = new SupplierRepository(_context);
            Categories = new CategoryRepository(_context);
        }



        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
