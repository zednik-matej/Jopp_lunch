using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Jopp_lunch.Data;
using Jopp_lunch.Model.DbEntities;

namespace Jopp_lunch.Pages.Choices
{
    public class DetailModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public DetailModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

      public Choice Choice { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.vybery == null)
            {
                return NotFound();
            }

            var choice = await _context.vybery.FirstOrDefaultAsync(m => m.cislo_vyberu == id);
            if (choice == null)
            {
                return NotFound();
            }
            else 
            {
                Choice = choice;
            }
            return Page();
        }
    }
}
