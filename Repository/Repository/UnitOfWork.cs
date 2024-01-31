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
        public UnitOfWork(PizzaStoreContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
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
