using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Jopp_lunch.Data;
using Jopp_lunch.Model.DbEntities;
using SQLitePCL;
using Microsoft.AspNetCore.Authorization;

namespace Jopp_lunch.Pages.Choices
{
    [Authorize(Roles = "admin,editor,chef")]
    public class ListHotModel : PageModel
    {
        public class Vyb
        {
            public int User_id;
            public string? jmeno;
            public string? prijmeni;
            public int celkem;
            public string? m1, m2, m3, m4;

        }

        public int pocetM1;
        public int pocetM2;
        public int pocetM3;
        public int pocetM4;
        public List<Vyb> vybery_view { get; set; } = new List<Vyb>();
        public DateTime loadedDate;
        public Canteen def_VM { get; set; } = new Canteen();
        public IList<Lunch> Lunch { get; set; } = default!;

        private readonly Jopp_lunch.Data.CanteenContext _context;

        public void LoadVybery(DateTime dt)
        {
            pocetM1 = 0;
            pocetM2 = 0;
            pocetM3 = 0;
            pocetM4 = 0;
            if (_context.uzivatele != null && _context.obedy != null && _context.vybery != null && _context.vydejni_mista != null)
            {
                _context.uzivatele.Load();
                _context.obedy.Load();
                _context.vybery.Load();
                _context.vydejni_mista.Load();
                Choice = _context.vybery.ToList();
                Lunch = _context.obedy
                    .Where(x => x.datum_vydeje.Date == dt.Date && x.forma == 0 /*&& x.datum_vydeje.Date <= endOfWeek.Date*/)
                    .OrderBy(o => o.datum_vydeje)
                    .ToList();
                vybery_view = new List<Vyb>();
                int id_m1 = 0, id_m2 = 0, id_m3 = 0, id_m4 = 0;
                int i=0;
                foreach(var obed in _context.obedy.Where(o=>o.datum_vydeje.Date==dt.Date && o.forma == 0).OrderBy(o=>o.cislo_obeda).ToList())
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
                if(id_m1 == 0 || id_m2 == 0 || id_m3 == 0 || id_m4 == 0)
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
                    foreach(var item in Choice.Where(x=>x.obedId.datum_vydeje.Date == dt.Date && x.cislo_uzivatele == usr && x.obedId.forma==0 && x.vydejni_misto.cislo_VM== def_VM.cislo_VM).ToList())
                    {
                        celkem+=item.pocet;
                        if (item.obedId.forma == 0)
                        {
                            // tepla
                            if (id_m1 == item.obedId.cislo_obeda) { m1 = item.pocet; pocetM1 += item.pocet; }
                            else if (id_m2 == item.obedId.cislo_obeda) { m2 = item.pocet; pocetM2 += item.pocet; }
                            else if (id_m3 == item.obedId.cislo_obeda) { m3 = item.pocet; pocetM3 += item.pocet; }
                            else if (id_m4 == item.obedId.cislo_obeda) { m4 = item.pocet; pocetM4 += item.pocet; }
                        }
                    }
                    if (celkem > 0)
                    {
                        Vyb vyber = new Vyb();
                        vyber.User_id = uid;
                        vyber.jmeno = jmeno;
                        vyber.prijmeni = prijmeni;
                        vyber.celkem = celkem;
                        vyber.m1 = "M1:" + m1.ToString();
                        vyber.m2 = "M2:" + m2.ToString();
                        vyber.m3 = "M3:" + m3.ToString();
                        vyber.m4 = "M4:" + m4.ToString();
                        vybery_view.Add(vyber);
                    }
                }
            }
        }

        public ListHotModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;           
        }

        public IList<Choice> Choice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.vybery != null && _context.uzivatele!=null && _context.obedy!=null && _context.vydejni_mista != null && _context.polevky != null)
            {
                _context.vybery.Load();
                _context.uzivatele.Load();
                _context.obedy.Load();
                _context.vydejni_mista.Load();
                _context.polevky.Load();
                Choice = await _context.vybery.ToListAsync();
                loadedDate = DateTime.Now;
                if (_context.vydejni_mista != null) def_VM = _context.vydejni_mista.Where(x => x.cislo_VM == 1).FirstOrDefault();
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
    }
}
