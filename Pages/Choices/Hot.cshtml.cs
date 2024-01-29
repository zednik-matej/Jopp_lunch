using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Jopp_lunch.Pages.Choices
{
    public class HotModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public HotModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        DateTime startOfWeek;
        DateTime endOfWeek;

        public IList<Soup> Soup { get; set; } = default!;
        public IList<Lunch> Lunch { get; set; } = default!;

        public string Thisweek = "";
        public async Task OnGetAsync()
        {
            if(DateTime.Now.Hour>=12) startOfWeek = DateTime.Today.AddDays(2);
            else startOfWeek = DateTime.Today.AddDays(1);
            endOfWeek = DateTime.Today.AddDays(
            (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 4 -
            (int)DateTime.Today.DayOfWeek);

            Thisweek = startOfWeek.ToString("dd. MM.") + " - " + endOfWeek.ToString("dd. MM. yyyy");
            if (_context.polevky != null)
            {
                Soup = await _context.polevky
                    .Where(x=> x.datum_vydeje.Date>=startOfWeek.Date && x.datum_vydeje.Date<=endOfWeek.Date)
                    .ToListAsync();
            }
            if (_context.obedy != null)
            {
                Lunch = await _context.obedy
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date && x.datum_vydeje.Date <= endOfWeek.Date)
                    .ToListAsync();
            }

        }
    }
}
