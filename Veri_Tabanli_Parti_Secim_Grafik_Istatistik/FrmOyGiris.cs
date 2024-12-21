﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Veri_Tabanli_Parti_Secim_Grafik_Istatistik
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-F1A12T8\KORAY;Initial Catalog=DBSECIMPROJE;Integrated Security=True");
        private void BtnOyGir_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into TBLILCE (ILCEAD, APARTI, BPARTI, CPARTI, DPARTI, EPARTI) Values (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtIlceAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtA.Text);
            komut.Parameters.AddWithValue("@p3", TxtB.Text);
            komut.Parameters.AddWithValue("@p4", TxtC.Text);
            komut.Parameters.AddWithValue("@p5", TxtD.Text);
            komut.Parameters.AddWithValue("@p6", TxtE.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti");
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
