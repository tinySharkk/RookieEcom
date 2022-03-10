using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Rookie.Ecom.Customer.Pages
{
    [Authorize]
    public class LoginModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("/");
        }
        public IActionResult OnPost()
        {
            return Redirect("/");
        }
    }
}
