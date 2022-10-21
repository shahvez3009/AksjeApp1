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
                var enes = new Brukere { Fornavn = "Enes", Etternavn = "Ergin", Saldo = 5000, Mail = "enesergin1204@hotmail.com", Mobilnummer = 90057976 };

                //Aksje
                var microsoft = new Aksjer { Navn = "Microsoft", Pris = 300, AntallLedige = 5531, MaxAntall = 6000 };

                //Portfolio
                var portfolio = new Portfolios { Antall = 5, Aksje = microsoft, Bruker = enes};
             
                context.Brukere.Add(enes);

                context.Aksjer.Add(microsoft);

                context.Portfolios.Add(portfolio);

                context.SaveChanges();
            }
        }
    }
}

