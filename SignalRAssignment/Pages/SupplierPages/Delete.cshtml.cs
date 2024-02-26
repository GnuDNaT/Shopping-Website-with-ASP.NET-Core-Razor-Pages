using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Model;

namespace SignalRAssignment.Pages.SupplierPages
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
      public Supplier Supplier { get; set; } = default!;

        public IActionResult OnGetAsync(int id)
        {
            if (id == null || _unitOfWork.Suppliers == null)
            {
                return NotFound();
            }

            var supplier = _unitOfWork.Suppliers.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }
            else 
            {
                Supplier = supplier;
            }
            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            if (id == null || _unitOfWork.Suppliers == null)
            {
                return NotFound();
            }
            var supplier =  _unitOfWork.Suppliers.GetById(id);

            if (supplier != null)
            {
                Supplier = supplier;
                _unitOfWork.Suppliers.Remove(Supplier);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
