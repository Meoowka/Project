using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Person
{
    public class DetailsModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public DetailsModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

      public Personal Personal { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personal == null)
            {
                return NotFound();
            }

            var personal = await _context.Personal.FirstOrDefaultAsync(m => m.Personal_ID == id);
            if (personal == null)
            {
                return NotFound();
            }
            else 
            {
                Personal = personal;
            }
            return Page();
        }
    }
}
