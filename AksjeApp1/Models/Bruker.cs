using System;
using System.Collections.Generic;

namespace AksjeApp1.Models
{
    public class Bruker
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public int Saldo { get; set; }
        public string Mail { get; set; }
        public int Mobilnummer { get; set; }
    }
}

