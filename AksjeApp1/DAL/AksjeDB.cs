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

    public class AksjeContext : DbContext
    {
        public AksjeContext(DbContextOptions<AksjeContext> options)
                : base(options)
        {
            // denne brukes for å opprette databasen fysisk dersom den ikke er opprettet
            // dette er uavhenig av initiering av databasen (seeding)
            // når man endrer på strukturen på KundeContxt her er det fornuftlig å slette denne fysisk før nye kjøringer
            Database.EnsureCreated();
        }

        public DbSet<Aksje> Aksje { get; set; }
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<Poststed> Poststed { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Ordre> Ordre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
            optionsBuilder.UseLazyLoadingProxies();
        }

    }

}
