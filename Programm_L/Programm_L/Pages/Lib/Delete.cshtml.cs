using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Lib
{
    public class DeleteModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public DeleteModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Library_l Library_l { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Library_l == null)
            {
                return NotFound();
            }

            var library_l = await _context.Library_l.FirstOrDefaultAsync(m => m.Lib_ID == id);

            if (library_l == null)
            {
                return NotFound();
            }
            else 
            {
                Library_l = library_l;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Library_l == null)
            {
                return NotFound();
            }
            var library_l = await _context.Library_l.FindAsync(id);

            if (library_l != null)
            {
                Library_l = library_l;
                _context.Library_l.Remove(Library_l);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
