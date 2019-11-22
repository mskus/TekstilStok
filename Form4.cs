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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection(Form1.sqlbaglanti);
        MySqlCommand komut;
        public string yetki;


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
            if (bunifuTextBox1.Text != "" && bunifuTextBox2.Text != "" )
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
                komut = new MySqlCommand("INSERT INTO yetkililer(kullanici_adi,sifre,yetki) VALUES ('" + bunifuTextBox1.Text + "','" + bunifuTextBox2.Text + "','" +yetki+ "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı!", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                
            }
            else MessageBox.Show("Lütfen Bütün Alanları Doldurunuz!", "Eksik Giriş Yaptınız", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
           

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
    }
}
