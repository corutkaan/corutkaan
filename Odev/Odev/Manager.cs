using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public class Manager
    {
        ICLF<Kitap> kitap;
        public Manager(ICLF<Kitap> kitap)
        {
            this.kitap = kitap;
        }
        public List<Kitap> Listele()
        {
            return kitap.Listele();
        }
        public Kitap Bul(int id) => kitap.Bul(id);
        public void Ekle(Kitap kitap)
        {
            this.kitap.Ekle(kitap);
        }
    }
}
