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

namespace Jopp_lunch.Pages.Canteens
{
    [Authorize(Roles = "admin,editor")]
    public class EditModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public EditModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Canteen Canteen { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.vydejni_mista == null)
            {
                return NotFound();
            }

            var canteen =  await _context.vydejni_mista.FirstOrDefaultAsync(m => m.cislo_VM == id);
            if (canteen == null)
            {
                return NotFound();
            }
            Canteen = canteen;
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

            _context.Attach(Canteen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanteenExists(Canteen.cislo_VM))
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

        private bool CanteenExists(int id)
        {
          return (_context.vydejni_mista?.Any(e => e.cislo_VM == id)).GetValueOrDefault();
        }
    }
}
