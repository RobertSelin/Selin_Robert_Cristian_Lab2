using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Selin_Robert_Cristian_Lab2.Models;

namespace Selin_Robert_Cristian_Lab2.Data
{
    public class Selin_Robert_Cristian_Lab2Context : DbContext
    {
        public Selin_Robert_Cristian_Lab2Context (DbContextOptions<Selin_Robert_Cristian_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Selin_Robert_Cristian_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Selin_Robert_Cristian_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Selin_Robert_Cristian_Lab2.Models.Authors> Authors { get; set; }

        public DbSet<Selin_Robert_Cristian_Lab2.Models.Category> Category { get; set; }

        public DbSet<Selin_Robert_Cristian_Lab2.Models.Member> Member { get; set; }

        public DbSet<Selin_Robert_Cristian_Lab2.Models.Borrowing> Borrowing { get; set; }
    }
}
