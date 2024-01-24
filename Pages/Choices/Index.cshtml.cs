using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;

namespace Jopp_lunch.Pages.Choices
{
    [Authorize(Roles = ("employee,admin,editor,chef"))]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}
