using System;
using Microsoft.EntityFrameworkCore;

namespace AksjeApp1.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Aksje> Aksje { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Portefølje> Portefølje { get; set; }
        public virtual DbSet<Ordre> Ordre { get; set; }
    }

}
