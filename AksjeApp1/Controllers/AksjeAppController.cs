using System.Net.Http;
using AksjeApp1.Models;
using TwelveDataSharp;
using TwelveDataSharp.Interfaces;
using TwelveDataSharp.Library.ResponseModels;


using System.Threading.Tasks;
using AksjeApp1.Controllers;
using System.Threading.Tasks;
using System.Linq;
using AksjeApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace AksjeApp1.Controllers
{
    public class AksjeAppController
    {
        private readonly DB _db;

        //Konstuktør
        public AksjeAppController(AksjeAppController db)
        {
            _db = db;
        }


   
        //Lagrer kjøp 
       
        public async Task<bool> Kjøp(Ordre innOrdre)
        {
            //Først må vi lage en ny rad i ordretabellen for å lagre ordren som har blitt gjort
            var nyOrdreRad = new Ordre();



            nyOrdreRad.OrdreSum = _db.Aksje.Pris * innOrdre.Antall; //Må ta _db.Aksje.
                                                                    //Pris siden prisen skal ikke komme inn som iput via
                                                                    //"kjøpskjema", prisen ligger i databasen

            //(ALT UNDER MÅ I EN IF SETNING SOM SKJEKKER OM KUNDEN HAR NOK PENGER)


            nyOrdreRad.Antall = innOrdre.Antall;//Dropper Id siden det er autoinkrement.
                                                //Tror det skal funke

            //Er 1 eller 2 riktig?
            nyOrdreRad.Kunde = innOrdre.Kunde; //(1)
            nyOrdreRad.Kunde.Id = innOrdre.Kunde.Id; //(2)
            

            nyOrdreRad.Aksje = innOrdre.Aksje; //(1) ?
            nyOrdreRad.Aksje.ID = innOrdre.Aksje.ID; //(2) ?

            nyOrdreRad.Portfolio = innOrdre.Portfolio; //(1)
            nyOrdreRad.Portfolio.Id = innOrdre.Portfolio.Id; //(2)

            //Endrer saldoen til kunden
            nyOrdreRad.Kunde.Saldo = innOrdre.Kunde.Saldo - innOrdre.OrdreSum;
            

            //Vi må også legge inn info i portofolio (husk også endre saldo til kunden i portofolio)


        }

        public async Task<List<Aksje>> HentAksjer()
        {
            try
            {
                List<Aksje> alleAksjer = await _db.Aksje.Select(k => new Aksje
                {
                    Id = k.Id,
                    Navn = k.Navn,
                    Pris = k.Pris,
                    AntallLedige = k.AntallLedige,
                    MaxAntall = k.MaxAntall
                }).ToListAsync();
                return alleAksjer;
            }
            catch
            {
                return null;
            }
        }


    }
}
