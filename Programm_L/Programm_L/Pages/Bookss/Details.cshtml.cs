using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Bookss
{
    public class DetailsModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public DetailsModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

      public Books Books { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FirstOrDefaultAsync(m => m.Book_ID == id);
            if (books == null)
            {
                return NotFound();
            }
            else 
            {
                Books = books;
            }
            return Page();
        }
    }
}
