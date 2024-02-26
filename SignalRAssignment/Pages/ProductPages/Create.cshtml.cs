using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Interface;
using Repository.Model;

namespace SignalRAssignment.Pages.ProductPages
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_unitOfWork.StoreContext.Categories, "CategoryId", "CategoryName");
        ViewData["SupplierId"] = new SelectList(_unitOfWork.StoreContext.Suppliers, "SupplierId", "Address");
            return Page();
        }

        [BindProperty]
        public Product Products { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
          if (!ModelState.IsValid || _unitOfWork.ProductsRepository == null || Products == null)
            {
                return Page();
            }

            _unitOfWork.ProductsRepository.Add(Products);
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}
