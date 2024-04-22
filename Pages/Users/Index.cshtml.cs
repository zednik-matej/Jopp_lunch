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

namespace Jopp_lunch.Pages.Users
{
    [Authorize(Roles = "admin, editor")]
    public class UsersModel : PageModel
    {
        private readonly CanteenContext _context;

        public UsersModel(CanteenContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; } = default!;

        public async Task OnGetAsync()
        {
            
            if (_context.uzivatele != null && _context.vydejni_mista != null)
            {
                _context.uzivatele.Load();
                _context.vydejni_mista.Load();
                Users = await _context.uzivatele.ToListAsync();
            }
        }
    }
}
