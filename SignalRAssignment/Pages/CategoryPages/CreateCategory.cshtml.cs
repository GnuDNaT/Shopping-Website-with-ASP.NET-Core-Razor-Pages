using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SignalRAssignment.Pages.CategoryPages
{
    public class CreateCategoryModel : PageModel
    {
        private readonly Repository.Model.PizzaStoreContext _dbcontext;

        public CreateCategoryModel(Repository.Model.PizzaStoreContext context)
        {
            this._dbcontext = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
