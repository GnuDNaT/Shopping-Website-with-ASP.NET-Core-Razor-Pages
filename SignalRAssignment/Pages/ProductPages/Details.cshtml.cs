using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Model;

namespace SignalRAssignment.Pages.ProductPages
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      public Product Products { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //var product = await _unitOfWork.Products.GetProduct(id);
            var product = await _unitOfWork.StoreContext.Products
                                        .Include(p => p.Category)
                                        .Include(p => p.Supplier)
                                        .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Products = product;
            }
            return Page();
        }
    }
}
