using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Extra
{
    public class DeleteModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public DeleteModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Extradition Extradition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Extradition == null)
            {
                return NotFound();
            }

            var extradition = await _context.Extradition.FirstOrDefaultAsync(m => m.Extra_ID == id);

            if (extradition == null)
            {
                return NotFound();
            }
            else 
            {
                Extradition = extradition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Extradition == null)
            {
                return NotFound();
            }
            var extradition = await _context.Extradition.FindAsync(id);

            if (extradition != null)
            {
                Extradition = extradition;
                _context.Extradition.Remove(Extradition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
