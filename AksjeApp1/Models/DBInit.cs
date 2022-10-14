using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AksjeApp1.Models
{
    public class DBInit
    {
        public static void Init(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DB>();

                
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var microsoft = new Aksje { Navn = "Microsoft", Pris = 300, AntallLedige = 5531, MaxAntall = 6000 };
                var apple = new Aksje { Navn = "Apple", Pris = 350, AntallLedige = 6531, MaxAntall = 7000 };

                db.Aksje.Add(microsoft);
                db.Aksje.Add(apple);

                db.SaveChanges();
            }
        }
    }
}

