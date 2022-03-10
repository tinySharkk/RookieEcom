using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Rookie.Ecom.Customer.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
