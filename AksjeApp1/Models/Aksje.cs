using System;
namespace AksjeApp1.Models
{
    public class Aksje
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Pris { get; set; }
        public int MaxAntall { get; set; }
        public int AntallLedige { get; set; }
    }
}

