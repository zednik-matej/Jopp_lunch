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

namespace Jopp_lunch.Pages.Canteens
{
    [Authorize(Roles = "admin,editor")]
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
        public Canteen Canteen { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.vydejni_mista == null || Canteen == null)
            {
                return Page();
            }

            _context.vydejni_mista.Add(Canteen);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
