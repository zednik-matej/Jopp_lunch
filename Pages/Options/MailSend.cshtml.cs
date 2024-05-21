using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jopp_lunch.Pages.Options
{
    [Authorize(Roles = "admin,editor")]
    public class MailSendModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
