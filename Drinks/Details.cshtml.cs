using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using D.I._Tech_Night_School.Data;

namespace D.I._Tech_Night_School.Pages.Drinks
{
    public class DetailsModel : PageModel
    {
        private readonly D.I._Tech_Night_School.Data.ApplicationDbContext _context;

        public DetailsModel(D.I._Tech_Night_School.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drink.FirstOrDefaultAsync(m => m.DID == id);

            if (Drink == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
