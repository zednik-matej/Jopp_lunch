using Jopp_lunch.Data;
using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Jopp_lunch.Pages.Users
{
    [Authorize(Roles = "admin, editor")]
    public class DeleteModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public DeleteModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User ThisUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.uzivatele == null)
            {
                return NotFound();
            }

            var usr = await _context.uzivatele.FirstOrDefaultAsync(m => m.osobni_cislo == id);

            if (usr == null)
            {
                return NotFound();
            }
            else
            {
                ThisUser = usr;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.uzivatele == null)
            {
                return NotFound();
            }
            var usr = await _context.uzivatele.FirstOrDefaultAsync(m => m.osobni_cislo == id);

            if (usr != null)
            {
                ThisUser = usr;
                _context.uzivatele.Remove(ThisUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
