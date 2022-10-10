using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AksjeApp1.Controllers;
using AksjeApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace AksjeApp1.Controllers
{
    public class AksjeAppController
    {
        private readonly DB _db;

        //Konstuktør
        public AksjeAppController(AksjeAppController db)
        {
            _db = db;
        }


        //Lagrer kjøp 
        /*
         * public async Task<bool> Kjøp(Ordre innOrdre)
        {
            var nyOrdreRad = new Ordre();

            //Dropper Id siden det er autoinkrement. Tror det skal funke
            nyOrdreRad.Antall = innOrdre.Antall;
            nyOrdreRad.OrdrePris = _db.Aksje.Pris * innOrdre.Antall;
        }
        */


        //Liste opp aksjer i porteføljen (Enes)
        public async Task<List<Aksje>> HentAksjer()
        {
            try
            {
                List<Aksje> alleAksjer = await _db.Aksje.Select(k => new Aksje
                {
                    Id = k.Id,
                    Navn = k.Navn,
                    Pris = k.Pris,
                    AntallLedige = k.AntallLedige,
                    MaxAntall = k.MaxAntall
                }).ToListAsync();
                return alleAksjer;
            }
            catch
            {
                return null;
            }
        }
    }
}
