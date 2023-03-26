using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Programm_L.Models;

namespace Programm_L.Data
{
    public class Programm_LContext : DbContext
    {
        public Programm_LContext (DbContextOptions<Programm_LContext> options)
            : base(options)
        {
        }

        public DbSet<Programm_L.Models.Books> Books { get; set; } = default!;

        public DbSet<Programm_L.Models.Extradition> Extradition { get; set; } = default!;

        public DbSet<Programm_L.Models.Library_l> Library_l { get; set; } = default!;

        public DbSet<Programm_L.Models.Personal> Personal { get; set; } = default!;
    }
}
