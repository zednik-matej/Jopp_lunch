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

namespace Jopp_lunch.Pages.Canteens
{
    [Authorize(Roles = "admin")]
    public class DetailsModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public DetailsModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

      public Canteen Canteen { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.vydejni_mista == null)
            {
                return NotFound();
            }

            var canteen = await _context.vydejni_mista.FirstOrDefaultAsync(m => m.cislo_VM == id);
            if (canteen == null)
            {
                return NotFound();
            }
            else 
            {
                Canteen = canteen;
            }
            return Page();
        }
    }
}
