using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CKM.DAL
{
    class Baglanti
    {
        SqlConnection baglanti;

        public SqlConnection BaglantiKablosu
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
        private string Provider()
        {
            string baglantiCumlesi = "BaglantiCumlesi";
            return ConfigurationManager.AppSettings[baglantiCumlesi];
        }
    }
}
