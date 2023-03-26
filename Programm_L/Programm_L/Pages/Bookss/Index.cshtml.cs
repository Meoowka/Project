using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programm_L.Data;
using Programm_L.Models;

namespace Programm_L.Pages.Bookss
{
    public class IndexModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public IndexModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        public IList<Books> Books { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Bookss { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Name_bok { get; set; }
        public async Task OnGetAsync()
        {
            var book = from m in _context.Books
                           select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                book = book.Where(s => s.Name_book.Contains(SearchString));
            }

            Books = await book.ToListAsync();
        }
    }
}
