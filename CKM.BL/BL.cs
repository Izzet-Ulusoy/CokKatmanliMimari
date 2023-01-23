using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKM.DAL;

namespace CKM.BL
{
    public class BL
    {
        DAL.DAL dal = new DAL.DAL();
        public int OgretmenEkle(string Adi, string Soyadi, string Bransi)
        {
            dal.EkleSilGuncelle("", CommandType.StoredProcedure);
            return 1;
        }
    }
}
