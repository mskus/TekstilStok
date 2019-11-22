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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection(Form1.sqlbaglanti);
        MySqlCommand komut;

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            komut = new MySqlCommand("insert into kupon values('"+kuponid.Text+"','"+bunifuDropdown2.Text+"','"+kuponadet.Text+"')", baglanti);
            MessageBox.Show("Başarılı Şekilde Kupon Kaydedildi !", "Kaydedildi ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
