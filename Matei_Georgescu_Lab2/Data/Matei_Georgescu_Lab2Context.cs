using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Matei_Georgescu_Lab2.Models;

namespace Matei_Georgescu_Lab2.Data
{
    public class Matei_Georgescu_Lab2Context : DbContext
    {
        public Matei_Georgescu_Lab2Context (DbContextOptions<Matei_Georgescu_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Matei_Georgescu_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Matei_Georgescu_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Matei_Georgescu_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Matei_Georgescu_Lab2.Models.Category>? Category { get; set; }

        public DbSet<Matei_Georgescu_Lab2.Models.Member>? Member { get; set; }

        public DbSet<Matei_Georgescu_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
