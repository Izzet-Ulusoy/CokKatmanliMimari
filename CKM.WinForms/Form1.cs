using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKM.BL;

namespace CKM.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OgretmenBL OgretmenIslemleri = new OgretmenBL();
        private void btnOgretmenKaydet_Click(object sender, EventArgs e)
        {
            int sonuc = OgretmenIslemleri.OgretmenEkle(Adi: txtAdi.Text, Soyadi: txtSoyadi.Text, Bransi: txtBransi.Text);
            MessageBox.Show(sonuc.ToString() + " Öğretmen Eklenmiştir");
        }

        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            OgrenciEkle frmOgrenciEkle = new OgrenciEkle();
            frmOgrenciEkle.Show();

        }
    }
}
