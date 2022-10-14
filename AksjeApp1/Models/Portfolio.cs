using System;
using System.Collections.Generic;

namespace AksjeApp1.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Antall { get; set; }
        public int Sum { get; set; }
        public virtual Aksje Aksje { get; set; }
        public virtual Kunde Kunde { get; set; }
    }
}

