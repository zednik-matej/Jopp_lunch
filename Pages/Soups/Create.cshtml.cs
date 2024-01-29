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

namespace Jopp_lunch.Pages.Soups
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
        public Soup Soup { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.polevky == null || Soup == null)
            {
                return Page();
            }

            Soup.datum_pridani = DateTime.Now;
            Soup.datum_editace = DateTime.Now;

            _context.polevky.Add(Soup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
