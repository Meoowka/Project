using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Lib
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
        public Library_l Library_l { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Library_l == null || Library_l == null)
            {
                return Page();
            }

            _context.Library_l.Add(Library_l);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
