using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public class Kitap
    {
        public int KitapID { get; set; }
        public string Ad { get; set; }
        public string YazarAd { get; set; }
        public double Fiyat { get; set; }
        public override string ToString()
        {
            return $"{KitapID} {Ad} {YazarAd} {Fiyat}";
        }
    }
}
