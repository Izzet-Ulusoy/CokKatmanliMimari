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
    public class OgrenciBL
    {
        DAL.DAL dal = new DAL.DAL();
        public int OgrenciEkle(string Adi, string Soyadi, string No, int OgretmenID)
        {
            dal.InputParametreEkle(DBParameterNames.Adi, Adi);
            dal.InputParametreEkle(DBParameterNames.Soyadi, Soyadi);
            dal.InputParametreEkle(DBParameterNames.No, No);
            dal.InputParametreEkle(DBParameterNames.OgretmenID, OgretmenID);
            int sonuc = dal.EkleSilGuncelle(DBStoreProcedureNames.SpOgrenciEkle, CommandType.StoredProcedure);
            return sonuc;
        }
       
    }
}
