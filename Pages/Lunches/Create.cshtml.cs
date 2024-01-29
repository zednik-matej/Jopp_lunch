using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Jopp_lunch.Data;
using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Jopp_lunch.Pages.Lunches
{
    [Authorize(Roles = "editor,admin,chef")]
    public class CreateModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public CreateModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lunch Lunch { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.obedy == null || _context.polevky == null || Lunch == null)
            {
                return Page();
            }
            else
            {
                Soup soup = await _context.polevky
                    .Where(p => p.datum_vydeje.Date == Lunch.datum_vydeje.Date)
                    .FirstOrDefaultAsync() ?? new Soup();

                if(soup.popis_obeda!=null)Lunch.cislo_polevky = soup;
                else return Page();//Error prvne zalozit polevku!
                Lunch.datum_pridani = DateTime.Now;
                Lunch.datum_editace = DateTime.Now;

                _context.obedy.Add(Lunch);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }
}
