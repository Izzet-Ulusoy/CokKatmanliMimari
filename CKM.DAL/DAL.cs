using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CKM.DAL
{
    public class DAL
    {
        Baglanti baglanti = new Baglanti();
        private SqlCommand SorguYaz(string Sorgu, CommandType SorguTipi)
        {
            SqlCommand cmd = baglanti.BaglantiKablosu.CreateCommand();
            cmd.CommandText = Sorgu;
            cmd.CommandType = SorguTipi;
            return cmd;
        }
        List<SqlParameter> Parametreler = new List<SqlParameter>();
        public void InputParametreEkle(string ParametreAdi, object ParametreDegeri)
        {
            SqlParameter parametre = new SqlParameter();
            parametre.ParameterName = ParametreAdi;
            parametre.Value = ParametreDegeri;
            Parametreler.Add(parametre);
        }
        public void OutPutParametreEkle(string ParametreAdi, object ParametreDegeri)
        {
            try
            {
                SqlParameter parametre = new SqlParameter();
                parametre.ParameterName = ParametreAdi;
                parametre.Value = ParametreDegeri;
                parametre.Direction = ParameterDirection.Output;
                Parametreler.Add(parametre);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void ParametreleriSorguyaEkle(SqlCommand CommandNesnesi)
        {
            CommandNesnesi.Parameters.AddRange(Parametreler.ToArray());
        }
        public object ParametreDegeriniGetir(string ParametreAdi)
        {
            foreach (var item in Parametreler)
            {
                if (item.ParameterName == ParametreAdi)
                {
                    return item.Value.ToString();
                }
            }
            return null;
        }
        public int EkleSilGuncelle(string Sorgu, CommandType SorguTipi)
        {
            try
            {
                SqlCommand cmd = SorguYaz(Sorgu: Sorgu, SorguTipi: SorguTipi);
                ParametreleriSorguyaEkle(cmd);
                int Sonuc = cmd.ExecuteNonQuery();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Connection.Dispose();
                cmd.Dispose();
                return Sonuc;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public object IlkSatirIlkSutun(string Sorgu, CommandType SorguTipi)
        {
            try
            {
                SqlCommand cmd = SorguYaz(Sorgu: Sorgu, SorguTipi: SorguTipi);
                ParametreleriSorguyaEkle(cmd);
                object Sonuc = cmd.ExecuteScalar();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Connection.Dispose();
                cmd.Dispose();
                return Sonuc;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public SqlDataReader DRVeriCek(string Sorgu, CommandType SorguTipi)
        {
            try
            {
                SqlCommand cmd = SorguYaz(Sorgu, SorguTipi);
                ParametreleriSorguyaEkle(cmd);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public DataTable DTVeriCek(string Sorgu, CommandType SorguTipi)
        {
            try
            {
                SqlDataReader dr = DRVeriCek(Sorgu: Sorgu, SorguTipi: SorguTipi);
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
