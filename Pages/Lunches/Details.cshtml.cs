using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Jopp_lunch.Data;
using Jopp_lunch.Model.DbEntities;

namespace Jopp_lunch.Pages.Lunches
{
    public class DetailsModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public DetailsModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

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
    }
}
