using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi_039
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public List<Pemesanann> Pemesanan()
        {
            List<Pemesanann> pemesanans = new List<Pemesanann>(); // proses utk mendeclare nama list yang sudah dibuat
            try
            {
                string sql = " select ID_Reservasi, Nama_Customer, No_Telpon, " + "Jumlah_Pemesanan, Nama_Lokasi from dbo.Pemesanann p join dbo.Lokasi l on p.ID_lokasi = l.ID_lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    /*nama class*/
                    Pemesanann data = new Pemesanann(); // deklarasi data, mengambil 1persatu dari database
                    //bentuk array
                    data.ID_Reservasi = reader.GetString(0);
                    data.Nama_Customer = reader.GetString(1);
                    data.No_Telpon = reader.GetString(2);
                    data.Jumlah_Pemesanan = reader.GetInt32(3);
                    data.ID_Lokasi = reader.GetString(4);
                    pemesanans.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return pemesanans;
        }

        string constring = "Data Source=YAPART\\YOGA;Initial Catalog=WCFReservasi;Persist Security Info=True;User ID=sa;Password=Crandle1";
        SqlConnection connection;
        SqlCommand com;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<DetailLokasi> DetailLokasi()
        {
            List<DetailLokasi> LokasiFull = new List<DetailLokasi>();
            try
            {
                string sql = "select ID_Lokasi, Nama_Lokasi, Deskripsi_Full, Kouta from dbo.Lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DetailLokasi data = new DetailLokasi();
                    data.ID_Lokasi = reader.GetString(0);
                    data.Nama_Lokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kouta = reader.GetInt32(3);
                    LokasiFull.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }
            
        public string Pemesanann(string ID_Reservasi, string Nama_Customer, string No_Telpon, int Jumlah_Pemesanan, string ID_Lokasi)
        {
            string a = "Gagal";
            try
            {
                string sql = "insert into dbo.Pemesanann values ('" + ID_Reservasi + "','" + Nama_Customer + "','" + No_Telpon + "',"
                    + "" + Jumlah_Pemesanan + ",'" + ID_Lokasi + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                string sql2 = "update dbo.Lokasi set Kuota = Kuota - " + Jumlah_Pemesanan + " where ID_lokasi = '" + ID_Lokasi + "' ";
                connection = new SqlConnection(constring); //fungsi konek database
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return a;
        }

        public string editPemesanan(string ID_Reservasi, string Nama_Customer, string No_Telpon)
        {
            string a = "gagal";
            try
            {
                string sql = "update dbo.Pemesanann set Nama_Customer = '" + Nama_Customer + "', No_telpon = '" + No_Telpon + "'" + " where ID_reservasi = '" + ID_Reservasi + "' ";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return a;
        }
        public string deletePemesanan(string ID_Reservasi)
        {
            string a = "gagal";
            try
            {
                string sql = "delete from dbo.Pemesanann where ID_Reservasi = '" + ID_Reservasi + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return a;
        }

        public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }
 
    }
}
