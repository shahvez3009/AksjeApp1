using System;
using AksjeApp1.Controllers;
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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // må importere pakken Microsoft.EntityFrameworkCore.Proxies
        // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
        optionsBuilder.UseLazyLoadingProxies();
    }

        public static implicit operator DB(AksjeAppContoller v)
        {
            throw new NotImplementedException();
        }
    }

}
