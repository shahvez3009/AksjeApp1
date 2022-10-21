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

        public bool Kjop(int brukerID, int aksjeID, int antall)
        {
            Aksjer finnAksje = _db.Aksjer.Find(aksjeID);
            Brukere finnBruker = _db.Brukere.Find(brukerID);
            int belop = antall * finnAksje.Pris;

            Portfolios[] portfolioss = _db.Portfolios.Where(p => p.Bruker.Id == finnBruker.Id && p.Aksje.Id == finnAksje.Id).ToArray();
            if (belop > finnBruker.Saldo)
            {
                return false;
            }
            if (portfolioss.Length == 1)
            {

                    Portfolios eksisterendeAksje = portfolioss[0];
                    eksisterendeAksje.Sum += belop;
                    eksisterendeAksje.Antall += antall;
                    finnBruker.Saldo -= belop;
                finnAksje.AntallLedige -= antall;

                    _db.SaveChanges();
                    return true;

            }
            else
            {
                    Portfolios nyPortfolio = new Portfolios();
                    nyPortfolio.Aksje = finnAksje;
                    nyPortfolio.Antall = antall;
                    nyPortfolio.Bruker = finnBruker;
                    nyPortfolio.Navn = finnBruker.Fornavn;
                    nyPortfolio.Sum = belop;
                finnAksje.AntallLedige -= antall;
                _db.Portfolios.Add(nyPortfolio);
                    _db.SaveChanges();
                    return true;
                
            }
           
        }
        public bool Selg(int brukerID, int aksjeID, int antall)
        {
            Aksjer finnAksje = _db.Aksjer.Find(aksjeID);
            Brukere finnBruker = _db.Brukere.Find(brukerID);
            int belop = antall * finnAksje.Pris;
            Portfolios[] portfolioss = _db.Portfolios.Where(p => p.Bruker.Id == finnBruker.Id && p.Aksje.Id == finnAksje.Id).ToArray();

            if (portfolioss.Length == 1)
            {
                Portfolios eksisterendeAksje = portfolioss[0];
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

        public async Task<Portfolio> HentEtPortfolio()
        {
            Portfolios etPortfolio = await _db.Portfolios.FindAsync(1);
          
            var hentetPortfolio = new Portfolio()
            {
                Id = etPortfolio.Id,
                Navn = etPortfolio.Navn,
                Pris = etPortfolio.Pris,
                Antall = etPortfolio.Antall,
                Sum = etPortfolio.Sum
            };
            return hentetPortfolio;
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

