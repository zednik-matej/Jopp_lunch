using Jopp_lunch.Model.DbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Jopp_lunch.Pages.Users
{
    [Authorize(Roles = "admin,editor")]
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
            if (id == null || _context.uzivatele == null ||_context.vydejni_mista == null)
            {
                return NotFound();
            }
            var usr = await _userManager.FindByNameAsync(id);
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
            if (!ModelState.IsValid || _context.uzivatele==null || _context.vydejni_mista == null)
            {
                return Page();
            }
            //User usr = await _context.uzivatele.FirstOrDefaultAsync(m => m.osobni_cislo == ThisUsr.osobni_cislo) ?? new User();
            if (ThisUsr.vychozi_VM != null)
            {
                ThisUsr.vychozi_VM = _context.vydejni_mista.Where(x => x.cislo_VM == ThisUsr.vychozi_VM.cislo_VM).FirstOrDefault();
            }
            try
            {
                await _userManager.UpdateAsync(ThisUsr);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ThisUsr.UserName==null || await _userManager.FindByNameAsync(ThisUsr.UserName) == null)
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
    }
}
