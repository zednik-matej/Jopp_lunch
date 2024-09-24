using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Jopp_lunch.Pages.Choices
{
    [Authorize(Roles = "admin,editor,chef")]
    public class ListEditModel : PageModel
    {
        public class Vyb
        {
            public int User_id;
            public string? jmeno;
            public string? prijmeni;
            public int celkem;
            public int? m1, m2, m3, m4, mb1, mb2, mb3;

        }
        public int id_m1, id_m2, id_m3, id_m4;
        public int id_mb1, id_mb2, id_mb3;
        public int pocetMB1;
        public int pocetMB2;
        public int pocetMB3;
        public int pocetM1;
        public int pocetM2;
        public int pocetM3;
        public int pocetM4;
        public List<Vyb> vybery_view { get; set; } = new List<Vyb>();
        public DateTime loadedDate;
        public Canteen def_VM { get; set; } = new Canteen();
        public IList<Lunch> Lunches { get; set; } = default!;

        private readonly Jopp_lunch.Data.CanteenContext _context;

        public void LoadVybery(DateTime dt)
        {
            pocetM1 = 0;
            pocetM2 = 0;
            pocetM3 = 0;
            pocetM4 = 0;
            pocetMB1 = 0;
            pocetMB2 = 0;
            pocetMB3 = 0;          
            if (_context.uzivatele != null && _context.obedy != null && _context.vybery != null && _context.vydejni_mista != null)
            {
                _context.uzivatele.Load();
                _context.obedy.Load();
                _context.vybery.Load();
                _context.vydejni_mista.Load();
                Choice = _context.vybery.ToList();
                Lunches = _context.obedy
                    .Where(x => x.datum_vydeje.Date == dt.Date/*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                    .OrderBy(o => o.datum_vydeje)
                    .ToList();
                vybery_view = new List<Vyb>();
                id_m1 = 0; id_m2 = 0; id_m3 = 0; id_m4 = 0;
                int i = 0;
                foreach (var obed in _context.obedy.Where(o => o.datum_vydeje.Date == dt.Date && o.forma == 0).OrderBy(o => o.cislo_obeda).ToList())
                {
                    switch (i)
                    {
                        case 0:
                            id_m1 = obed.cislo_obeda; break;
                        case 1:
                            id_m2 = obed.cislo_obeda; break;
                        case 2:
                            id_m3 = obed.cislo_obeda; break;
                        case 3:
                            id_m4 = obed.cislo_obeda; break;
                        default:
                            break;
                    }
                    i++;
                }
                id_mb1 = 0; id_mb2 = 0; id_mb3 = 0;
                i = 0;
                foreach (var obed in _context.obedy.Where(o => o.datum_vydeje.Date == dt.Date && o.forma == 1).OrderBy(o => o.cislo_obeda).ToList())
                {
                    switch (i)
                    {
                        case 0:
                            id_mb1 = obed.cislo_obeda; break;
                        case 1:
                            id_mb2 = obed.cislo_obeda; break;
                        case 2:
                            id_mb3 = obed.cislo_obeda; break;
                        default:
                            break;
                    }
                    i++;
                }
                if (id_m1 == 0 || id_m2 == 0 || id_m3 == 0 || id_m4 == 0 || id_mb1 == 0 || id_mb2 == 0 || id_mb3 == 0)
                {
                    return;
                }
                foreach (var usr in _context.uzivatele)
                {
                    int uid;
                    string jmeno;
                    string prijmeni;
                    uid = usr.osobni_cislo;
                    jmeno = usr.jmeno;
                    prijmeni = usr.prijmeni;
                    int celkem = 0;
                    int m1 = 0, m2 = 0, m3 = 0, m4 = 0;
                    int mb1 = 0, mb2 = 0, mb3 = 0;
                    foreach (var item in Choice.Where(x => x.obedId.datum_vydeje.Date == dt.Date && x.cislo_uzivatele == usr && x.vydejni_misto.cislo_VM == def_VM.cislo_VM).ToList())
                    {
                        celkem += item.pocet;
                        if (id_m1 == item.obedId.cislo_obeda) { m1 = item.pocet; pocetM1 += item.pocet; }
                        else if (id_m2 == item.obedId.cislo_obeda) { m2 = item.pocet; pocetM2 += item.pocet; }
                        else if (id_m3 == item.obedId.cislo_obeda) { m3 = item.pocet; pocetM3 += item.pocet; }
                        else if (id_m4 == item.obedId.cislo_obeda) { m4 = item.pocet; pocetM4 += item.pocet; }
                        if (id_mb1 == item.obedId.cislo_obeda) { mb1 = item.pocet; pocetMB1 += item.pocet; }
                        else if (id_mb2 == item.obedId.cislo_obeda) { mb2 = item.pocet; pocetMB2 += item.pocet; }
                        else if (id_mb3 == item.obedId.cislo_obeda) { mb3 = item.pocet; pocetMB3 += item.pocet; }
                    }
                    Vyb vyber = new Vyb();
                    vyber.User_id = uid;
                    vyber.jmeno = jmeno;
                    vyber.prijmeni = prijmeni;
                    vyber.celkem = celkem;
                    vyber.m1 = m1;
                    vyber.m2 = m2;
                    vyber.m3 = m3;
                    vyber.m4 = m4;
                    vyber.mb1 = mb1;
                    vyber.mb2 = mb2;
                    vyber.mb3 = mb3;
                    vybery_view.Add(vyber);
                }
            }
        }

        public ListEditModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        public IList<Choice> Choice { get; set; } = default!;

        public async Task OnGetAsync(string cislo_VM , string dt)
        {
            if (_context.vybery != null && _context.uzivatele != null && _context.obedy != null && _context.vydejni_mista != null && _context.polevky != null)
            {
                _context.vybery.Load();
                _context.uzivatele.Load();
                _context.obedy.Load();
                _context.vydejni_mista.Load();
                _context.polevky.Load();
                Choice = await _context.vybery.ToListAsync();
                if (!dt.IsNullOrEmpty())
                {
                    loadedDate = DateTime.Parse(dt);
                }
                else loadedDate = DateTime.Now;
                if (_context.vydejni_mista != null) {
                    if (!cislo_VM.IsNullOrEmpty())
                    {
                        def_VM = _context.vydejni_mista.Where(x => x.cislo_VM.ToString() == cislo_VM).FirstOrDefault();
                    }
                    else def_VM = _context.vydejni_mista.Where(x => x.cislo_VM == 1).FirstOrDefault(); 
                }
                LoadVybery(loadedDate);
            }
        }

        public void OnGetMinusDay(int cislo_VM, string dt)
        {

            loadedDate = DateTime.Parse(dt).AddDays(-1);
            def_VM = _context.vydejni_mista.Where(x => x.cislo_VM == cislo_VM).FirstOrDefault();
            LoadVybery(loadedDate);
        }

        public void OnGetPlusDay(int cislo_VM, string dt)
        {
            loadedDate = DateTime.Parse(dt).AddDays(1);
            def_VM = _context.vydejni_mista.Where(x => x.cislo_VM == cislo_VM).FirstOrDefault();
            LoadVybery(loadedDate);
        }

        public void OnGetZmenaVM(int cislo_VM, string dt)
        {
            if (_context.vydejni_mista != null)
            {
                loadedDate = DateTime.Parse(dt);
                def_VM = _context.vydejni_mista.Where(x => x.cislo_VM != cislo_VM).FirstOrDefault();
                LoadVybery(loadedDate);
            }
        }

        public IActionResult OnGetAddLunch(int id, int usr, int vm, string dt)
        {
            if (_context.vybery != null && _context.obedy != null && _context.uzivatele != null && _context.vydejni_mista != null)
            {
                _context.vybery.Load();
                _context.uzivatele.Load();
                _context.obedy.Load();
                _context.vydejni_mista.Load();
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda == id).FirstOrDefault() ?? new Lunch();
                if (lnch != null)
                {
                    User thisUsr = _context.uzivatele.Where(x => x.osobni_cislo == usr).FirstOrDefault() ?? new User();
                    Choice choice = _context.vybery.Where(x => x.obedId == lnch && x.cislo_uzivatele == thisUsr && x.vydejni_misto.cislo_VM == vm).FirstOrDefault() ?? new Choice();
                    if (choice.cislo_vyberu != 0)
                    {
                        choice.pocet = choice.pocet + 1;
                        choice.vydejni_misto = _context.vydejni_mista.Where(x => x.cislo_VM == vm).FirstOrDefault() ?? new Canteen();
                        _context.vybery.Update(choice);
                        _context.SaveChanges();
                    }
                    else
                    {
                        if (_context.vydejni_mista != null)
                        {
                            choice.pocet += 1;
                            choice.cislo_uzivatele = thisUsr;
                            choice.vydejni_misto = _context.vydejni_mista.Where(x => x.cislo_VM == vm).FirstOrDefault() ?? new Canteen();
                            choice.obedId = lnch;
                            _context.vybery.Add(choice);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            if (_context.vybery != null && _context.uzivatele != null && _context.obedy != null && _context.vydejni_mista != null && _context.polevky != null)
            {
                _context.vybery.Load();
                _context.uzivatele.Load();
                _context.obedy.Load();
                _context.vydejni_mista.Load();
                _context.polevky.Load();
                Choice = _context.vybery.ToList();
                if (!dt.IsNullOrEmpty())
                {
                    loadedDate = DateTime.Parse(dt);
                }
                else loadedDate = DateTime.Now;
                if (_context.vydejni_mista != null)
                {
                    def_VM = _context.vydejni_mista.Where(x => x.cislo_VM == vm).FirstOrDefault();
                }
                LoadVybery(loadedDate);
            }
            return RedirectToPage("",new { dt=loadedDate.ToString("d"), cislo_VM=vm.ToString() });
        }

        public IActionResult OnGetRemoveLunch(int id, int usr, int vm, string dt)
        {
            if (_context.vybery != null && _context.obedy != null && _context.uzivatele != null && _context.vydejni_mista != null)
            {
                _context.vybery.Load();
                _context.uzivatele.Load();
                _context.obedy.Load();
                _context.vydejni_mista.Load();
                Lunch lnch = _context.obedy.Where(ob => ob.cislo_obeda == id).FirstOrDefault() ?? new Lunch();
                if (lnch != null)
                {
                    User thisUsr = _context.uzivatele.Where(x => x.osobni_cislo == usr).FirstOrDefault() ?? new User();
                    Choice choice = _context.vybery.Where(x => x.obedId == lnch && x.cislo_uzivatele == thisUsr && x.vydejni_misto.cislo_VM == vm).FirstOrDefault() ?? new Choice();
                    if (choice != null && choice.pocet > 0)
                    {
                        choice.pocet--;
                        _context.vybery.Update(choice);
                        _context.SaveChanges();
                    }
                }
            }
            if (_context.vybery != null && _context.uzivatele != null && _context.obedy != null && _context.vydejni_mista != null && _context.polevky != null)
            {
                _context.vybery.Load();
                _context.uzivatele.Load();
                _context.obedy.Load();
                _context.vydejni_mista.Load();
                _context.polevky.Load();
                Choice = _context.vybery.ToList();
                if (!dt.IsNullOrEmpty())
                {
                    loadedDate = DateTime.Parse(dt);
                }
                else loadedDate = DateTime.Now;
                if (_context.vydejni_mista != null)
                {
                    def_VM = _context.vydejni_mista.Where(x => x.cislo_VM == vm).FirstOrDefault();
                }
                LoadVybery(loadedDate);
            }
            return RedirectToPage("", new { dt = loadedDate.ToString("d"), cislo_VM = vm.ToString() });
        }
    }
}
