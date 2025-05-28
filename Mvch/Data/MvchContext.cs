using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvch.Models;

namespace Mvch.Data
{
    public class MvchContext : DbContext
    {
        public MvchContext (DbContextOptions<MvchContext> options)
            : base(options)
        {
        }

        public DbSet<Mvch.Models.author> author { get; set; } = default!;
        public DbSet<Mvch.Models.Books> Books { get; set; } = default!;
        public DbSet<Mvch.Models.Zakaz> Zakaz { get; set; } = default!;
    }
}
