using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public class VeritabaniKontrol
    {
        SqlConnection Conn;
        public VeritabaniKontrol()
        {
            string strConn = "Data source=.;initial catalog=master;integrated security=true";

            Conn = new SqlConnection(strConn);

            Conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = @kitaplar", Conn);
            cmd.Parameters.AddWithValue("@kitaplar", "Kitaplar");
            int var = (int)cmd.ExecuteScalar();
            if (var == 0)
            {
                try
                {
                    SqlCommand cmd2 = new SqlCommand("CREATE TABLE [dbo].[Kitaplar]([KitapID][int] IDENTITY(1, 1) PRIMARY KEY, [Ad][varchar](30) NULL,[Yazar][varchar](30) NULL, [Fiyat][float] NULL)", Conn);
                    cmd2.ExecuteScalar();
                    Console.WriteLine("'Kitaplar' Veritabanı Yaratıldı..");
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                Console.WriteLine("'Kitaplar' Veritabanı mevcut. İşlemler bu Veri tabanı üzerinden Gerçekleştirilecektir.");
            }
            Conn.Close();
        }
    }
}
