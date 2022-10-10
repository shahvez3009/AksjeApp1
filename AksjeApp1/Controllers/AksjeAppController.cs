using System.Threading.Tasks;
using AksjeApp1.Controllers;
using AksjeApp1.Models;

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
    }
}
