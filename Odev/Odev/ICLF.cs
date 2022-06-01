using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public interface ICLF<T> where T : class
    {
        List<T> Listele();
        Kitap Bul(int id);
        void Ekle(Kitap kitap);

    }
}
