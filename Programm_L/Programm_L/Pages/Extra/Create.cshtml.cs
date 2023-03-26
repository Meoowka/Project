using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Extra
{
    public class CreateModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public CreateModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Book_ID"] = new SelectList(_context.Books, "Book_ID", "Book_ID");
        ViewData["Personal_ID"] = new SelectList(_context.Set<Personal>(), "Personal_ID", "Personal_ID");
            return Page();
        }

        [BindProperty]
        public Extradition Extradition { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Extradition == null || Extradition == null)
            {
                return Page();
            }

            _context.Extradition.Add(Extradition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
