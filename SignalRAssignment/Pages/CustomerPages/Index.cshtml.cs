using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Model;
using Repository.Repository;

namespace SignalRAssignment.Pages.CustomerPages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Customer> Customers { get; set; } = default!;

        public void OnGet()
        {
            if (_unitOfWork.CustomersRepository != null)
            {
                Customers = _unitOfWork.CustomersRepository.Get(filter: null,
                                                    orderBy: null,
                                                    includeProperties: "", // Assuming no related entities to include, otherwise specify them as a comma-separated string
                                                    pageIndex: 1,
                                                    pageSize: 5).ToList();
            }
        }
    }
}
// Instantiate your repository - assuming `context` is your database context
//var repository = new GenericRepository<Product>(context);

//// Define the filter for products starting with "Coca" and price between 100 and 1000
//Expression<Func<Product, bool>> filter = p => p.Name.StartsWith("Coca") && p.Price >= 100 && p.Price <= 1000;

//// Define the ordering by ProductCode
//Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = q => q.OrderBy(p => p.ProductCode);

// Calling the Get method with the specified criteria
//var products = repository.Get(
//    filter: filter,
//    orderBy: orderBy,
//    includeProperties: "", // Assuming no related entities to include, otherwise specify them as a comma-separated string
//    pageIndex: 2,
//    pageSize: 50);