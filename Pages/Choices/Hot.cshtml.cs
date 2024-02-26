using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Globalization;
using System.Security.Claims;

namespace Jopp_lunch.Pages.Choices
{
    public class HotModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        private readonly UserManager<User> _userManager;

        DateTime startOfWeek;
        public IList<Soup> Soup { get; set; } = default!;
        public IList<Lunch> Lunch { get; set; } = default!;
        public IList<Choice> Choices { get; set; } = default!;

        public HotModel(Jopp_lunch.Data.CanteenContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private void LoadDays()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                startOfWeek = DateTime.Today.AddDays(3);
                return;
            }
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                startOfWeek = DateTime.Today.AddDays(3);
                return;
            }
            if (DateTime.Now.Hour >= 12) 
            { 
                if(DateTime.Now.DayOfWeek == DayOfWeek.Friday) { startOfWeek = DateTime.Today.AddDays(4); }
                else startOfWeek = DateTime.Today.AddDays(2); 
            }
            else startOfWeek = DateTime.Today.AddDays(1);
        }

        private void LoadLunches()
        {
            if (_context.polevky != null)
            {
                Soup = _context.polevky
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date /*&& x.datum_vydeje.Date<=endOfWeek.Date*/)
                    .OrderBy(o => o.datum_vydeje)
                    .ToList();
            }
            if (_context.obedy != null)
            {
                Lunch = _context.obedy
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                    .OrderBy(o => o.datum_vydeje)
                    .ToList();
                if (_context.vybery != null && _context.uzivatele != null)
                {
                    User usr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault() ?? new User();
                    Choices = _context.vybery
                        .Where(x => Lunch.Contains(x.obedId) && x.cislo_uzivatele == usr /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                        .ToList();
                }
            }
        }

        public void OnGet()
        {
            LoadDays();
            LoadLunches();
        }

        public IActionResult OnGetAddLunch(int id)
        {
            if (_context.vybery != null && _context.obedy != null) {
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda==id).FirstOrDefault() ?? new Lunch();
                if (lnch != null)
                {
                    Choice choice = _context.vybery.Where(x => x.obedId == lnch).FirstOrDefault() ?? new Choice();
                    if (choice.cislo_vyberu!=0)
                    {
                        choice.pocet = choice.pocet + 1;
                        _context.vybery.Update(choice);
                        _context.SaveChanges();
                    }
                    else
                    {
                        if (_context.uzivatele != null && _context.vydejni_mista!=null)
                        {
                            choice.pocet += 1;
                            choice.cislo_uzivatele = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault() ?? new User();
                            choice.vydejni_misto = _context.vydejni_mista.Where(x => x.cislo_VM == 1).FirstOrDefault() ?? new Canteen();
                            choice.obedId = lnch;
                            _context.vybery.Add(choice);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            LoadDays();
            LoadLunches();
            return Page();
        }

        public IActionResult OnGetRemoveLunch(int id)
        {
            if (_context.vybery != null && _context.obedy != null)
            {
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda == id).FirstOrDefault() ?? new Lunch();
                if (lnch != null)
                {
                    Choice choice = _context.vybery.Where(x => x.obedId == lnch).FirstOrDefault() ?? new Choice();
                    if (choice != null && choice.pocet>0)
                    {
                        choice.pocet--;
                        _context.vybery.Update(choice);
                        _context.SaveChanges();
                    }
                }
            }
            LoadDays();
            LoadLunches();
            return Page();
        }
    }
}
