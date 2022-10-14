using System.Net.Http;
using AksjeApp1.Models;
using TwelveDataSharp;
using TwelveDataSharp.Interfaces;
using TwelveDataSharp.Library.ResponseModels;
using System.Threading.Tasks;
using AksjeApp1.Controllers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AksjeApp1.Controllers
{
    public class AksjeAppController
    {
        private const string V = "google";
        private readonly DB _db;

        //Konstuktør
        public AksjeAppController(AksjeAppController db)
        {
            _db = db;
        }

        /*
   
        //Lagrer kjøp 

        /* public async Task<bool> Kjøp(Ordre innOrdre)
         {
             //Først må vi lage en ny rad i ordretabellen for å lagre ordren som har blitt gjort
             var nyOrdreRad = new Ordre();



            nyOrdreRad.OrdreSum = _db.Aksje.Pris * innOrdre.Antall; //Må ta _db.Aksje.
                                                                    //Pris siden prisen skal ikke komme inn som input via
                                                                    //"kjøpskjema", prisen ligger i databasen

            //(ALT UNDER MÅ I EN IF SETNING SOM SJEKKER OM KUNDEN HAR NOK PENGER)


             nyOrdreRad.Antall = innOrdre.Antall;//Dropper Id siden det er autoinkrement.
                                                 //Tror det skal funke

             //Er 1 eller 2 riktig?
             nyOrdreRad.Kunde = innOrdre.Kunde; //(1)
             nyOrdreRad.Kunde.Id = innOrdre.Kunde.Id; //(2)


        }
        */
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
        /*
        public async Task<List<Portfolio>> HentPortfolio()
        {
            try
            {
                List<Portfolio> helePortfolio = await _db.Portfolio.Select(k => new Portfolio
                {
                    Id = k.Id,
                    Navn = k.Navn,
                    Pris = k.Pris,
                    AntallLedige = k.AntallLedige,
                    MaxAntall = k.MaxAntall
                }).ToListAsync();
                return helePortfolio;
            }
            catch
            {
                return null;
            }
        }
        */

    }
}
