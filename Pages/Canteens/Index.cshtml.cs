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
using Microsoft.AspNetCore.Identity;

namespace Jopp_lunch.Pages.Canteens
{
    [Authorize(Roles = "admin,editor")]
    public class IndexModel : PageModel
    {

        private readonly Jopp_lunch.Data.CanteenContext _context;

        public IndexModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        public IList<Canteen> Canteen { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.vydejni_mista != null)
            {
                Canteen = await _context.vydejni_mista.ToListAsync();
            }
        }
    }
}
