using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CKM.DAL
{
    static class Baglanti
    {
        static SqlConnection baglanti;

        public static SqlConnection BaglantiKablosu
        {
            get
            {
                if (baglanti != null)
                {
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    return baglanti;
                }
                else
                {
                    baglanti = new SqlConnection(Provider());
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    return baglanti;
                }
            }
        }
        private static string Provider()
        {
            string baglantiCumlesi = "BaglantiCumlesi";
            return ConfigurationManager.AppSettings[baglantiCumlesi];
        }
    }
}
