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
    public class DeleteModel : PageModel
    {
        private readonly D.I._Tech_Night_School.Data.ApplicationDbContext _context;

        public DeleteModel(D.I._Tech_Night_School.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Food Food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food = await _context.Food
                .Include(f => f.Drinks).FirstOrDefaultAsync(m => m.FID == id);

            if (Food == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food = await _context.Food.FindAsync(id);

            if (Food != null)
            {
                _context.Food.Remove(Food);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
