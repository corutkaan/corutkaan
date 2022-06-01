using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public static class Yazdir
    {
        public static void yazdir(Kitap kitap)
        {
            Console.WriteLine(kitap);
        }

        public static void yazdir(List<Kitap> kitaplar)
        {
            foreach (Kitap kitap in kitaplar)
            {
                Console.WriteLine(kitap);
            }
        }
    }
}
