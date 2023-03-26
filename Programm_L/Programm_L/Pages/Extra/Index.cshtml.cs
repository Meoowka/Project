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
    public class IndexModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public IndexModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        public IList<Extradition> Extradition { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Extradition != null)
            {
                Extradition = await _context.Extradition
                .Include(e => e.Books)
                .Include(e => e.personal).ToListAsync();
            }
        }
    }
}
