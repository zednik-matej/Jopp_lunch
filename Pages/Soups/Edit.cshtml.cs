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

namespace Jopp_lunch.Pages.Soups
{
    public class EditModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public EditModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Soup Soup { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.polevky == null)
            {
                return NotFound();
            }

            var soup =  await _context.polevky.FirstOrDefaultAsync(m => m.polevkaId == id);
            if (soup == null)
            {
                return NotFound();
            }
            Soup = soup;
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

            _context.Attach(Soup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoupExists(Soup.polevkaId))
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

        private bool SoupExists(int id)
        {
          return (_context.polevky?.Any(e => e.polevkaId == id)).GetValueOrDefault();
        }
    }
}
