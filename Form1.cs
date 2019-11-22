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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string sqlbaglanti = "Server=yunusturhan.com;Database=yunustu1_proje;Uid=yunustu1_turhan;Pwd='Yunus@Turhan16';Encrypt=false;AllowUserVariables=True;UseCompression=True;";
        public MySqlConnection baglan = new MySqlConnection(sqlbaglanti);
        public MySqlCommand komut;

        
        
       

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            if (bunifuTextBox1.Text != "" && bunifuTextBox2.Text != "")
            {
                baglan.Open();
                komut = new MySqlCommand("Select * from yetkililer where kullanici_adi='" + bunifuTextBox1.Text + "' and sifre ='" + bunifuTextBox2.Text + "'", baglan);
                MySqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    string yetki = dr["yetki"].ToString();
                    if (yetki != "0")
                    {
                        Form2 frm2 = new Form2();
                        frm2.yetkisi = dr["yetki"].ToString();
                        frm2.yetkili = dr["kullanici_adi"].ToString();
                        frm2.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Bu Kullanıcı Adının Sisteme Giriş İzni Yoktur !", "Yetkisiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else MessageBox.Show("Kullanıcı Adı ya da Şifre Hatalı !", "Hatalı Giriş Yaptınız", MessageBoxButtons.OK, MessageBoxIcon.Error);


                baglan.Close();
            }
            else MessageBox.Show("Lütfen Kullanıcı Adı ve Şifrenizi Giriniz !", "Eksik Giriş Yaptınız", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
     
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
