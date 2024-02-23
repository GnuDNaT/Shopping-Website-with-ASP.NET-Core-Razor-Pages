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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly PizzaStoreContext _dbContext;

        public ProductRepository(PizzaStoreContext context) : base(context)
        {
            this._dbContext = context;
        }

        public Task<Product> GetProduct(int id)
        {
            return _dbContext.Products.Include(p => p.Category)
                             .Include(p => p.Supplier)
                              .FirstAsync(m => m.ProductId == id);
        }
    }
}
