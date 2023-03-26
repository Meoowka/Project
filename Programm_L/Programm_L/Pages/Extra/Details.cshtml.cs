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
    public class DetailsModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public DetailsModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

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
    }
}
