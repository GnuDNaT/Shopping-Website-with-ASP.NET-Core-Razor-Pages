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
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
      public Product Product { get; set; } = default!;

        public IActionResult OnGetAsync(int id)
        {

            var product =  _unitOfWork.ProductsRepository.GetById( id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            var product = _unitOfWork.ProductsRepository.GetById(id);

            if (product != null)
            {
                Product = product;
                _unitOfWork.ProductsRepository.Remove(Product);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
