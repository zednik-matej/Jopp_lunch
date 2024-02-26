using Jopp_lunch.Controllers;
using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Jopp_lunch.Pages.Lunches
{
    public class AddModel : PageModel
    {
        //public string htmltext { get; set; } = string.Empty;
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public AddModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        public IActionResult OnGetParseText()
        {
            LunchesController lnchctrl = new LunchesController(_context);
            string text = "pondìlí 26.2.\r\nHovìzí se zeleninou a tìstovinou 1;9\r\n1. Vepøová kýta na smetanì, houskové knedlíky  1;3;7;10\r\n2. Èoèka na kyselo, opeèený gothaj, vaøené vejce, chléb, okurka 1;3\r\n3. Salát coleslaw + kuøecí stripsy  1;3;7\r\n(zelí, mrkev, majonéza, cibule, bílý jogurt)\r\n4. Krupicová kaše sypaná kakaem a cukrem, ovoce 1;7\r\n\r\núterý   27.2.\r\nBramborová 1;9\r\n1. Špagety s vepøovým masem sypané sýrem  1;3;7\r\n2. Kuøecí prsíèka na žampionech, dušená rýže  1\r\n3. Feferonový salát  7\r\n(feferony, kapie, steril.paprikový salát)\r\n4. Cmunda po kaplicku (uzené maso, zelí)  1;3;7\r\n\r\nstøeda  28.2.\r\nSekyrková s masem a kroupami 1;9\r\n1. Vepøová kýta po španìlsku, dušená rýže  1;3;7\r\n2. Kuøecí nudlièky, gnocchi s bazalkovým pestem sypané parmezánem  1;3;7\r\n3. Kuskus se sekanými olivami a kuøecím masem  1\r\n(èesnek)\r\n4. Jablková žemlovka s tvarohem a rozinkami  1;3;7\r\n\r\nètvrtek 29.2.\r\nKvìtáková 1\r\n1. Peèené krùtí maso, èervené zelí, bramborové knedlíky  1;3;7\r\n2. Rizoto s vepøovým masem sypané sýrem, okurka 7\r\n3. Øecký salát s olivami  7\r\n(èervená cibule, rajèata, okurky, olivy, oregano, sýr feta)\r\n4. Zeleninové leèo s uzeninou, chléb  1;3\r\n\r\npátek   1.3.\r\nBoršè 1;7\r\n1. Sekaný øízek se sýrem, vaøené brambory, okurka 1;3;7\r\n2. Kuøecí špalíky na hoøèici, italské tìstoviny  1;3;10\r\n3. Luštìninový salát s vejcem  3\r\n(cizrna, èervená èoèka, fazole)\r\n4. Zabijaèkový guláš, chléb  1";
            int err = lnchctrl.parseText(text);
            return Page();
        }
    }  
}
