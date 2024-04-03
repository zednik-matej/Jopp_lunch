using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Jopp_lunch.Pages.Users
{
    public class EditRoleModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;
        private readonly UserManager<User> _userManager;

        public EditRoleModel(Jopp_lunch.Data.CanteenContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public User ThisUsr { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.uzivatele == null)
            {
                return NotFound();
            }
            //var usr = await _userManager.FindByIdAsync(id);
            var usr = await _context.uzivatele.Where(x=> x.UserName==id).FirstOrDefaultAsync();
            if (usr == null)
            {
                return NotFound();
            }
            ThisUsr = usr;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.uzivatele==null)
            {
                return Page();
            }

            //_userManager.Attach(ThisUsr).State = EntityState.Modified;
            //User usr = await _context.uzivatele.FirstOrDefaultAsync(m => m.osobni_cislo == ThisUsr.osobni_cislo) ?? new User();
            _context.uzivatele.Update(ThisUsr);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(ThisUsr.UserName))
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

        private bool UserExists(string id)
        {
            return (_context.uzivatele?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
