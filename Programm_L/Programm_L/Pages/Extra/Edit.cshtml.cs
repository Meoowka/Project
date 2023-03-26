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

namespace Programm_L.Pages.Extra
{
    public class EditModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public EditModel(Programm_L.Data.Programm_LContext context)
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

            var extradition =  await _context.Extradition.FirstOrDefaultAsync(m => m.Extra_ID == id);
            if (extradition == null)
            {
                return NotFound();
            }
            Extradition = extradition;
           ViewData["Book_ID"] = new SelectList(_context.Books, "Book_ID", "Book_ID");
           ViewData["Personal_ID"] = new SelectList(_context.Set<Personal>(), "Personal_ID", "Personal_ID");
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

            _context.Attach(Extradition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraditionExists(Extradition.Extra_ID))
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

        private bool ExtraditionExists(int id)
        {
          return (_context.Extradition?.Any(e => e.Extra_ID == id)).GetValueOrDefault();
        }
    }
}
