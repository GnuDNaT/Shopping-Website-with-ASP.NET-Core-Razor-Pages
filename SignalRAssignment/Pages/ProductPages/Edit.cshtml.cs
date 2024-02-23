using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Model;

namespace SignalRAssignment.Pages.ProductPages
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public IActionResult OnGetAsync(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;

            // Set SelectList for Categories and Suppliers
            ViewData["CategoryId"] = new SelectList(_unitOfWork.StoreContext.Categories, "CategoryId", "CategoryName", Product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_unitOfWork.StoreContext.Suppliers, "SupplierId", "CompanyName", Product.SupplierId);

            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.StoreContext.Attach(Product).State = EntityState.Modified;

            try
            {
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
          return (_unitOfWork.StoreContext.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
