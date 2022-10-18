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

        public bool Kjop(int brukerID, int aksjeID, int antall)
        {
            return _db.Kjop(brukerID, aksjeID, antall);
        }

        /*
        public async Task<bool> Selg(Ordre innOrdre)
        {
            return await _db.Selg(innOrdre);
        }
        */

        public async Task<List<Aksje>> HentAksjene()
        {
            return await _db.HentAksjene();
        }

        public async Task<List<Portfolio>> HentPortfolio()
        {
            return await _db.HentPortfolio();
        }
    }
}
