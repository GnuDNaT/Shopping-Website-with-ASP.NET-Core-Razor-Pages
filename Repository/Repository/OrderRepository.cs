using Repository.Interface;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOderRepository
    {
        public OrderRepository(PizzaStoreContext context) : base(context)
        {
        }
    }
}
