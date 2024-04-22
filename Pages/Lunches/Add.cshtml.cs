using Jopp_lunch.Controllers;
using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;


namespace Jopp_lunch.Pages.Lunches
{
    [Authorize(Roles = "admin,editor")]
    public class AddModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public AddModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }


        public IActionResult OnPost(string textAnswer)
        {
            LunchesController lnchctrl = new LunchesController(_context);
            int err = lnchctrl.parseText(textAnswer);
            return Page();
        }
    }  
}
