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
                var context = serviceScope.ServiceProvider.GetService<AksjeContext>();

                /*var client = new RestClient("https://api.polygon.io/v1/open-close/AAPL/2020-10-14?adjusted=true&apiKey=ZEiSOvpQCiinfLiWOiJhnyeJmGdrIUpF");
                var request = new RestRequest("", (Method)DataFormat.Json);
                var response = client.Get(request);
                Console.WriteLine(response.Content);
                Console.Read();
                */
                
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Bruker
                var enes = new Bruker { Fornavn = "Enes", Etternavn = "Ergin", Saldo = 5000, Mail = "enesergin1204@hotmail.com", Mobilnummer = 90057976 };

                //Aksje
                var microsoft = new Aksje { Navn = "Microsoft", Pris = 300, AntallLedige = 5531, MaxAntall = 6000 };
                var apple = new Aksje { Navn = "Apple", Pris = 350, AntallLedige = 6531, MaxAntall = 7000 };

                //Portfolio
                var portfolio1 = new Portfolio { Navn = microsoft.Navn, Pris = microsoft.Pris, Antall = 5, Sum = microsoft.Pris * 5, Bruker = enes, Aksje = microsoft};
                var portfolio2 = new Portfolio { Navn = apple.Navn, Pris = apple.Pris, Antall = 5, Sum = apple.Pris * 5, Bruker = enes, Aksje = apple };

                context.Bruker.Add(enes);

                context.Aksje.Add(microsoft);
                context.Aksje.Add(apple);

                context.Portfolio.Add(portfolio1);
                //context.Portfolio.Add(portfolio2);

                context.SaveChanges();
            }
        }
    }
}

