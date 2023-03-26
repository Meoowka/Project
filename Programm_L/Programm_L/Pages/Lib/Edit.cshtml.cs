using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Lib
{
    public class EditModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public EditModel(Programm_L.Data.Programm_LContext context)
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

            var library_l =  await _context.Library_l.FirstOrDefaultAsync(m => m.Lib_ID == id);
            if (library_l == null)
            {
                return NotFound();
            }
            Library_l = library_l;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Library_l).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Library_lExists(Library_l.Lib_ID))
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

        private bool Library_lExists(int id)
        {
          return (_context.Library_l?.Any(e => e.Lib_ID == id)).GetValueOrDefault();
        }
    }
}
