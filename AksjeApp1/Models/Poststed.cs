using System;
using System.ComponentModel.DataAnnotations;

namespace AksjeApp1.Models
{
    public class Poststed
    {
        [Key]
        public int PostNr { get; set; }
        public string Poststeder { get; set; }
    }
}

