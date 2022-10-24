using System;
using AksjeApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;

namespace AksjeApp1.DAL
{
    public class AksjeRepository : AksjeRepositoryInterface
    {
        private readonly AksjeContext _db;

        public AksjeRepository(AksjeContext db)
        {
            _db = db;
        }



        public async Task<bool> Kjop(int id, Portfolios innPortfolio)
        {
            try
            {
                Portfolios[] portfolioss = _db.Portfolios.Where(p => p.Aksje.Id == id && p.Bruker.Id == 1).ToArray();
                Brukere enBruker = await _db.Brukere.FindAsync(1);
                Aksjer enAksje = await _db.Aksjer.FindAsync(id);

                var saldo = enBruker.Saldo;
                var sum = enAksje.Pris * innPortfolio.Antall;

                if (saldo >= sum)
                {
                    if (portfolioss.Length == 1)
                    {
                        Console.WriteLine("Jeg er i if");
                  
                        portfolioss[0].Antall += innPortfolio.Antall;
                        enBruker.Saldo -= enAksje.Pris * innPortfolio.Antall;
                        enAksje.AntallLedige -= innPortfolio.Antall;

                    }
                    else
                    {
                        Console.WriteLine("Jeg er i else");

                        var nyPortfolio = new Portfolios();
                        nyPortfolio.Antall = innPortfolio.Antall;
                        nyPortfolio.Aksje = enAksje;
                        nyPortfolio.Bruker = enBruker;
                        _db.Portfolios.Add(nyPortfolio);
                    }
                    await _db.SaveChangesAsync();
                    Console.WriteLine("Det funka, og du har råd");
                    return true;
                }
                else
                {
                    Console.WriteLine("Det funka, men du har ikke råd");
                    return false;
                }
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

