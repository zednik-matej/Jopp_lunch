using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicHoliday;

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
                if (_context.vybery != null || _context.obedy != null)
                {
                    CzechRepublicPublicHoliday czhol = new CzechRepublicPublicHoliday();
                    DateTime dt= DateTime.Now;
                    DateTime firstWork = czhol.NextWorkingDayNotSameDay(dt);
                    DateTime secondWork = czhol.NextWorkingDayNotSameDay(firstWork);

                    _context.obedy.Load();
                    _context.vybery.Load();
                    int pocet_tep_vm = _context.vybery.Where(x => x.obedId.forma == 0 && x.obedId.datum_vydeje.Date == firstWork.Date && x.vydejni_misto.cislo_VM == 1).ToList().Count();
                    int pocet_bal_vm = _context.vybery.Where(x => x.obedId.forma == 1 && x.obedId.datum_vydeje.Date == secondWork.Date && x.vydejni_misto.cislo_VM == 1).ToList().Count();
                    int pocet_tep_tr = _context.vybery.Where(x => x.obedId.forma == 0 && x.obedId.datum_vydeje.Date == firstWork.Date && x.vydejni_misto.cislo_VM == 2).ToList().Count();
                    int pocet_bal_tr = _context.vybery.Where(x => x.obedId.forma == 1 && x.obedId.datum_vydeje.Date == secondWork.Date && x.vydejni_misto.cislo_VM == 2).ToList().Count();


                }
            }
        }
    }
}
