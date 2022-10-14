using System;
using System.Collections.Generic;

namespace AksjeApp1.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public int Saldo { get; set; }
        public string Mail { get; set; }
        public string Telefonnr { get; set; }
        public virtual Poststed Poststed { get; set; }
        public virtual List<Ordre> Ordre { get; set; }
    }
}

