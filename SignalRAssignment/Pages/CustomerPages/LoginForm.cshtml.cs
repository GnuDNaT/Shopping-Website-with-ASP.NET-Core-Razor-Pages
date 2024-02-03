using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Model;
using Repository.Repository;

namespace SignalRAssignment.Pages.CustomerPages
{
    public class LoginFormModel : PageModel
    {
        private readonly Repository.Model.PizzaStoreContext _context;

        public LoginFormModel(Repository.Model.PizzaStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var accountRepository = new AccountRepository(_context);

            if (IsValidLogin(accountRepository.GetByUserName(Account.UserName), Account.Password))
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }
        }
        private bool IsValidLogin(Account account, string password)
        {
            return (account != null && account.Password == password);
        }
    }
}
