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

        // denne funksjonen calles på av kjøp og selg funksjonene
        public async Task<bool> lagTransaksjon(string status, int id, Portfolios portfolio, int antall)
        {
            try
            {
                var nyTransaksjon = new Transaksjoner();
                nyTransaksjon.Status = status;
                DateTime datoTid = DateTime.Now;
                nyTransaksjon.DatoTid = datoTid.ToString();
                nyTransaksjon.Antall = antall;
                nyTransaksjon.Aksje = portfolio.Aksje;
                nyTransaksjon.Bruker = portfolio.Bruker;
                _db.Transaksjoner.Add(nyTransaksjon);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Denne funksjonen vil kjøres når brukeren selger aksjer fra portføljen
        public async Task<bool> Selg(int id, Portfolios innPortfolio)
        {
            try
            {
                //Finner den spesifike aksjen som skal selges fra portfolio via AksjeID
                Portfolios[] etPortfolioRad = _db.Portfolios.Where(p => p.Aksje.Id == id).ToArray();

                // Sjekker om antallet brukeren prøver å selge er mindre enn det brukeren eier. Hvis dette er sann vil den utføre transaksjonen
                if (etPortfolioRad[0].Antall > innPortfolio.Antall && innPortfolio.Antall != 0)
                {
                    // Legger til Saldo for brukeren fra salget
                    etPortfolioRad[0].Bruker.Saldo += innPortfolio.Antall * etPortfolioRad[0].Aksje.Pris;
                    // Antallet aksjer brukeren eier vil minke
                    etPortfolioRad[0].Antall -= innPortfolio.Antall;
                    //Antall ledige aksjer tilgjengelig på markedet vil øke med antallet solgt
                    etPortfolioRad[0].Aksje.AntallLedige += innPortfolio.Antall;
                   
                    await lagTransaksjon("Salg", id, etPortfolioRad[0], innPortfolio.Antall);
                    return true;
                }
                // Sjekker om brukeren vil selge alle aksjene den eier. Hvis dette er sann vil den slette aksje beholdningen fra portføljen.
                if (etPortfolioRad[0].Antall == innPortfolio.Antall && innPortfolio.Antall != 0)
                {
                    //Legger til Saldo for brukeren fra salget
                    etPortfolioRad[0].Bruker.Saldo += innPortfolio.Antall * etPortfolioRad[0].Aksje.Pris;
                    //Antall ledige aksjer tilgjengelig på markedet vil øke med antallet solgt
                    etPortfolioRad[0].Aksje.AntallLedige += innPortfolio.Antall;
                    // Slette beholdningen fra databasen ettersom alt er solgt.
                    _db.Remove(etPortfolioRad[0]);
                  
                    await lagTransaksjon("Salg", id, etPortfolioRad[0], innPortfolio.Antall);
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
                if (enBruker.Saldo >= enAksje.Pris * innPortfolio.Antall && enAksje.AntallLedige >= innPortfolio.Antall && innPortfolio.Antall >= 1)
                {
                    if (portfolioss.Length == 1)
                    {
                        Console.WriteLine("Bruker har allerede aksje fra før av i Portfolio: ");
                        Console.WriteLine(portfolioss[0].Antall);
                        portfolioss[0].Antall += innPortfolio.Antall;
                        Console.WriteLine(portfolioss[0].Antall);
                        await lagTransaksjon("Kjøp", id, portfolioss[0], innPortfolio.Antall);
                    }
                    else
                    {
                        Console.WriteLine("Bruker får ny aksje i Portfolio: ");
                        var nyPortfolio = new Portfolios();
                        nyPortfolio.Antall = innPortfolio.Antall;
                        nyPortfolio.Aksje = enAksje;
                        nyPortfolio.Bruker = enBruker;
                        _db.Portfolios.Add(nyPortfolio);
                        await lagTransaksjon("Kjøp", id, nyPortfolio, innPortfolio.Antall);
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

        public async Task<List<Transaksjon>> HentTransaksjon()
        {
            try
            {
                List<Transaksjon> heleTransaksjon = await _db.Transaksjoner.Select(p => new Transaksjon
                {
                    Id = p.Id,
                    Status = p.Status,
                    DatoTid = p.DatoTid,
                    Antall = p.Antall,
                    AksjeId = p.Aksje.Id,
                    AksjeNavn = p.Aksje.Navn,
                    AksjePris = p.Aksje.Pris,
                    BrukerId = p.Bruker.Id
                }).ToListAsync();
                return heleTransaksjon;
            }
            catch
            {
                return null;
            }
        }

    }
}
