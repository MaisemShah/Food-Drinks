using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using D.I._Tech_Night_School.Data;

namespace D.I._Tech_Night_School.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly D.I._Tech_Night_School.Data.ApplicationDbContext _context;

        public IndexModel(D.I._Tech_Night_School.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            Food = await _context.Food
                .Include(f => f.Drinks).ToListAsync();
        }
    }
}
