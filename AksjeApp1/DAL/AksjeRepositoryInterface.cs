using System;
using AksjeApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace AksjeApp1.DAL
{
    public interface AksjeRepositoryInterface
    {
        bool Kjop(int brukerID, int aksjeID, int antall);
        //Task<bool> Selg(Ordre innOrdre);
        Task<Bruker> HentEnBruker();
        Task<Aksje> HentEnAksje(int id);
        Task<Portfolio> HentEtPortfolio();
        Task<List<Aksje>> HentAksjene();
        Task<List<Portfolio>> HentPortfolio();
    }
}

