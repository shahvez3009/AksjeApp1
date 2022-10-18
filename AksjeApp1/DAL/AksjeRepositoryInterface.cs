using System;
using AksjeApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AksjeApp1.DAL
{
    public interface AksjeRepositoryInterface
    {
        bool Kjop(int brukerID, int aksjeID, int antall);
        //Task<bool> Selg(Ordre innOrdre);
        Task<List<Aksje>> HentAksjene();
        Task<List<Portfolio>> HentPortfolio();
    }
}

