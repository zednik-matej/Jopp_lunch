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
    public class ListModel : PageModel
    {
        private readonly Jopp_lunch.Data.CanteenContext _context;

        public ListModel(Jopp_lunch.Data.CanteenContext context)
        {
            _context = context;
        }

        public IList<Choice> Choice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.vybery != null)
            {
                Choice = await _context.vybery.ToListAsync();
            }
        }
    }
}
