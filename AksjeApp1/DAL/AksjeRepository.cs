using System;
using AksjeApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AksjeApp1.DAL
{
    public class AksjeRepository : AksjeRepositoryInterface
    {
        private readonly AksjeContext _db;

        public AksjeRepository(AksjeContext db)
        {
            _db = db;
        }

        /*public async bool Task kjop(Ordre innOrdre)
        {
            try
            {
                //Dette er for å finne navnet fra aksjeID
                Aksje enAksje = _db.Aksje.Find(innOrdre.Aksje.Id);

                Ordre enOrdre = new Ordre();
                enOrdre.Antall = innOrdre.Antall;
                enOrdre.OrdreSum = innOrdre.Antall * enAksje.Pris;

                //Lagre kjøpte aksjer i portfolio
                var sjekkAksje = _db.Portfolio.Find(innOrdre.AksjeId);

                if (sjekkAksje == null)
                {
                    Potfolio enPortfolio = new Portfolio
                    {
                        KundeId = 1,
                        AksjeId = innOrdre.Aksje.Id,
                        Antall = innOrdre.Antall,
                        Sum = enOrdre.OrdreSum,


                    }
                }

            }
            catch
            {
                return false;
            }
        }
        */


        /*
   
        //Lagrer kjøp 

        public async Task<bool> Kjøp(Ordre innOrdre)
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


        public bool kjop(int brukerID, int aksjeID, int antall)
        {
            Aksje finnAksje = _db.Aksje.Find(aksjeID);
            Bruker finnBruker = _db.Bruker.Find(brukerID);
            int belop = antall * finnAksje.Pris;

            Portfolio[] portfolios = _db.Portfolio.Where(p => p.Bruker.Id == finnBruker.Id && p.Aksje.Id == finnAksje.Id).ToArray();
            if (belop > finnBruker.Saldo)
            {
                return false;
            }
            if (portfolios.Length == 1)
            {

                    Portfolio eksisterendeAksje = portfolios[0];
                    eksisterendeAksje.Sum += belop;
                    eksisterendeAksje.Antall += antall;
                    finnBruker.Saldo -= belop;
                finnAksje.AntallLedige -= antall;

                    _db.SaveChanges();
                    return true;

            }
            else
            {
                    Portfolio nyPortfolio = new Portfolio();
                    nyPortfolio.Aksje = finnAksje;
                    nyPortfolio.Antall = antall;
                    nyPortfolio.Bruker = finnBruker;
                    nyPortfolio.Navn = finnBruker.Fornavn;
                    nyPortfolio.Sum = belop;
                finnAksje.AntallLedige -= antall;
                _db.Portfolio.Add(nyPortfolio);
                    _db.SaveChanges();
                    return true;
                
            }
           
        }
        public bool selg(int brukerID, int aksjeID, int antall)
        {
            Aksje finnAksje = _db.Aksje.Find(aksjeID);
            Bruker finnBruker = _db.Bruker.Find(brukerID);
            int belop = antall * finnAksje.Pris;
            Portfolio[] portfolios = _db.Portfolio.Where(p => p.Bruker.Id == finnBruker.Id && p.Aksje.Id == finnAksje.Id).ToArray();

            if (portfolios.Length == 1)
            {
                Portfolio eksisterendeAksje = portfolios[0];
                if (eksisterendeAksje.Antall > antall)
                {
                    eksisterendeAksje.Sum -= belop;
                    eksisterendeAksje.Antall -= antall;
                    finnBruker.Saldo += belop;
                    finnAksje.AntallLedige += antall;
                    _db.SaveChanges();
                    return true;
                }
                else if (eksisterendeAksje.Antall == antall)
                {
                    finnBruker.Saldo += belop;
                    finnAksje.AntallLedige += antall;
                    _db.Remove(eksisterendeAksje.Id);
                    _db.SaveChanges();
                    return true;
                }
            }
             return false;
        }







        public async Task<List<Aksje>> HentAksjene()
        {
            try
            {
                List<Aksje> alleAksjer = await _db.Aksje.Select(a => new Aksje
                {
                    Id = a.Id,
                    Navn = a.Navn,
                    Pris = a.Pris,
                    AntallLedige = a.AntallLedige,
                    MaxAntall = a.MaxAntall
                }).ToListAsync();
                return alleAksjer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Portfolio>> HentPortfolio()
        {
            try
            {
                List<Portfolio> helePortfolio = await _db.Portfolio.Select(p => new Portfolio
                {
                    Id = p.Id,
                    Navn = p.Aksje.Navn,
                    Pris = p.Aksje.Pris,
                    Antall = p.Antall,
                    Sum = p.Pris * p.Antall
                }).ToListAsync();
                return helePortfolio;
            }
            catch
            {
                return null;
            }
        }
        
    }
}

