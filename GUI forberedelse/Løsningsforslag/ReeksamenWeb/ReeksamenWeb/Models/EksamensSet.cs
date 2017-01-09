using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReeksamenWeb.Models
{
    public class EksamensSet
    {
        public int EksamensSetId { get; set; }
        public string Fag { get; set; }
        public System.DateTime Termin { get; set; }
        public string StudieNummer { get; set; }
        public int Karakter { get; set; }
    }
}