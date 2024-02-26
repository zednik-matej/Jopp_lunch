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
            string text = "pond�l� 26.2.\r\nHov�z� se zeleninou a t�stovinou 1;9\r\n1. Vep�ov� k�ta na smetan�, houskov� knedl�ky  1;3;7;10\r\n2. �o�ka na kyselo, ope�en� gothaj, va�en� vejce, chl�b, okurka 1;3\r\n3. Sal�t coleslaw + ku�ec� stripsy  1;3;7\r\n(zel�, mrkev, majon�za, cibule, b�l� jogurt)\r\n4. Krupicov� ka�e sypan� kakaem a cukrem, ovoce 1;7\r\n\r\n�ter�   27.2.\r\nBramborov� 1;9\r\n1. �pagety s vep�ov�m masem sypan� s�rem  1;3;7\r\n2. Ku�ec� prs��ka na �ampionech, du�en� r��e  1\r\n3. Feferonov� sal�t  7\r\n(feferony, kapie, steril.paprikov� sal�t)\r\n4. Cmunda po kaplicku (uzen� maso, zel�)  1;3;7\r\n\r\nst�eda  28.2.\r\nSekyrkov� s masem a kroupami 1;9\r\n1. Vep�ov� k�ta po �pan�lsku, du�en� r��e  1;3;7\r\n2. Ku�ec� nudli�ky, gnocchi s bazalkov�m pestem sypan� parmez�nem  1;3;7\r\n3. Kuskus se sekan�mi olivami a ku�ec�m masem  1\r\n(�esnek)\r\n4. Jablkov� �emlovka s tvarohem a rozinkami  1;3;7\r\n\r\n�tvrtek 29.2.\r\nKv�t�kov� 1\r\n1. Pe�en� kr�t� maso, �erven� zel�, bramborov� knedl�ky  1;3;7\r\n2. Rizoto s vep�ov�m masem sypan� s�rem, okurka 7\r\n3. �eck� sal�t s olivami  7\r\n(�erven� cibule, raj�ata, okurky, olivy, oregano, s�r feta)\r\n4. Zeleninov� le�o s uzeninou, chl�b  1;3\r\n\r\np�tek   1.3.\r\nBor�� 1;7\r\n1. Sekan� ��zek se s�rem, va�en� brambory, okurka 1;3;7\r\n2. Ku�ec� �pal�ky na ho��ici, italsk� t�stoviny  1;3;10\r\n3. Lu�t�ninov� sal�t s vejcem  3\r\n(cizrna, �erven� �o�ka, fazole)\r\n4. Zabija�kov� gul�, chl�b  1";
            int err = lnchctrl.parseText(text);
            return Page();
        }
    }  
}
