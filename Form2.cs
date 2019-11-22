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
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }

        MySqlConnection baglanti = new MySqlConnection(Form1.sqlbaglanti);
        MySqlCommand komut;
        MySqlDataReader dr;
        public int toplamucret;
        public string link, linkadresi;
        public string yetkili;
        public string yetkisi;
        public int fisnumarasi;
        public int iadenumarasi;

        public void yenile()
        {
            stokad.Text = "";
            stokadet.Text = "";
            stokbarkod.Text = "";
            stokbeden.Text = "";
            stokfiyat.Text = "";
            stokresim.Text = "";
            pictureBox1.ImageLocation = "";


            comboboxsatisadet.Items.Clear();
            comboboxsatisbeden.Items.Clear();
            comboboxsatisbarkod.Items.Clear();
            comboboxsatisadet.Text = "";
            comboboxsatisbeden.Text = "";
            comboboxsatisbarkod.Text = "";


            comboboxsatisbarkod.Text = "";
            comboboxsatisbeden.Text = "";
            comboboxsatisadet.Text = "";



            comboboxsorgu.Items.Clear();
            baglanti.Open();
            komut = new MySqlCommand("Select distinct barkod_no from urunler", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboboxsorgu.Items.Add(dr["barkod_no"].ToString());
                comboboxsatisbarkod.Items.Add(dr["barkod_no"].ToString());

            }
            baglanti.Close();            
            bunifuMaterialTextbox1.Text = "Sayın "+yetkili;


            MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select * from urunler ", baglanti);
            DataSet dataset = new DataSet();
            dataAdaptor.Fill(dataset, "urunler");
            dataGridView2.DataSource = dataset.Tables["urunler"];
            

            girisguncellebuton.Visible = false;
            giriskaydetbuton.Visible = false;

            
        }

        //Mail Ayarları
        public bool MailGonder(string konu = "E-Fatura", string icerik = "Bu Mail Bitirme Projesi Amaçlı Atılmaktadır Hiç Bir Mali Değeri Yoktur.")
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("musteribilgi@yunusturhan.com");
            //
            ePosta.To.Add(satismail.Text);
            //
            ePosta.Attachments.Add(new Attachment(@"e-fatura.pdf"));
            //
            ePosta.Subject = konu;
            //
            ePosta.Body = icerik;
            //
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential("musteribilgi@yunusturhan.com", "123321YunusTurhan");
            smtp.Port = 587;
            smtp.Host = "mail.yunusturhan.com";
            smtp.EnableSsl = false;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;
        }


        //PDF Ayarları
        public void PdfHazirla()
        {
            iTextSharp.text.Document fis = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(300, 600));
            iTextSharp.text.Font normalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10f, iTextSharp.text.Font.NORMAL);

            iTextSharp.text.Font italikFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10f, iTextSharp.text.Font.ITALIC);

            
            

            iTextSharp.text.Font tahomaFont = iTextSharp.text.FontFactory.GetFont("Tahoma", 10f);


            PdfWriter.GetInstance(fis, new FileStream("D:e-fatura.pdf", FileMode.Create));
            fis.AddAuthor("Yunus Turhan");
            fis.AddCreationDate();
            fis.AddSubject("Bilgilendirme Maili");



            if (fis.IsOpen() == false)
            {
                fis.Open();
            }

            fis.Add(new Paragraph(mailicerigi.Text));
            
            fis.Close();
        }

        public DateTime dateTime = DateTime.Now;

        private void Form2_Load(object sender, EventArgs e)
        {            
            
            yenile();
            

            if (yetkisi == "1")
            {

                tabControl1.Controls.Remove(tabPage2);
                tabControl2.Controls.Remove(tabPage4);
                tabControl2.Controls.Remove(tabPage6);
            }
            if (yetkisi == "2")
            {

                tabControl1.Controls.Remove(tabPage2);
                tabControl2.Controls.Remove(tabPage4);
                
            }
            if (yetkisi == "3")
            {
                bunifuThinButton22.Visible = false;
            }
            
            timer1.Start();

            baglanti.Open();
            komut = new MySqlCommand("Select MAX(fis_no) from satis ", baglanti);
            dr = komut.ExecuteReader();
            dr.Read();
            
            fisnumarasi = dr.GetInt32(0);
            satisfisno.Text = (fisnumarasi + 1).ToString();
            baglanti.Close();


            baglanti.Open();
            komut = new MySqlCommand("Select MAX(iade_no) from iade ", baglanti);
            dr = komut.ExecuteReader();
            dr.Read();

            iadenumarasi = dr.GetInt32(0);
            iadenotutantextbox.Text = (iadenumarasi + 1).ToString();
            baglanti.Close();




            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.RowHeadersVisible = false;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.RowHeadersVisible = false;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }


        //Sorgu Sayfası

        private void bunifuThinButton2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select * from urunler where barkod_no='" + comboboxsorgu.SelectedItem + "'  ", baglanti);
            DataSet dataset = new DataSet();
            dataAdaptor.Fill(dataset, "urunler");
            dataGridView1.DataSource = dataset.Tables["urunler"];

            baglanti.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboboxsorgu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            sorguad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            sorgubeden.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            sorgufiyat.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString() + " ₺";
            sorguadet.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            pictureBox1.ImageLocation = @"Image\" + dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }
        
        //Stok Giriş Sayfası

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            stokresim.Text = openFileDialog1.FileName;
            pictureBox2.ImageLocation = stokresim.Text;
            
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (stokad.Text != "" && stokadet.Text != "" && stokbeden.Text != "" && stokfiyat.Text != "" && stokresim.Text != "")
            {
                link = stokresim.Text;
                linkadresi = link.Substring(stokresim.TextLength - 7);
                baglanti.Open();
                komut = new MySqlCommand("INSERT INTO urunler(barkod_no,urun_adi, bedeni, fiyati, adet, urun_resmi) VALUES ('" + stokbarkod.Text + "','" + stokad.Text + "','" + stokbeden.Text + "','" + stokfiyat.Text + "','" + stokadet.Text + "','" + linkadresi + "'  )", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı!", "Giriş Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

               
                
            }
            else MessageBox.Show("Lütfen Bütün Alanları Doldurunuz!", "Eksik Giriş Yaptınız", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            yenile();
        }
        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            yenile();
            stokbarkod.Enabled = true;
            girisguncellebuton.Visible = false;
            giriskaydetbuton.Visible = true;



        }
        private void girisguncellebuton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (stokresim.TextLength >= 10)
            {
                link = stokresim.Text;
                linkadresi = link.Substring(stokresim.TextLength - 7);
            }
            else linkadresi = stokresim.Text;
            komut = new MySqlCommand("UPDATE urunler SET urun_adi='" + stokad.Text + "', bedeni='" + stokbeden.Text + "', fiyati='" + stokfiyat.Text + "', adet='" + stokadet.Text + "', urun_resmi='" + linkadresi + "' where barkod_no='" + stokbarkod.Text + "' and bedeni='" + stokbeden.Text + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Başarılı!", "Giriş Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            yenile();
            
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            stokbarkod.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            stokad.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            stokbeden.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            stokfiyat.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString() + " ₺";
            stokadet.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            stokresim.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            pictureBox2.ImageLocation = @"Image\" + dataGridView2.CurrentRow.Cells[5].Value.ToString();
            stokbarkod.Enabled = false;
            girisguncellebuton.Visible = true;
            giriskaydetbuton.Visible = false;
        }
      
        //satış

        private void comboboxsatisbarkod_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxsatisadet.Items.Clear();
            comboboxsatisbeden.Items.Clear();
            comboboxsatisadet.Text = "";
            comboboxsatisbeden.Text = "";
            baglanti.Open();
            
            MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select * from urunler where barkod_no='" + comboboxsorgu.SelectedItem + "'  ", baglanti);

            komut = new MySqlCommand("select * from urunler where barkod_no='" + comboboxsatisbarkod.SelectedItem + "'  ", baglanti);
            dr = komut.ExecuteReader();
            
            while (dr.Read())
            {
                
                comboboxsatisbeden.Items.Add(dr["bedeni"].ToString());
                if (dr.GetInt32(4) < 9)
                {
                    comboboxsatisadet.Items.Clear();

                    for (int i = 1; i <= dr.GetInt32(4); i++)
                    {
                        comboboxsatisadet.Items.Add(i);

                    }
                }
                else
                {
                    comboboxsatisadet.Items.Clear();
                    for (int i = 1; i <= 9; i++)
                    {
                        comboboxsatisadet.Items.Add(i);

                    }
                }
            }
            baglanti.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if (comboboxsatisbarkod.Text != "" && comboboxsatisadet.Text != "" &&comboboxsatisbeden.Text!="" )
            {
                baglanti.Open();
                MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select * from urunler where barkod_no='" + comboboxsorgu.SelectedItem + "'  ", baglanti);

                komut = new MySqlCommand("select barkod_no , urun_adi , bedeni, fiyati ,adet,urun_resmi from urunler where barkod_no='" + comboboxsatisbarkod.SelectedItem + "'  ", baglanti);
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboboxsatisbeden.Items.Add(dr["bedeni"].ToString());
                }
                satislistbarkod.Items.Add(dr["barkod_no"].ToString());
                satislisturunadi.Items.Add(dr["urun_adi"].ToString());
                satislistbedeni.Items.Add(comboboxsatisbeden.Text);
                satislistadet.Items.Add(comboboxsatisadet.Text);
                satislistfiyat.Items.Add(dr["fiyati"].ToString());

                toplamucret += dr.GetInt32(3) * Int32.Parse(comboboxsatisadet.Text);
                baglanti.Close();
                satisucret.Text = toplamucret.ToString();
            }
            else
                        MessageBox.Show("Henüz Ürün Bilgilerini Seçmediniz !", "Ürün Bilgilerini Girin", MessageBoxButtons.OK, MessageBoxIcon.Error);


            yenile();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            int secilen = satislistbarkod.SelectedIndex;
            if(secilen >=0 )
            {
                toplamucret -=(Int32.Parse(satislistfiyat.Items[secilen].ToString())* Int32.Parse(satislistadet.Items[secilen].ToString()));
                satisucret.Text = toplamucret.ToString();
                satislistbarkod.Items.RemoveAt(secilen);
                satislisturunadi.Items.RemoveAt(secilen);
                satislistbedeni.Items.RemoveAt(secilen);
                satislistadet.Items.RemoveAt(secilen);
                satislistfiyat.Items.RemoveAt(secilen);
            }
            else
                MessageBox.Show("Herhangi bir seçim yapılmadı !", "Çıkarılacak Ürünü Seçin ", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            bunifuThinButton211.Enabled = true;
            kuponid.Enabled = true;


            baglanti.Open();
            
            
            int i;
            for (i = 0; i < satislistbarkod.Items.Count; i++)
            {

                komut = new MySqlCommand("INSERT INTO satis(fis_no , barkod_no,bedeni, fiyat, adet,satis_tar) VALUES (" + Convert.ToInt32(satisfisno.Text) + "," + Convert.ToInt32(satislistbarkod.Items[i].ToString()) + ",'" + satislistbedeni.Items[i].ToString() + "'," + Convert.ToInt32(satislistfiyat.Items[i].ToString()) + "," + Convert.ToInt32(satislistadet.Items[i].ToString()) + ",'" + dateTime.ToString("yyyy-MM-dd") +"'  )", baglanti);
                komut.ExecuteNonQuery();

                komut = new MySqlCommand("Update urunler set adet=adet- " + Convert.ToInt32(satislistadet.Items[i].ToString()) + " where barkod_no=" + Convert.ToInt32(satislistbarkod.Items[i].ToString()) + " and bedeni='" + satislistbedeni.Items[i].ToString() + "' ", baglanti);
                komut.ExecuteNonQuery();
            }
            baglanti.Close();
            MessageBox.Show("Satış Başarılı!", "Satış Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if(bunifuCheckbox1.Checked==true)
            {
                mailicerigi.Text += "Ürün Adı -- Bedeni --- Adet --- Tutarı\n";

                for (i = 0; i < satislistbarkod.Items.Count; i++)
                {
                    mailicerigi.Text += satislisturunadi.Items[i].ToString()+" --- "+ satislistbedeni.Items[i].ToString() + " --- " + satislistadet.Items[i].ToString() + " --- " + (Convert.ToInt32(satislistadet.Items[i].ToString())* Convert.ToInt32(satislistfiyat.Items[i].ToString())+ "\n\n\n");

                }


                //mailicerigi.Text += "\n\n\n\n\n";
                mailicerigi.Text +="Bizi Tercih Ettiğiniz İçin Teşekürler.";
                PdfHazirla();
                MailGonder();
            }
            
            
            toplamucret = 0;
            fisnumarasi++;
            satisfisno.Text = (fisnumarasi + 1).ToString();
            satislistbarkod.Items.Clear();
            satislistadet.Items.Clear();
            satislistbedeni.Items.Clear();
            satislistfiyat.Items.Clear();
            satislisturunadi.Items.Clear();
        }

        // İade sayfası


        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            komut = new MySqlCommand("Select * from satis where fis_no='" + iadefis.Text + "' ", baglanti);
            MySqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                string fisalistar = dr["satis_tar"].ToString();
                DateTime fisalistarih = Convert.ToDateTime(fisalistar);
                baglanti.Close();
                baglanti.Open();
                string buguntar = (DateTime.Now).ToString();
                DateTime buguntarih = Convert.ToDateTime(buguntar);
                string GunFarki = GunBul(buguntarih, fisalistarih).ToString();
                int gunsayisi = Convert.ToInt32(GunFarki);

               
                if (gunsayisi < 15)
                {
                    MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select fis_no,barkod_no,bedeni , fiyat,adet,satis_tar from satis where fis_no='" + iadefis.Text + "'  ", baglanti);
                    DataSet dataset = new DataSet();
                    dataAdaptor.Fill(dataset, "satis");
                    dataGridView3.DataSource = dataset.Tables["satis"];
                }
                else MessageBox.Show("Alış Tarihi 15 Günden Fazla Olmuş !", "Hatalı Giriş Yaptınız", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else MessageBox.Show("Eksik Ya Da Hatalı Fiş Numarası Girdiniz !", "Hatalı Giriş Yaptınız", MessageBoxButtons.OK, MessageBoxIcon.Error);

            baglanti.Close();
            
        }
        public int GunBul(DateTime dt1, DateTime dt2)
        {
            TimeSpan zaman = new TimeSpan();
            zaman = dt1 - dt2;
            return Math.Abs(zaman.Days);
        }


        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 1)
            {
                baglanti.Open();
                bunifuDatePicker2.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[5].Value.ToString());

                komut = new MySqlCommand("INSERT INTO iade(iade_no,fis_no , barkod_no,bedeni, fiyat, adet,satis_tar ,iade_tar) VALUES (" + iadenotutantextbox.Text + "," + dataGridView3.CurrentRow.Cells[0].Value.ToString() + "," + dataGridView3.CurrentRow.Cells[1].Value.ToString() + ",'" + dataGridView3.CurrentRow.Cells[2].Value.ToString() + "'," + dataGridView3.CurrentRow.Cells[3].Value.ToString() + "," + dataGridView3.CurrentRow.Cells[4].Value.ToString() + ",'" + bunifuDatePicker2.Value.ToString("yyyy-MM-dd") + "','" + bunifuDatePicker1.Value.ToString("yyyy-MM-dd") + "'  )", baglanti);
                komut.ExecuteNonQuery();

                komut = new MySqlCommand("Update urunler set adet=adet+ " + dataGridView3.CurrentRow.Cells[4].Value.ToString() + " where barkod_no=" + dataGridView3.CurrentRow.Cells[1].Value.ToString() + " and bedeni='" + dataGridView3.CurrentRow.Cells[2].Value.ToString() + "' ", baglanti);
                komut.ExecuteNonQuery();

                komut = new MySqlCommand("Delete from satis WHERE barkod_no=" + dataGridView3.CurrentRow.Cells[1].Value.ToString() + "  and bedeni='" + dataGridView3.CurrentRow.Cells[2].Value.ToString() + "' "     , baglanti);
                komut.ExecuteNonQuery();


                baglanti.Close();
                MessageBox.Show("İade Başarılı!", "İade Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            MessageBox.Show("İade Edilecek Ürün Seçilmedi !", "İade Tamamlanamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            iadenumarasi++;
            iadenotutantextbox.Text = (iadenumarasi + 1).ToString();
            yenile();

        }



        // Yetkili Sayfası
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.Show();
        }



        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.Text = "Bulunan Ürünler";
            toplamucret = 0;
            baglanti.Open();
            MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select * from urunler where adet >0 order by barkod_no  ", baglanti);
            DataSet dataset = new DataSet();
            dataAdaptor.Fill(dataset, "urunler");
            dataGridView4.DataSource = dataset.Tables["urunler"];

            komut = new MySqlCommand("select * from urunler  ", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                

                toplamucret += dr.GetInt32(3) * dr.GetInt32(4);
            }
            raportoplamtutar.Text = toplamucret.ToString() ;

            baglanti.Close();
        }

        private void bunifuThinButton24_Click_1(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.Text = "Bu Hafta Satılanlar";
            toplamucret = 0;
            baglanti.Open();
            MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select * from satis where satis_tar >= NOW() - INTERVAL 7 DAY order by satis_tar ", baglanti);
            DataSet dataset = new DataSet();
            dataAdaptor.Fill(dataset, "satis");
            dataGridView4.DataSource = dataset.Tables["satis"];

            komut = new MySqlCommand("select * from satis where satis_tar >= NOW() - INTERVAL 7 DAY", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {


                toplamucret += dr.GetInt32(3) * dr.GetInt32(4);
            }
            raportoplamtutar.Text = toplamucret.ToString();

            baglanti.Close();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.Text = "Bu Ay Satılanlar";
            toplamucret = 0;
            baglanti.Open();
            MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select * from satis where satis_tar >= NOW() - INTERVAL 1 MONTH order by satis_tar", baglanti);
            DataSet dataset = new DataSet();
            dataAdaptor.Fill(dataset, "satis");
            dataGridView4.DataSource = dataset.Tables["satis"];

            komut = new MySqlCommand("select * from satis where satis_tar >= NOW() - INTERVAL 1 MONTH", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {


                toplamucret += dr.GetInt32(3) * dr.GetInt32(4);
            }
            raportoplamtutar.Text = toplamucret.ToString();

            baglanti.Close();
        }


        private void bunifuThinButton27_Click_1(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.Text = "İade Alınanlar";
            toplamucret = 0;
            baglanti.Open();
            MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("select * from iade where iade_tar >= NOW() - INTERVAL 6 MONTH", baglanti);
            DataSet dataset = new DataSet();
            dataAdaptor.Fill(dataset, "iade");
            dataGridView4.DataSource = dataset.Tables["iade"];

            komut = new MySqlCommand("select * from iade where iade_tar >= NOW() - INTERVAL 6 MONTH", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {


                toplamucret += dr.GetInt32(5) * dr.GetInt32(4);
            }
            raportoplamtutar.Text = toplamucret.ToString();

            baglanti.Close();
        }


        private void bunifuButton1_Click(object sender, EventArgs e) /*Oturum Kapatma Butonu */
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)/*Form2 Kapatma */
        {
            Environment.Exit(1);
        }

        

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            satismail.Visible = false;
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {

            if (bunifuCheckbox1.Checked == false)
            {
                satismail.Visible = false;
                
            }
            else
            {
                satismail.Visible = true;
            }
        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new MySqlCommand("select * from kupon where kupon_id='"+kuponid.Text+"' ", baglanti);
            dr = komut.ExecuteReader();

            if (dr.Read())
            {

                while (dr.Read())
                {
                    toplamucret -= dr.GetInt32(1);
                    satisucret.Text = toplamucret.ToString();
                    komut = new MySqlCommand("update set adet=-1 where kupon_id='" + kuponid.Text + "' ", baglanti);


                }
                MessageBox.Show("Başarılı Şekilde Kupon Girdiniz !", "Girildi ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else MessageBox.Show("Eksik Yada Hatalı Kupon Girdiniz !", "Kupon Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            baglanti.Close();
            bunifuThinButton211.Enabled = false;
            bunifuThinButton211.ButtonText = "Kuponu Aktif Et";
            kuponid.Enabled = false;

            bunifuThinButton211.TextAlign = ContentAlignment.TopCenter;
        }

        private void bunifuThinButton211_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton211_EnabledChanged(object sender, EventArgs e)
        {
            bunifuThinButton211.ButtonText = "Kuponu Aktif Et";
            bunifuThinButton211.TextAlign = ContentAlignment.TopCenter;
        }

        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

       
    }
}
