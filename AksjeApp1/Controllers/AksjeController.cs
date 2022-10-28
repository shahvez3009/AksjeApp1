using System.Net.Http;
using System;
using AksjeApp1.Models;
using TwelveDataSharp;
using TwelveDataSharp.Interfaces;
using TwelveDataSharp.Library.ResponseModels;
using System.Threading.Tasks;
using AksjeApp1.Controllers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AksjeApp1.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AksjeApp1.Controllers
{
    [Route("[controller]/[action]")]
    public class AksjeController : ControllerBase
    {
        private readonly AksjeRepositoryInterface _db;

        public AksjeController(AksjeRepositoryInterface db)
        {
            _db = db;
        }

        public async Task<bool> Selg(int id, Portfolios innPortfolio)
        {
            return await _db.Selg(id,innPortfolio);
        }
       

        public async Task<bool> Kjop(int id, Portfolios innPortfolio)
        {
            return await _db.Kjop(id, innPortfolio);
        }

        public async Task<Bruker> HentEnBruker()
        {
            return await _db.HentEnBruker();
        }

        public async Task<Aksje> HentEnAksje(int id)
        {
            return await _db.HentEnAksje(id);
        }
        
        public async Task<Portfolio> HentEtPortfolioRad(int id)
        {
            return await _db.HentEtPortfolioRad(id);
        }
        

        public async Task<List<Aksje>> HentAksjer()
        {
            return await _db.HentAksjer();
        }

        public async Task<List<Portfolio>> HentPortfolio()
        {
            return await _db.HentPortfolio();
        }

        public async Task<List<Transaksjon>> HentTransaksjoner()
        {
            return await _db.HentTransaksjoner();
        }
    }
}
