using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;
using System.Globalization;
using System.Security.Claims;

namespace Jopp_lunch.Pages.Choices
{
    public class HotModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        private readonly UserManager<User> _userManager;

        public class DatumVD
        {
            public DateTime datum_vydeje;
            public string Canteen;

            public DatumVD(DateTime datum_vydeje, string canteen)
            {
                this.datum_vydeje = datum_vydeje;
                Canteen = canteen;
            }
        }

        public List<DatumVD> _VydejniMista { get; set; } = default!;

        DateTime startOfWeek;
        public IList<Soup> Soup { get; set; } = default!;
        public IList<Lunch> Lunch { get; set; } = default!;
        public IList<Choice> Choices { get; set; } = default!;

        public HotModel(Jopp_lunch.Data.CanteenContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _VydejniMista = new List<DatumVD>();
        }

        private void setVMLunches(DateTime datum_vydeje)
        {

        }

        private void LoadDays()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                startOfWeek = DateTime.Today.AddDays(3);
                return;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                startOfWeek = DateTime.Today.AddDays(2);
                return;
            }
            if (DateTime.Now.Hour >= 12) 
            { 
                if(DateTime.Now.DayOfWeek == DayOfWeek.Friday) { startOfWeek = DateTime.Today.AddDays(4); }
                else startOfWeek = DateTime.Today.AddDays(2); 
            }
            else startOfWeek = DateTime.Today.AddDays(1);
        }

        private void LoadLunches(string datum_vydeje,string canteen_name)
        {

            if (_context.polevky != null)
            {
                Soup = _context.polevky
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date /*&& x.datum_vydeje.Date<=endOfWeek.Date*/)
                    .OrderBy(o => o.datum_vydeje)
                    .ToList();
                foreach (Soup Sp in Soup)
                {
                    _context.vydejni_mista.Load();
                    _context.obedy.Load();
                    _context.polevky.Load();
                    string canteen = "";
                    if (_context.vybery.Where(x => x.obedId.cislo_polevky == Sp).FirstOrDefault() != null)
                    {
                        canteen = _context.vybery.Where(x => x.obedId.cislo_polevky == Sp).FirstOrDefault().vydejni_misto.nazev;
                    }
                    if (canteen.IsNullOrEmpty()) canteen = "Velké Meziøíèí";//TO DO: vychozi VM z uzivatele
                    DatumVD dvd = new DatumVD(Sp.datum_vydeje, canteen);
                    _VydejniMista.Add(dvd);
                }
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
                    if (datum_vydeje != null && canteen_name != null && _context.vydejni_mista!=null)
                    {
                        DateTime dt = DateTime.Parse(datum_vydeje);
                        _context.vybery.Where(x => Lunch.Contains(x.obedId) && x.cislo_uzivatele == usr && x.forma == 0 && x.obedId.datum_vydeje.Date == dt.Date)
                            .ToList()
                            .ForEach(item => item.vydejni_misto=_context.vydejni_mista
                                    .Where(vm=>vm.nazev!= canteen_name)
                                    .FirstOrDefault());
                        if (_context.vybery.Where(x => x.cislo_uzivatele == usr && x.obedId.datum_vydeje.Date == dt.Date).FirstOrDefault() != null)
                        {
                            _VydejniMista.Where(vm => vm.datum_vydeje.Date == dt.Date).FirstOrDefault().Canteen = _context.vybery.Where(x => x.cislo_uzivatele == usr && x.obedId.datum_vydeje.Date == dt.Date).FirstOrDefault().vydejni_misto.nazev;
                        }
                    }                  
                    _context.SaveChanges();
                    Choices = _context.vybery
                    .Where(x => Lunch.Contains(x.obedId) && x.cislo_uzivatele == usr && x.forma == 0 /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                    .ToList();
                }
            }
        }

        public void OnGet()
        {
            LoadDays();
            LoadLunches(null,null);         
        }

        public IActionResult OnGetZmenaVM(string id,string vm)
        {
            LoadDays();
            LoadLunches(id,vm);
            return Page();
        }


        public IActionResult OnGetAddLunch(int id)
        {          
            if (_context.vybery != null && _context.obedy != null && _context.uzivatele != null)
            {
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda == id).FirstOrDefault() ?? new Lunch();
                if (lnch.cislo_obeda != 0)
                {
                    User thisUsr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault() ?? new User();
                    Choice choice = _context.vybery.Where(x => x.obedId == lnch &&  x.cislo_uzivatele == thisUsr && x.forma == 0).FirstOrDefault() ?? new Choice();
                    if (choice.cislo_vyberu != 0)
                    {
                        choice.pocet = choice.pocet + 1;
                        _context.vybery.Update(choice);
                        _context.SaveChanges();
                    }
                    else
                    {
                        if (_context.vydejni_mista != null)
                        {
                            choice.pocet += 1;
                            choice.cislo_uzivatele = thisUsr;
                            choice.vydejni_misto = _context.vydejni_mista.Where(x => x.cislo_VM == 1).FirstOrDefault() ?? new Canteen();
                            choice.obedId = lnch;
                            choice.forma = 0;//0-hot,1-packed/cold
                            _context.vybery.Add(choice);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            LoadDays();
            LoadLunches(null,null);
            Console.Out.WriteLine("Some log entry");
            return Page();
        }

        public IActionResult OnGetRemoveLunch(int id)
        {
            if (_context.vybery != null && _context.obedy != null)
            {
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda == id).FirstOrDefault() ?? new Lunch();
                if (lnch != null)
                {
                    Choice choice = _context.vybery.Where(x => x.obedId == lnch && x.forma == 0).FirstOrDefault() ?? new Choice();
                    if (choice != null && choice.pocet>0)
                    {
                        choice.pocet--;
                        _context.vybery.Update(choice);
                        _context.SaveChanges();
                    }
                }
            }
            LoadDays();
            LoadLunches(null,null);
            return Page();
        }
    }
}
