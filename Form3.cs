using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection(Form1.sqlbaglanti);
        MySqlCommand komut;
        MySqlDataReader dr;
        public string yetki;

        public void yenile()
        {
            bunifuDropdown1.Items.Clear();
            
            baglanti.Open();
            komut = new MySqlCommand("Select kullanici_adi from yetkililer where yetki != 4", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                bunifuDropdown1.Items.Add(dr["kullanici_adi"].ToString());
               
            }
            baglanti.Close();

        }
        

        private void Form3_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown2.Text == "Yetkisizleştir")
            {
                yetki = "0";
            }

            if (bunifuDropdown2.Text == "Kasiyer")
            {
                yetki = "1";
            }
            if (bunifuDropdown2.Text == "Kasa Sorumlusu")
            {
                yetki = "2";
            }
            if (bunifuDropdown2.Text == "Mağaza Müdür Yardımcısı")
            {
                yetki = "3";
            }
            baglanti.Open();
            komut = new MySqlCommand("UPDATE yetkililer SET yetki='" + yetki + "' WHERE kullanici_adi='" + bunifuDropdown1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Tamamlandı !", "Yetkilendirme Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

      

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();

        }
    }
}
