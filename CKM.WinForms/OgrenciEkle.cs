using CKM.BL;
using CKM.DAL;
using CKM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKM.WinForms
{
    public partial class OgrenciEkle : Form
    {
        public OgrenciEkle()
        {
            InitializeComponent();
        }
        OgrenciBL ogrenciBL = new OgrenciBL();
        OgretmenBL ogretmenBL = new OgretmenBL();
        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            ogrenciBL.OgrenciEkle(Adi: txtAdi.Text, Soyadi: txtSoyadi.Text, No: txtNo.Text, OgretmenID: 1);
        }

        private void OgrenciEkle_Load(object sender, EventArgs e)
        {
            OgretmenleriGetir();

        }
        void OgretmenleriGetir()
        {
            listBox1.Items.Clear();
            List<Ogretmen> list = ogretmenBL.OgretmenleriGetir();
            listBox1.DataSource = list;
            listBox1.ValueMember = DBColumnNames.ID;
            listBox1.DisplayMember = DBColumnNames.Adi;
        }
    }
}
