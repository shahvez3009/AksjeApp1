﻿using System;
namespace AksjeApp1.Models
{
    public class Ordre
    {
     public int Id { get; set; }
     public int Antall { get; set;}
     public int OrdrePris { get; set; }
     public virtual Kunde Kunde { get; set; }
     public virtual Aksje Aksje { get; set; }
     public virtual Portefølje Portefølje { get; set; }

    }
}
