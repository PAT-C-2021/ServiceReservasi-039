using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi_039
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        string Pemesanann(string ID_Reservasi, string Nama_Customer, string No_Telpon, int Jumlah_Pemesanan, string ID_Lokasi); // Method // Proses input data
        [OperationContract]
        string editPemesanan(string ID_Reservasi, string Nama_Customer, string No_Telpon);
        [OperationContract]
        string deletePemesanan(string ID_Reservasi);
        [OperationContract]
        List<CekLokasi> ReviewLokasi(); // Menampilkan data yang ada di database (select all) // Menampilkan isi dari yang ada contract
        [OperationContract]
        List<DetailLokasi> DetailLokasi(); // Menampilkan detail lokasi
        [OperationContract]
        List<Pemesanann> Pemesanan();
    }
    [DataContract]
    public class CekLokasi
    {
        [DataMember]
        public string ID_Lokasi { get; set; }
        [DataMember]
        public string Nama_Lokasi { get; set; }
        [DataMember]
        public string Deskripsi_Singkat { get; set; }
    }

    [DataContract]
    public class DetailLokasi
    {
        [DataMember]
        public string ID_Lokasi { get; set; }
        [DataMember]
        public string Nama_Lokasi { get; set; }
        [DataMember]
        public string DeskripsiFull { get; set; }
        [DataMember]
        public int Kouta { get; set; }
    }

    [DataContract]
    public class Pemesanann
    {
        [DataMember]
        public string ID_Reservasi { get; set; }
        [DataMember]
        public string Nama_Customer { get; set; }
        [DataMember]
        public string No_Telpon { get; set; }
        [DataMember]
        public int Jumlah_Pemesanan { get; set; }
        [DataMember]
        public string ID_Lokasi { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceReservasi_087.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
