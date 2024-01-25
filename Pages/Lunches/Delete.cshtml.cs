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

namespace Jopp_lunch.Pages.Lunches
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
      public Lunch Lunch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.obedy == null)
            {
                return NotFound();
            }

            var lunch = await _context.obedy.FirstOrDefaultAsync(m => m.cislo_obeda == id);

            if (lunch == null)
            {
                return NotFound();
            }
            else 
            {
                Lunch = lunch;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.obedy == null)
            {
                return NotFound();
            }
            var lunch = await _context.obedy.FindAsync(id);

            if (lunch != null)
            {
                Lunch = lunch;
                _context.obedy.Remove(Lunch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
