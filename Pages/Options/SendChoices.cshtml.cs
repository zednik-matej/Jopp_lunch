using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PublicHoliday;
using Aspose.Pdf;
using Jopp_lunch.Model.DbEntities;

namespace Jopp_lunch.Pages.Options
{
    public class SendChoicesModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;
        int id_m1 = 0, id_m2 = 0, id_m3 = 0, id_m4 = 0;
        int id_mb1 = 0, id_mb2 = 0, id_mb3 = 0;

        public SendChoicesModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        public void LoadPDFPacked(string vydejni_misto, string datum_vydeje, int celkem, int mb1, int mb2, int mb3, string pmb1, string pmb2, string pmb3)
        {
            //Aspose.Pdf.Document pdf = new Aspose.Pdf.Document("C:/Users/zedni/objednavka_template_packed.pdf");
            Aspose.Pdf.Document pdf = new Aspose.Pdf.Document("../upload/templates/objednavka_template_packed.pdf");
            //..\upload\
            // instantiate TextFragment Absorber object
            Aspose.Pdf.Text.TextFragmentAbsorber TextFragmentAbsorberAddress = new Aspose.Pdf.Text.TextFragmentAbsorber();

            // search text within page bound
            TextFragmentAbsorberAddress.TextSearchOptions.LimitToPageBounds = true;

            // search text from first page of PDF file
            pdf.Pages[1].Accept(TextFragmentAbsorberAddress);

            // iterate through individual TextFragment
            foreach (Aspose.Pdf.Text.TextFragment tf in TextFragmentAbsorberAddress.TextFragments)
            {
                // update text to blank characters
                if (String.Equals(tf.Text, "Závod: ")) tf.Text = "Závod: " + vydejni_misto;
                if (String.Equals(tf.Text, "datum_vydeje"))
                {
                    tf.Text = datum_vydeje;
                }
                if (String.Equals(tf.Text, "pol")) tf.Text = celkem.ToString();
                if (String.Equals(tf.Text, "ma")) tf.Text = pmb1;
                if (String.Equals(tf.Text, "m1")) tf.Text = mb1.ToString();
                if (String.Equals(tf.Text, "mb")) tf.Text = pmb2;
                if (String.Equals(tf.Text, "m2")) tf.Text = mb2.ToString();
                if (String.Equals(tf.Text, "mc")) tf.Text = pmb3;
                if (String.Equals(tf.Text, "m3")) tf.Text = mb3.ToString();
                if (String.Equals(tf.Text, "atum"))
                {
                    tf.Text = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");
                }
            }

            // save updated PDF file after text replace
            pdf.Save("../upload/sent_files/packed_sent_"+vydejni_misto+"_"+ DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".pdf");
        }

        public void LoadPDFHot(string vydejni_misto, string datum_vydeje, int celkem, int m1,int m2, int m3, int m4, string ppol, string pm1, string pm2, string pm3, string pm4)
        {
            //Aspose.Pdf.Document pdf = new Aspose.Pdf.Document("C:/Users/zedni/objednavka_template.pdf");
            Aspose.Pdf.Document pdf = new Aspose.Pdf.Document("../upload/templates/objednavka_template.pdf");
            //..\upload\
            // instantiate TextFragment Absorber object
            Aspose.Pdf.Text.TextFragmentAbsorber TextFragmentAbsorberAddress = new Aspose.Pdf.Text.TextFragmentAbsorber();

            // search text within page bound
            TextFragmentAbsorberAddress.TextSearchOptions.LimitToPageBounds = true;

            // search text from first page of PDF file
            pdf.Pages[1].Accept(TextFragmentAbsorberAddress);

            // iterate through individual TextFragment
            foreach (Aspose.Pdf.Text.TextFragment tf in TextFragmentAbsorberAddress.TextFragments)
            {
                // update text to blank characters
                if (String.Equals(tf.Text, "Závod: "))tf.Text = "Závod: " + vydejni_misto;
                if (String.Equals(tf.Text, "datum_vydeje"))
                { 
                    tf.Text = datum_vydeje; 
                }
                if (String.Equals(tf.Text, "pp")) tf.Text = ppol;
                if (String.Equals(tf.Text, "pol")) tf.Text = celkem.ToString();
                if (String.Equals(tf.Text, "ma")) tf.Text = pm1;
                if (String.Equals(tf.Text, "m1")) tf.Text = m1.ToString();
                if (String.Equals(tf.Text, "mb")) tf.Text = pm2;
                if (String.Equals(tf.Text, "m2") )tf.Text = m2.ToString();
                if (String.Equals(tf.Text, "mc")) tf.Text = pm3;
                if (String.Equals(tf.Text, "m3")) tf.Text = m3.ToString();
                if (String.Equals(tf.Text, "md")) tf.Text = pm4;
                if (String.Equals(tf.Text, "m4")) tf.Text = m4.ToString();
                if (String.Equals(tf.Text, "atum"))
                {
                    tf.Text = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");
                }
            }

            // save updated PDF file after text replace
            pdf.Save("../upload/sent_files/hot_sent_"+vydejni_misto+"_"+ DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".pdf");
        }

        public void LoadHot(int VM)
        {
            if (_context != null)
            {
                if (_context.vybery != null || _context.obedy != null || _context.polevky != null)
                {
                    CzechRepublicPublicHoliday czhol = new CzechRepublicPublicHoliday();
                    DateTime dt = DateTime.Now;
                    DateTime firstWork = czhol.NextWorkingDayNotSameDay(dt);
                    DateTime secondWork = czhol.NextWorkingDayNotSameDay(firstWork);

                    _context.obedy.Load();
                    _context.polevky.Load();
                    _context.vybery.Load();
                    int celkem = _context.vybery.Where(x => x.obedId.forma == 0 && x.obedId.datum_vydeje.Date == firstWork.Date && x.vydejni_misto.cislo_VM == VM).ToList().Count();
                    string popis_pol = "";
                    string m1 = "", m2 = "", m3 = "", m4 = "";
                    int pm1 = 0, pm2 = 0, pm3 = 0, pm4 = 0;
                    int i = 1;
                    foreach (var lns in _context.obedy.Where(x => x.datum_vydeje.Date == firstWork.Date && x.forma == 0))
                    {
                        if (i == 1) m1 = lns.popis_obeda;
                        else if (i == 2) m2 = lns.popis_obeda;
                        else if (i == 3) m3 = lns.popis_obeda;
                        else m4 = lns.popis_obeda;
                        i++;
                    }
                    LoadHotID(firstWork);
                    foreach (var item in _context.vybery.Where(x => x.obedId.datum_vydeje.Date == firstWork.Date && x.obedId.forma == 0 && x.vydejni_misto.cislo_VM == VM).ToList())
                    {
                        if (id_m1 == item.obedId.cislo_obeda) { pm1 += item.pocet; }
                        else if (id_m2 == item.obedId.cislo_obeda) { pm2 += item.pocet; }
                        else if (id_m3 == item.obedId.cislo_obeda) { pm3 += item.pocet; }
                        else if (id_m4 == item.obedId.cislo_obeda) { pm4 += item.pocet; }
                    }
                    string vyd_mis = _context.vydejni_mista.Where(x => x.cislo_VM == VM).FirstOrDefault().nazev;
                    LoadPDFHot(vyd_mis, firstWork.ToString("dd.MM.yyyy"), celkem, pm1, pm2, pm3, pm4, popis_pol, m1, m2, m3, m4);
                }
            }
        }


        public void LoadHotID(DateTime dt)
        {
            if (_context != null && _context.obedy != null)
            {
                
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
            }
        }

        public void LoadPackedID(DateTime dt)
        {
            if (_context != null && _context.obedy != null)
            {

                int i = 0;
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
            }
        }

        public void LoadPacked(int VM)
        {
            if (_context != null)
            {
                if (_context.vybery != null || _context.obedy != null || _context.polevky != null)
                {
                    CzechRepublicPublicHoliday czhol = new CzechRepublicPublicHoliday();
                    DateTime dt = DateTime.Now;
                    DateTime firstWork = czhol.NextWorkingDayNotSameDay(dt);
                    DateTime secondWork = czhol.NextWorkingDayNotSameDay(firstWork);

                    _context.obedy.Load();
                    _context.polevky.Load();
                    _context.vybery.Load();
                    int celkem = _context.vybery.Where(x => x.obedId.forma == 1 && x.obedId.datum_vydeje.Date == secondWork.Date && x.vydejni_misto.cislo_VM == VM).ToList().Count();
                    int i = 1;
                    string mb1 = "", mb2 = "", mb3 = "";
                    int pmb1 = 0, pmb2 = 0, pmb3 = 0;
                    i = 1;
                    foreach (var lns in _context.obedy.Where(x => x.datum_vydeje.Date == secondWork.Date && x.forma == 1))
                    {
                        if (i == 1) mb1 = lns.popis_obeda;
                        else if (i == 2) mb2 = lns.popis_obeda;
                        else mb3 = lns.popis_obeda;
                        i++;
                    }
                    LoadPackedID(secondWork);
                    foreach (var item in _context.vybery.Where(x => x.obedId.datum_vydeje.Date == secondWork.Date && x.obedId.forma == 1 && x.vydejni_misto.cislo_VM == VM).ToList())
                    {
                        if (id_mb1 == item.obedId.cislo_obeda) { pmb1 += item.pocet; }
                        else if (id_mb2 == item.obedId.cislo_obeda) { pmb2 += item.pocet; }
                        else if (id_mb3 == item.obedId.cislo_obeda) { pmb3 += item.pocet; }
                    }
                    string vyd_mis = _context.vydejni_mista.Where(x => x.cislo_VM == VM).FirstOrDefault().nazev;
                    LoadPDFPacked(vyd_mis, secondWork.ToString("dd.MM.yyyy"), celkem, pmb1, pmb2, pmb3, mb1, mb2, mb3);
                }
            }
        }

        public void OnGet()
        {
            LoadPacked(1);
            LoadPacked(2);
            LoadHot(1);
            LoadHot(2);
        }
    }
}
