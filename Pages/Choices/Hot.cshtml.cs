using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PublicHoliday;
using System.Collections.Immutable;
using System.Globalization;
using System.Security.Claims;

namespace Jopp_lunch.Pages.Choices
{
    [Authorize(Roles = "admin,editor,chef,employee")]
    public class HotModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        private readonly UserManager<User> _userManager;

        public class DatumVD
        {
            public DateTime datum_vydeje;
            public string Canteen;
            public int Cnt_ID;

            public DatumVD(DateTime datum_vydeje, string canteen, int cnt_ID)
            {
                this.datum_vydeje = datum_vydeje;
                Canteen = canteen;
                Cnt_ID = cnt_ID;
            }
        }

        public List<DatumVD> _VydejniMista { get; set; } = default!;

        public DateTime lockdate;
        public DateTime startOfWeek;
        public IList<Soup> Soup { get; set; } = default!;
        public IList<Lunch> Lunch { get; set; } = default!;
        public IList<Choice> Choices { get; set; } = default!;

        public HotModel(Jopp_lunch.Data.CanteenContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _VydejniMista = new List<DatumVD>();
        }

        private void LoadDays()
        {
            CzechRepublicPublicHoliday czhol = new CzechRepublicPublicHoliday();
            DateTime dt = DateTime.Now;
            if (DateTime.Now.Hour > 12) dt=dt.AddDays(1);
            lockdate = czhol.NextWorkingDayNotSameDay(dt);
            startOfWeek = DateTime.Now;
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
                    int cnt_id = 1;
                    User thisUsr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault() ?? new User();
                    if (_context.vybery.Where(x => x.obedId.cislo_polevky == Sp && x.obedId.forma == 0 && x.cislo_uzivatele==thisUsr).FirstOrDefault() != null)
                    {
                        cnt_id = _context.vybery.Where(x => x.obedId.cislo_polevky == Sp && x.obedId.forma == 0 && x.cislo_uzivatele == thisUsr).FirstOrDefault().vydejni_misto.cislo_VM;
                    }
                    else if (_context.uzivatele.Where(x => x.UserName == thisUsr.UserName).FirstOrDefault().vychozi_VM != null)
                    {
                        cnt_id = _context.uzivatele.Where(x => x.UserName == thisUsr.UserName).FirstOrDefault().vychozi_VM.cislo_VM;
                    }
                    else cnt_id = _context.vydejni_mista.FirstOrDefault().cislo_VM;
                    canteen = _context.vydejni_mista.Where(x => x.cislo_VM == cnt_id).FirstOrDefault().nazev;
                    DatumVD dvd = new DatumVD(Sp.datum_vydeje, canteen, cnt_id);
                    if (_VydejniMista.Where(x => x.datum_vydeje == Sp.datum_vydeje).Count() == 0)
                    {
                        _VydejniMista.Add(dvd);
                    }
                }
            }
            if (_context.obedy != null)
            {
                Lunch = _context.obedy
                    .Where(x => x.datum_vydeje.Date >= startOfWeek.Date && x.forma == 0 /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                    .OrderBy(o => o.datum_vydeje)
                    .ToList();
                if (_context.vybery != null && _context.uzivatele != null)
                {
                    User usr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault() ?? new User();
                    if (datum_vydeje != null && canteen_name != null && _context.vydejni_mista!=null)
                    {
                        DateTime dt = DateTime.Parse(datum_vydeje);
                        _context.vybery.Where(x => Lunch.Contains(x.obedId) && x.cislo_uzivatele == usr && x.obedId.forma == 0 && x.obedId.datum_vydeje.Date == dt.Date)
                            .ToList()
                            .ForEach(item => item.vydejni_misto=_context.vydejni_mista
                                    .Where(vm=>vm.nazev!= canteen_name)
                                    .FirstOrDefault());
                        if (_context.vybery.Where(x => x.cislo_uzivatele == usr && x.obedId.datum_vydeje.Date == dt.Date && x.obedId.forma == 0).FirstOrDefault() != null)
                        {
                            _VydejniMista.Where(vm => vm.datum_vydeje.Date == dt.Date).FirstOrDefault().Canteen = _context.vybery.Where(x => x.cislo_uzivatele == usr && x.obedId.datum_vydeje.Date == dt.Date && x.obedId.forma == 0).FirstOrDefault().vydejni_misto.nazev;
                            _VydejniMista.Where(vm => vm.datum_vydeje.Date == dt.Date).FirstOrDefault().Cnt_ID = _context.vybery.Where(x => x.cislo_uzivatele == usr && x.obedId.datum_vydeje.Date == dt.Date && x.obedId.forma == 0).FirstOrDefault().vydejni_misto.cislo_VM;
                        }
                    }                  
                    _context.SaveChanges();
                    Choices = _context.vybery
                    .Where(x => Lunch.Contains(x.obedId) && x.cislo_uzivatele == usr && x.obedId.forma == 0 /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
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
            LoadDays();
            LoadLunches(null, null);
            if (_context.vybery != null && _context.obedy != null && _context.uzivatele != null && _context.vydejni_mista != null)
            {
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda == id).FirstOrDefault() ?? new Lunch();
                if (lnch.datum_vydeje.Date >= lockdate.Date)
                {
                    if (lnch.cislo_obeda != 0)
                    {
                        User thisUsr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault() ?? new User();
                        Choice choice = _context.vybery.Where(x => x.obedId == lnch && x.cislo_uzivatele == thisUsr && x.obedId.forma == 0).FirstOrDefault() ?? new Choice();
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
                                Canteen cnt;
                                if (_VydejniMista.Where(x => x.datum_vydeje.Date == lnch.datum_vydeje.Date).FirstOrDefault() != null)
                                {
                                    int cnt_id = _VydejniMista.Where(x => x.datum_vydeje.Date == lnch.datum_vydeje.Date).FirstOrDefault().Cnt_ID;
                                    cnt = _context.vydejni_mista.Where(x => x.cislo_VM == cnt_id).FirstOrDefault();
                                }
                                else if (_context.uzivatele.Where(x => x.UserName == thisUsr.UserName).FirstOrDefault().vychozi_VM != null)
                                {
                                    cnt = _context.uzivatele.Where(x => x.UserName == thisUsr.UserName).FirstOrDefault().vychozi_VM;
                                }
                                else cnt = _context.vydejni_mista.FirstOrDefault();
                                choice.vydejni_misto = cnt;
                                choice.obedId = lnch;
                                _context.vybery.Add(choice);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
            }
            LoadDays();
            LoadLunches(null,null);
            return Page();
        }

        public IActionResult OnGetRemoveLunch(int id)
        {
            if (_context.vybery != null && _context.obedy != null && _context.uzivatele != null)
            {
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda == id).FirstOrDefault() ?? new Lunch();
                if (lnch.datum_vydeje.Date > lockdate.Date)
                {
                    if (lnch != null)
                    {
                        User thisUsr = _context.uzivatele.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)).FirstOrDefault() ?? new User();
                        Choice choice = _context.vybery.Where(x => x.obedId == lnch && x.obedId.forma == 0 && x.cislo_uzivatele == thisUsr).FirstOrDefault() ?? new Choice();
                        if (choice != null && choice.pocet > 0)
                        {
                            choice.pocet--;
                            _context.vybery.Update(choice);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            LoadDays();
            LoadLunches(null,null);
            return Page();
        }
    }
}
