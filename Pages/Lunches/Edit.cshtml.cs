using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jopp_lunch.Data;
using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authorization;

namespace Jopp_lunch.Pages.Lunches
{
    [Authorize(Roles = "editor,admin,chef")]
    public class EditModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public EditModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lunch Lunch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.obedy == null)
            {
                return NotFound();
            }

            var lunch =  await _context.obedy.FirstOrDefaultAsync(m => m.cislo_obeda == id);
            if (lunch == null)
            {
                return NotFound();
            }
            Lunch = lunch;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lunch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LunchExists(Lunch.cislo_obeda))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LunchExists(int id)
        {
          return (_context.obedy?.Any(e => e.cislo_obeda == id)).GetValueOrDefault();
        }
    }
}
