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
    public class UnitOfWork : IUnitOfWork
    {
        private  PizzaStoreContext _context ;
        private IGenericRepository<Customer> _customersRepository;
        private IGenericRepository<Account> _accountRepository;
        private IGenericRepository<Order> _orderRepository;
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<Supplier> _supplierRepository;
        private IGenericRepository<Category> _categoryRepository;

        public UnitOfWork(PizzaStoreContext pizzaStoreContext)
        {
            _context = pizzaStoreContext;
        }
        public IGenericRepository<Customer> CustomersRepository
        {
            get
            {
                return _customersRepository ??= new GenericRepository<Customer>(_context);
            }
        }

        public IGenericRepository<Order> OrdersRepository { 
            get
            {
                return _orderRepository ??= new GenericRepository<Order>(_context);
            }
        }

        public IGenericRepository<Product> ProductsRepository {
            get 
            {
                return _productRepository ??= new GenericRepository<Product>(_context); 
            } 
        }

        public IGenericRepository<Supplier> SuppliersRepository
        {
            get
            {
                return _supplierRepository ??= new GenericRepository<Supplier>(_context);
            }   
        }

        public IGenericRepository<Category> CategoriesRepository {
            get
            {
                return _categoryRepository ??= new GenericRepository<Category>(_context);
            }
        }

        public IGenericRepository<Account> AccountsRepository
        {
            get
            {
                return _accountRepository ??= new GenericRepository<Account>(_context);
            }
        }

        public PizzaStoreContext StoreContext => _context;

        public int Save()
        {
            return StoreContext.SaveChanges();
        }
        public void Dispose()
        {
            StoreContext.Dispose();
        }

        public async Task<Account> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return await StoreContext.Accounts.FirstOrDefaultAsync(a => a.UserName == username && a.Password == password);
        }
    }
}
