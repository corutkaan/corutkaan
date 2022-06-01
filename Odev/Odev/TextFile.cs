using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public class TextFile : ICLF<Kitap>
    {
        public Kitap Bul(int id)
        {
            StreamReader sr = new StreamReader("Kitaplar.txt");
            Kitap kitap = new Kitap();
            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine().Split(";");
                
                if (Convert.ToInt32(data[0]) == id)
                {
                    kitap.KitapID = Convert.ToInt32(data[0]);
                    kitap.Ad = data[1];
                    kitap.YazarAd = data[2];
                    kitap.Fiyat = Convert.ToDouble(data[3]);
                    break;
                }
            }
            sr.Close();
            return kitap;
        }

        public void Ekle(Kitap kitap)
        {
            StreamWriter sw = new StreamWriter("Kitaplar.txt",true);
            sw.Write(kitap.KitapID + ";" + kitap.Ad + ";" + kitap.YazarAd + ";" + kitap.Fiyat + "\n");
            Console.WriteLine("Kitap Başarıyla Eklendi..");
            sw.Close();
        }

        public List<Kitap> Listele()
        {
            try
            {            
            StreamReader sr = new StreamReader("Kitaplar.txt");
            List<Kitap> list = new List<Kitap>();
            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine().Split(";");
                Kitap kitap = new Kitap();
                kitap.KitapID = Convert.ToInt32(data[0]);
                kitap.Ad = data[1];
                kitap.YazarAd = data[2];
                kitap.Fiyat = Convert.ToDouble(data[3]);
                list.Add(kitap);
            }
            sr.Close();
            return list;
            }
            catch (Exception)
            {

                Console.WriteLine("Kitaplar.txt Bulunamadı.");
                List<Kitap> list = new List<Kitap>();
                return list;
            }
        }
    }
}
