using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;

namespace Jopp_lunch.Controllers
{
    public class LunchesController : Controller
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public LunchesController(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        public int AddSoups(string desc, DateTime issueDate)
        {
            if (_context==null || _context.polevky == null || _context.obedy == null) { return -1; }
            if (_context.polevky
                .Where(x => x.datum_vydeje.Date == issueDate.Date)
                .FirstOrDefault() != null) 
            {
                return -1;
            }
            else 
            {
                Soup sp = new Soup();
                sp.datum_vydeje = issueDate;
                sp.popis_obeda = desc;
                sp.datum_pridani = DateTime.Now;
                sp.datum_editace = DateTime.Now;
                _context.polevky.Add(sp);
                _context.SaveChanges();
                return 0;
            }
        }

        public int AddLunch(string desc, DateTime issueDate)
        {
            if(_context == null || _context.polevky==null||_context.obedy==null) { return -1; }
            if (_context.polevky
                .Where(x => x.datum_vydeje.Date == issueDate.Date)
                .FirstOrDefault() == null)
            {
                return -1;
            }
            else
            {
                Soup sp = _context.polevky
                .Where(x => x.datum_vydeje.Date == issueDate.Date)
                .FirstOrDefault() ?? new Soup();
                Lunch lnch = new Lunch();
                lnch.cislo_polevky = sp;
                lnch.datum_vydeje = issueDate;
                lnch.popis_obeda = desc;
                lnch.datum_pridani = DateTime.Now;
                lnch.datum_editace = DateTime.Now;
                _context.obedy.Add(lnch);
                _context.SaveChanges();
                return 0;
            }
        }

        public int parseText(string text)
        {
            if(text == null || text.Length == 0) { return -1; }
            var reader = new StringReader(text);
            string datum_vydeje="";
            string lastline = "";
            string prelastline = "";
            DateTime issueDate = DateTime.Now;
            int err;
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                if (line.Contains("pondělí") || line.Contains("úterý") || line.Contains("středa") || line.Contains("čtvrtek") || line.Contains("pátek"))
                {
                    datum_vydeje = line.Substring(8);
                    datum_vydeje += DateTime.Now.Year.ToString();
                    issueDate = DateTime.Parse(datum_vydeje);
                }
                if (!String.IsNullOrEmpty(datum_vydeje)&& !String.IsNullOrEmpty(line)&& line.Length>3)
                {
                    if (line[0] == '1')
                    {
                        err = AddSoups(lastline, issueDate);
                        if (err != 0) continue;
                        err = AddLunch(line.Substring(3), issueDate);
                        if (err != 0) continue;
                    }
                     if(line[0] == '2')
                    {
                        err = AddLunch(line.Substring(3), issueDate);
                        if (err != 0) continue;
                    }
                    if (line[0] == '3')
                    {
                        prelastline = line.Substring(3);
                    }
                    if(line[0] == '4')
                    {
                        err = AddLunch(prelastline+lastline, issueDate);
                        if (err != 0) continue;
                        err = AddLunch(line.Substring(3), issueDate);
                        if (err != 0) continue;
                    }
                    lastline = line;
                }
            }
            
            return 0;
        }
    }
}
