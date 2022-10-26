using System;
namespace AksjeApp1.Models
{
    public class Transaksjon
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string DatoTid { get; set; }
        public int Antall { get; set;}

        //Fra Aksje
        public int AksjeId { get; set; }
        public string AksjeNavn { get; set; }
        public int AksjePris { get; set; }

        //Fra Bruker
        public int BrukerId { get; set; }
    }
}

