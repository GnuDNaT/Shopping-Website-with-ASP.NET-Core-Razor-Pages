using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Model;

namespace SignalRAssignment.Pages.CustomerPages
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
      public Customer Customer { get; set; } = default!;

        public IActionResult OnGet(int id)
        {  
            var customer = _unitOfWork.CustomersRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            var customer = _unitOfWork.CustomersRepository.GetById(id);

            if (customer != null)
            {
                Customer = customer;
                _unitOfWork.CustomersRepository.Remove(Customer);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
