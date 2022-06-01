using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public class Veritabani : ICLF<Kitap>
    {
        SqlConnection Conn;
        public Veritabani()
        {
            string strConn = "Data source=.;initial catalog=master;integrated security=true";

            Conn = new SqlConnection(strConn);
        }

        public Kitap Bul(int id)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kitaplar Where KitapID = @id", Conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            Kitap kitap = new Kitap();
            kitap.KitapID = -1;
            dr.Read();
            if (dr.HasRows)
            {
                kitap.KitapID = Convert.ToInt32(dr[0]);
                kitap.Ad = dr.GetString(1);
                kitap.YazarAd = dr.GetString(2);
                kitap.Fiyat = Convert.ToDouble(dr[3]);
            }
            else
            {
                Console.WriteLine("Kitap Bulunamadı.");
            }
            Conn.Close();
            return kitap;
        }

        public void Ekle(Kitap kitap)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Kitaplar values(@ad,@yazar,@fiyat)", Conn);
            cmd.Parameters.AddWithValue("@ad", kitap.Ad);
            cmd.Parameters.AddWithValue("@yazar", kitap.YazarAd);
            cmd.Parameters.AddWithValue("@fiyat", kitap.Fiyat);

            cmd.ExecuteNonQuery();
            Conn.Close();
            Console.WriteLine("Kitap Başarıyla Eklendi..");
        }

        public List<Kitap> Listele()
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Kitaplar", Conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Kitap> list = new List<Kitap>();
            while (dr.Read())
            {
                Kitap kitap = new Kitap();
                kitap.KitapID = Convert.ToInt32(dr[0]);
                kitap.Ad = dr.GetString(1);
                kitap.YazarAd = dr.GetString(2);
                kitap.Fiyat = Convert.ToDouble(dr[3]);
                list.Add(kitap);
            }
            if (list.Count < 1)
            {
                Console.WriteLine("Herhangi Bir kayıt bulunamadı.");
            }
            Conn.Close();
            return list;
        }
    }
}
