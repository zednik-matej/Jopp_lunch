using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Jopp_lunch.Pages.Options
{
    public class SendChoicesModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public SendChoicesModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            if(_context!=null)
            {

            }
        }
    }
}
