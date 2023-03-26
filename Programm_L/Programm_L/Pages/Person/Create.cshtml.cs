using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Person
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
            return Page();
        }

        [BindProperty]
        public Personal Personal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Personal == null || Personal == null)
            {
                return Page();
            }

            _context.Personal.Add(Personal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
