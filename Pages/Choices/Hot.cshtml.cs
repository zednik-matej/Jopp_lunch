using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Jopp_lunch.Pages.Choices
{
    public class HotModel : PageModel
    {
        DateTime startOfWeek = DateTime.Today.AddDays(
       (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
       (int)DateTime.Today.DayOfWeek);
        DateTime endOfWeek = DateTime.Today.AddDays(
        (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 4 -
        (int)DateTime.Today.DayOfWeek);

        String Thisweek = "";
        public void OnGet()
        {
            Thisweek = startOfWeek.ToString("dd-MM") + " - " + endOfWeek.ToString("dd-MM");
        }
    }
}
