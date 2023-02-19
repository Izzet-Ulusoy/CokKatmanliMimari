using CKM.DAL;
using CKM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKM.BL
{
    public class OgretmenBL
    {
        DAL.DAL dal = new DAL.DAL();
        public int OgretmenEkle(string Adi, string Soyadi, string Bransi)
        {
            dal.InputParametreEkle(DBParameterNames.Adi, Adi);
            dal.InputParametreEkle(DBParameterNames.Soyadi, Soyadi);
            dal.InputParametreEkle(DBParameterNames.Bransi, Bransi);
            int sonuc = dal.EkleSilGuncelle(DBStoreProcedureNames.SpOgretmenEkle, CommandType.StoredProcedure);
            return sonuc;
        }
        public List<Ogretmen> OgretmenleriGetir()
        {
            SqlDataReader dr = dal.DRVeriCek(DBStoreProcedureNames.SpOgretmenleriCek, CommandType.StoredProcedure);
            if (dr.HasRows)
            {
                List<Ogretmen> ogretmenler = new List<Ogretmen>();
                while (dr.Read())
                {
                    Ogretmen ogretmen = new Ogretmen
                    {
                        Adi = dr[DBColumnNames.Adi].ToString(),
                        Soyadi = dr[DBColumnNames.Soyadi].ToString(),
                        Bransi = dr[DBColumnNames.Bransi].ToString(),
                        ID = Convert.ToInt32(dr[DBColumnNames.ID].ToString())
                    };
                    ogretmenler.Add(ogretmen);
                }
                return ogretmenler;
            }
            return null;
        }
    }
}
