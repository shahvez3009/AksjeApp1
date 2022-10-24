using System;
using AksjeApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using System.Reflection.Metadata;

namespace AksjeApp1.DAL
{
    public class AksjeRepository : AksjeRepositoryInterface
    {
        private readonly AksjeContext _db;

        public AksjeRepository(AksjeContext db)
        {
            _db = db;
        }





        public async Task<bool> Selg(int aksjeID, int antall)
        {
            try {
                Console.WriteLine("Jeg er i start");
                Portfolios[] etPortfolioRad = _db.Portfolios.Where(p => p.Aksje.Id == 2).ToArray();
                Console.WriteLine(aksjeID);
                var medAntall = 4;
                if (etPortfolioRad.Length == 0)
                {
                    Console.WriteLine("FUNNET PORT");
                }
                Console.WriteLine("Jeg er forbi Portfolio");
                Brukere enBruker = await _db.Brukere.FindAsync(1);
                Console.WriteLine("Jeg er forbi Bruker");
                Aksjer enAksje = await _db.Aksjer.FindAsync(aksjeID);
                Console.WriteLine("Jeg er forbi Aksje");
                var antallAksjer = etPortfolioRad[0].Antall;
                Console.WriteLine(antallAksjer + "Ja");
                if ( antallAksjer > medAntall)
            {
                    Console.WriteLine("Jeg er i if");
                    enBruker.Saldo += etPortfolioRad[0].Antall * etPortfolioRad[0].Aksje.Pris;
                    Console.WriteLine("Jeg er forbi saldo");
                    etPortfolioRad[0].Antall -= medAntall;
                    Console.WriteLine("Jeg er forbi antall");
                    etPortfolioRad[0].Aksje.AntallLedige += medAntall;
                    Console.WriteLine("Jeg er forbi ledige");
                    await _db.SaveChangesAsync();
                return true;
            }
                if (etPortfolioRad[0].Antall == antall)
            {
                    Console.WriteLine("Jeg er i else if");
                    etPortfolioRad[0].Bruker.Saldo += etPortfolioRad[0].Antall * etPortfolioRad[0].Aksje.Pris;
                    etPortfolioRad[0].Aksje.AntallLedige += antall;
                    _db.Remove(etPortfolioRad[0].Id);
                await _db.SaveChangesAsync();
                return true;
            }
                Console.WriteLine("Jeg er i else");
                return false;
        }
            catch
            {
                Console.WriteLine("Jeg er i catch");
                return false;
            }
            }





        public async Task<bool> Kjop(int id, Portfolios innPortfolio)
        {
            try
            {
                Portfolios[] portfolioss = _db.Portfolios.Where(p => p.Aksje.Id == id && p.Bruker.Id == 1).ToArray();
                Brukere enBruker = await _db.Brukere.FindAsync(1);
                Aksjer enAksje = await _db.Aksjer.FindAsync(id);
                if(enBruker.Saldo >= enAksje.Pris * innPortfolio.Antall && enAksje.AntallLedige >= innPortfolio.Antall)
                {
                    if (portfolioss.Length == 1)
                    {
                        Console.WriteLine("Bruker har allerede aksje fra før av i Portfolio: ");
                        Console.WriteLine(portfolioss[0].Antall);
                        portfolioss[0].Antall += innPortfolio.Antall;
                        Console.WriteLine(portfolioss[0].Antall);

                    }
                    else
                    {
                        Console.WriteLine("Bruker får ny aksje i Portfolio: ");
                        var nyPortfolio = new Portfolios();
                        nyPortfolio.Antall = innPortfolio.Antall;
                        nyPortfolio.Aksje = enAksje;
                        nyPortfolio.Bruker = enBruker;
                        _db.Portfolios.Add(nyPortfolio);
                    }
                    Console.WriteLine("Saldo før oppdatering: " + enBruker.Saldo);
                    enBruker.Saldo -= enAksje.Pris * innPortfolio.Antall;
                    Console.WriteLine("Saldo etter oppdatering: " + enBruker.Saldo);

                    Console.WriteLine("Antall Ledige før oppdatering: " + enAksje.AntallLedige);
                    enAksje.AntallLedige -= innPortfolio.Antall;
                    Console.WriteLine("Antall Ledige etter oppdatering: " + enAksje.AntallLedige);

                    await _db.SaveChangesAsync();
                    Console.WriteLine("Det funka, og du har råd");
                    return true;
                }
                Console.WriteLine("Det funka, og du har IKKE råd, eller du kan ikke kjøpe så mange aksjer.");
                return false;
                
            }

            catch
            {
                Console.WriteLine("Noe gikk galt");
                return false;
            }
        }

        public async Task<Bruker> HentEnBruker()
        {
            Brukere enBruker = await _db.Brukere.FindAsync(1);
            var hentetBruker = new Bruker()
            {
                Id = enBruker.Id,
                Fornavn = enBruker.Fornavn,
                Etternavn = enBruker.Etternavn,
                Saldo = enBruker.Saldo,
                Mail = enBruker.Mail,
                Mobilnummer = enBruker.Mobilnummer
            };
            return hentetBruker;
        }

        public async Task<Aksje> HentEnAksje(int id)
        {
            Aksjer enAksje = await _db.Aksjer.FindAsync(id);
            var hentetAksje = new Aksje()
            {
                Id = enAksje.Id,
                Navn = enAksje.Navn,
                Pris = enAksje.Pris,
                MaxAntall = enAksje.MaxAntall,
                AntallLedige = enAksje.AntallLedige
            };
            return hentetAksje;
        }

        public async Task<Portfolio> HentEtPortfolioRad(int id)
        {
            Portfolios etPortfolioRad = _db.Portfolios.First(p => p.Aksje.Id == id);
            Brukere enBruker = await _db.Brukere.FindAsync(1);
            Aksjer enAksje = await _db.Aksjer.FindAsync(id);
            var hentetPortfolioRad = new Portfolio()
            {
                Id = etPortfolioRad.Id,
                Antall = etPortfolioRad.Antall,
                AksjeId = enAksje.Id,
                AksjeNavn = enAksje.Navn,
                AksjePris = enAksje.Pris,
                BrukerId = enBruker.Id
            };
            return hentetPortfolioRad;
        }

        public async Task<List<Aksje>> HentAksjene()
        {
            try
            {
                List<Aksje> alleAksjer = await _db.Aksjer.Select(a => new Aksje
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
                List<Portfolio> helePortfolio = await _db.Portfolios.Select(p => new Portfolio
                {
                    Id = p.Id,
                    Antall = p.Antall,
                    AksjeId = p.Aksje.Id,
                    AksjeNavn = p.Aksje.Navn,
                    AksjePris = p.Aksje.Pris,
                    BrukerId = p.Bruker.Id
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

