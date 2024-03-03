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
            string text = "pond�l� 4.3.\r\nCibulov� s p�rkem 3;9\r\n1. Jihlavsk� flamendr, du�en� r��e  1\r\n2. Hov�z� maso va�en�, koprov� om��ka, houskov� knedl�ky  1;3;7\r\n3. Zeln� sal�t s citronovomedovou z�livkou + ku�ec� stripsy  1;3;7\r\n(�epa, mrkev)\r\n4. Nudle s tvarohem, ovoce 1;3;7\r\n\r\n�ter�   5.3.\r\nKu�ec� v�var s masem a nudlemi 1;9\r\n1. Vep�ov� k�ta na houb�ch, italsk� t�stoviny  1;3\r\n2. Ku�ec� steak v t�st��ku, va�en� brambory, tatarsk� om��ka  1;3;7;10\r\n3. Zeleninov� sal�t s mozzarellou  7\r\n(mix sezonn� zeleniny, olivov� olej)\r\n4. Zape�en� francouzsk� brambory s uzen�m masem, okurka 1;3;7\r\n\r\nst�eda  6.3.\r\n�o�kov� s raj�aty 1\r\n1. P��rodn� ku�ec� prs��ka, du�en� r��e  1\r\n2. Ope�en� jitrnice, kysan� zel�, va�en� brambory  1;7\r\n3. Labu�nick� sal�t s dr�be��mi j�try  7\r\n(mix sezonn� zeleniny, ke�up, jogurt)\r\n4. Kynut� knedl�ky s povidly a vanilkov�m p�elivem sypan� m�kem  1;3;7\r\n\r\n�tvrtek 7.3.\r\nZeleninov� s kuskusem 1;9\r\n1. Hov�z� gul� s cibul�, houskov� knedl�ky  1;3;7\r\n2. Rizoto z tarhon� s ku�ec�m masem sypan� s�rem, okurka 1;7\r\n3. Farfalle (t�stoviny) s tu��kem  1;3;4\r\n(kuku�ice, paprika, raj�ata, cibule, vejce, majon�za)\r\n4. Fazole chilli con carne, chl�b  1\r\n\r\np�tek   8.3.\r\nFrankfurtsk� s uzeninou 1;7\r\n1. P��rodn� sekan� ��zek, va�en� brambory, ��belsk� om��ka 1;3;7;10\r\n2. Vep�ov� �eb�rko dle pra�sk�ho uzen��e, du�en� r��e  1;3;7\r\n3. Sal�t z restovan� karotky s ku�ec�m masem  7\r\n(zakysan� smetana, �esnek, rozinky)\r\n4. T�stoviny s ku�ec�m masem, brokolic� a s�rem  1;3;7";
            int err = lnchctrl.parseText(text);
            return Page();
        }
    }  
}
