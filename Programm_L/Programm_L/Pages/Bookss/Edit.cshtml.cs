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

namespace Programm_L.Pages.Bookss
{
    public class EditModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public EditModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Books Books { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books =  await _context.Books.FirstOrDefaultAsync(m => m.Book_ID == id);
            if (books == null)
            {
                return NotFound();
            }
            Books = books;
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

            _context.Attach(Books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(Books.Book_ID))
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

        private bool BooksExists(int id)
        {
          return (_context.Books?.Any(e => e.Book_ID == id)).GetValueOrDefault();
        }
    }
}
