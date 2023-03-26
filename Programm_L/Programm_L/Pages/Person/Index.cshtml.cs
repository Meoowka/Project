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

namespace Programm_L.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly Programm_L.Data.Programm_LContext _context;

        public IndexModel(Programm_L.Data.Programm_LContext context)
        {
            _context = context;
        }

        public IList<Personal> Personal { get;set; } = default!;
                [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? Name_p { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? Name_pers { get; set; }
        public async Task OnGetAsync()
        {
            var person = from m in _context.Personal
                      select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                person = person.Where(s => s.Name_pers.Contains(SearchString));
            }

            Personal = await person.ToListAsync();
        }
    }
}
