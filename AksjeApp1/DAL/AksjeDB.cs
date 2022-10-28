using System;
using System.Reflection;
using AksjeApp1.Controllers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace AksjeApp1.Models
{

    public class Aksjer
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Pris { get; set; }
        public int MaxAntall { get; set; }
        public int AntallLedige { get; set; }
    }

    public class Brukere
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public int Saldo { get; set; }
        public string Mail { get; set; }
        public int Mobilnummer { get; set; }
    }

    public class Portfolios
    {
        public int Id { get; set; }
        public int Antall { get; set; }

        public virtual Aksjer Aksje { get; set; }
        public virtual Brukere Bruker { get; set; }
    }

    public class Transaksjoner
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string DatoTid { get; set; }
        public int Antall { get; set; }

        public virtual Aksjer Aksje { get; set; }
        public virtual Brukere Bruker { get; set; }
    }

    public class AksjeContext : DbContext
    {
        public AksjeContext(DbContextOptions<AksjeContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Aksjer> Aksjer { get; set; }
        public DbSet<Brukere> Brukere { get; set; }
        public DbSet<Portfolios> Portfolios { get; set; }
        public DbSet<Transaksjoner> Transaksjoner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }

}
