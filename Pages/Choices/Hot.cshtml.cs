using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Jopp_lunch.Pages.Choices
{
    public class HotModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        private readonly UserManager<User> _userManager;

        public HotModel(Jopp_lunch.Data.CanteenContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }

        DateTime startOfWeek;
        DateTime endOfWeek;

        public IList<Soup> Soup { get; set; } = default!;
        public IList<Lunch> Lunch { get; set; } = default!;
        public IList<Choice> Choices { get; set; } = default!;


        public string Thisweek = "";

        public async Task OnGetAsync()
        {
            if (DateTime.Now.Hour>=12) startOfWeek = DateTime.Today.AddDays(2);
            else startOfWeek = DateTime.Today.AddDays(1);
            endOfWeek = DateTime.Today.AddDays(
            (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 4 -
            (int)DateTime.Today.DayOfWeek);

            Thisweek = startOfWeek.ToString("dd. MM.") + " - " + endOfWeek.ToString("dd. MM. yyyy");
            if (_context.polevky != null)
            {
                Soup = await _context.polevky
                    .Where(x=> x.datum_vydeje.Date>=startOfWeek.Date /*&& x.datum_vydeje.Date<=endOfWeek.Date*/)
                    .ToListAsync();
            }
            if (_context.obedy != null)
            {
                Lunch = await _context.obedy
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                    .ToListAsync();
                if (_context.vybery != null && _context.uzivatele != null)
                {
                    User usr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
                    Choices = await _context.vybery
                        .Where(x => Lunch.Contains(x.obedId) && x.cislo_uzivatele== usr /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                        .ToListAsync();
                }
            }          
        }



        public IActionResult OnGetAddLunch(int id)
        {
            if (_context.vybery != null && _context.obedy != null) {
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda==id).FirstOrDefault();
                if (lnch != null)
                {
                    Choice choice = _context.vybery.Where(x => x.obedId == lnch).FirstOrDefault();
                    if (choice != null)
                    {
                        choice.pocet = choice.pocet + 1;
                        _context.vybery.Update(choice);
                        _context.SaveChanges();
                    }
                    else
                    {
                        if (_context.uzivatele != null)
                        {
                            choice = new Choice();
                            choice.pocet += 1;
                            choice.cislo_uzivatele = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
                            choice.vydejni_misto = _context.vydejni_mista.Where(x => x.cislo_VM == 1).FirstOrDefault();
                            choice.obedId = lnch;
                            _context.vybery.Add(choice);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            if (DateTime.Now.Hour >= 12) startOfWeek = DateTime.Today.AddDays(2);
            else startOfWeek = DateTime.Today.AddDays(1);
            endOfWeek = DateTime.Today.AddDays(
            (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 4 -
            (int)DateTime.Today.DayOfWeek);
            if (_context.polevky != null)
            {
                Soup =  _context.polevky
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date /*&& x.datum_vydeje.Date<=endOfWeek.Date*/)
                    .ToList();
            }
            if (_context.obedy != null)
            {
                Lunch =  _context.obedy
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                    .ToList();
                if (_context.vybery != null && _context.uzivatele != null)
                {
                    User usr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
                    Choices =  _context.vybery
                        .Where(x => Lunch.Contains(x.obedId) && x.cislo_uzivatele == usr /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                        .ToList();
                }
            }
            return Page();
        }

        public IActionResult OnGetRemoveLunch(int id)
        {
            if (_context.vybery != null && _context.obedy != null)
            {
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda == id).FirstOrDefault();
                if (lnch != null)
                {
                    Choice choice = _context.vybery.Where(x => x.obedId == lnch).FirstOrDefault();
                    if (choice != null && choice.pocet>0)
                    {
                        choice.pocet--;
                        _context.vybery.Update(choice);
                        _context.SaveChanges();
                    }
                }
            }
            if (DateTime.Now.Hour >= 12) startOfWeek = DateTime.Today.AddDays(2);
            else startOfWeek = DateTime.Today.AddDays(1);
            endOfWeek = DateTime.Today.AddDays(
            (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 4 -
            (int)DateTime.Today.DayOfWeek);
            if (_context.polevky != null)
            {
                Soup =  _context.polevky
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date /*&& x.datum_vydeje.Date<=endOfWeek.Date*/)
                    .ToList();
            }
            if (_context.obedy != null)
            {
                Lunch =  _context.obedy
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                    .ToList();
                if (_context.vybery != null && _context.uzivatele != null)
                {
                    User usr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault();
                    Choices =  _context.vybery
                        .Where(x => Lunch.Contains(x.obedId) && x.cislo_uzivatele == usr /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                        .ToList();
                }
            }
            return Page();
        }
    }
}
