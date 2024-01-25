using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Jopp_lunch.Data;
using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authorization;

namespace Jopp_lunch.Pages.Soups
{
    [Authorize(Roles = "editor,admin,chef")]
    public class DeleteModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public DeleteModel(Jopp_lunch.Data.CanteenContext context)
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

            var soup = await _context.polevky.FirstOrDefaultAsync(m => m.polevkaId == id);

            if (soup == null)
            {
                return NotFound();
            }
            else 
            {
                Soup = soup;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.polevky == null)
            {
                return NotFound();
            }
            var soup = await _context.polevky.FindAsync(id);

            if (soup != null)
            {
                Soup = soup;
                _context.polevky.Remove(Soup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
