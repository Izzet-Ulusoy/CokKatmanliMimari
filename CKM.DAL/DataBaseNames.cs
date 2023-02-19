using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKM.DAL
{
    public class DataBaseNames
    {
    }
    /// <summary>
    /// NON @p
    /// </summary>
    public class DBColumnNames
    {
        public static string ID = "ID";
        public static string OgretmenID = "OgretmenID";
        public static string Adi = "Adi";
        public static string Soyadi = "Soyadi";
        public static string Bransi = "Bransi";
        public static string No = "No";
    }
    /// <summary>
    /// @p
    /// </summary>
    public class DBParameterNames
    {
        public static string ID = "@pID";
        public static string OgretmenID = "@pOgretmenID";
        public static string Adi = "@pAdi";
        public static string Soyadi = "@pSoyadi";
        public static string Bransi = "@pBransi";
        public static string No = "@pNo";
    }
    public class DBStoreProcedureNames
    {
        public static string SpOgretmenEkle = "SP_OgretmenEkle";
        public static string SpOgrenciEkle = "SP_OgrenciEkle";
        public static string SpOgretmenleriCek = "SP_OgretmenleriCek";


    }
}
