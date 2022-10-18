using System;
namespace AksjeApp1.Models
{
    public class Ordre
    {
        public int Id { get; set; }
        public int Antall { get; set;}
        public int OrdreSum { get; set; }

        public virtual Bruker Bruker { get; set; }
        public virtual Aksje Aksje { get; set; }
    }
}

