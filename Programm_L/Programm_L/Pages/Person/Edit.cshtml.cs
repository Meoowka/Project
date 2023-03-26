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

namespace Programm_L.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public EditModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Personal Personal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personal == null)
            {
                return NotFound();
            }

            var personal =  await _context.Personal.FirstOrDefaultAsync(m => m.Personal_ID == id);
            if (personal == null)
            {
                return NotFound();
            }
            Personal = personal;
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

            _context.Attach(Personal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalExists(Personal.Personal_ID))
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

        private bool PersonalExists(int id)
        {
          return (_context.Personal?.Any(e => e.Personal_ID == id)).GetValueOrDefault();
        }
    }
}
