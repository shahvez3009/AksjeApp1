using System;
using AksjeApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace AksjeApp1.DAL
{
    public interface AksjeRepositoryInterface
    {
        bool Kjop(Portfolio innPortfolio);
        //Task<bool> Selg(Ordre innOrdre);
        Task<Aksje> HentEnAksje(int id);
        Task<Bruker> HentEnBruker();
        Task<List<Aksje>> HentAksjene();
        Task<List<Portfolio>> HentPortfolio();
    }
}

