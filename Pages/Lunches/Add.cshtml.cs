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
            string text = "pondìlí 4.3.\r\nCibulová s pórkem 3;9\r\n1. Jihlavský flamendr, dušená rýže  1\r\n2. Hovìzí maso vaøené, koprová omáèka, houskové knedlíky  1;3;7\r\n3. Zelný salát s citronovomedovou zálivkou + kuøecí stripsy  1;3;7\r\n(øepa, mrkev)\r\n4. Nudle s tvarohem, ovoce 1;3;7\r\n\r\núterý   5.3.\r\nKuøecí vývar s masem a nudlemi 1;9\r\n1. Vepøová kýta na houbách, italské tìstoviny  1;3\r\n2. Kuøecí steak v tìstíèku, vaøené brambory, tatarská omáèka  1;3;7;10\r\n3. Zeleninový salát s mozzarellou  7\r\n(mix sezonní zeleniny, olivový olej)\r\n4. Zapeèené francouzské brambory s uzeným masem, okurka 1;3;7\r\n\r\nstøeda  6.3.\r\nÈoèková s rajèaty 1\r\n1. Pøírodní kuøecí prsíèka, dušená rýže  1\r\n2. Opeèená jitrnice, kysané zelí, vaøené brambory  1;7\r\n3. Labužnický salát s drùbežími játry  7\r\n(mix sezonní zeleniny, keèup, jogurt)\r\n4. Kynuté knedlíky s povidly a vanilkovým pøelivem sypané mákem  1;3;7\r\n\r\nètvrtek 7.3.\r\nZeleninová s kuskusem 1;9\r\n1. Hovìzí guláš s cibulí, houskové knedlíky  1;3;7\r\n2. Rizoto z tarhonì s kuøecím masem sypané sýrem, okurka 1;7\r\n3. Farfalle (tìstoviny) s tuòákem  1;3;4\r\n(kukuøice, paprika, rajèata, cibule, vejce, majonéza)\r\n4. Fazole chilli con carne, chléb  1\r\n\r\npátek   8.3.\r\nFrankfurtská s uzeninou 1;7\r\n1. Pøírodní sekaný øízek, vaøené brambory, ïábelská omáèka 1;3;7;10\r\n2. Vepøové žebírko dle pražského uzenáøe, dušená rýže  1;3;7\r\n3. Salát z restované karotky s kuøecím masem  7\r\n(zakysaná smetana, èesnek, rozinky)\r\n4. Tìstoviny s kuøecím masem, brokolicí a sýrem  1;3;7";
            int err = lnchctrl.parseText(text);
            return Page();
        }
    }  
}
