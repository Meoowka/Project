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

namespace Programm_L.Pages.Lib
{
    public class IndexModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public IndexModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        public IList<Library_l> Library_l { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Lib_n { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Name_lib { get; set; }
        public async Task OnGetAsync()
        {
            var lib = from m in _context.Library_l
                           select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                lib = lib.Where(s => s.Name_lib.Contains(SearchString));
            }

            Library_l = await lib.ToListAsync();
        }
    }
}
