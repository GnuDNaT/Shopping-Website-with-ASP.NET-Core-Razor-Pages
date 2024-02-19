using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Interface;
using Repository.Model;
using Repository.Repository;

namespace SignalRAssignment.Pages.CustomerPages
{
    public class LoginFormModel : PageModel
    {
        private readonly Repository.Model.PizzaStoreContext _context;
        private readonly IAccountRepository _accountService;

        public LoginFormModel(Repository.Model.PizzaStoreContext context, IAccountRepository accountService)
        {
            _context = context;
            _accountService = accountService;
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
            var account = await _accountService.GetUserByUsernameAndPasswordAsync(Account.UserName, Account.Password);
            if (account != null)
            {
                // Serialize user information as JSON or store individual properties as needed
                var accountJson = System.Text.Json.JsonSerializer.Serialize(account);
                HttpContext.Session.SetString("UserSession", accountJson); // Store user information in session

                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }
        }
        private bool IsValidLogin(Task<Account> account)
        {
            return (account != null);
        }
    }
}
