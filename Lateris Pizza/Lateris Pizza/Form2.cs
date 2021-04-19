using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Lateris_Pizza
{
    public partial class kayit : Form
    {
       
        OleDbCommand komut;
       
        public kayit()
        {
            InitializeComponent();
        }
        int kk;
        private void kayit_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            kk = r.Next(1000, 9999);
            label6.Text = kk.ToString();





        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            this.Hide();
            giris.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
             OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Access");//access veri bağlanıtınızı ekleyiniz data source kısmına
         
           
                baglanti.Open();
                string sorgu = "INSERT INTO giris (Kul,sifre) VALUES(@kul,@sifre)";
                komut = new OleDbCommand(sorgu, baglanti);

               
            try
            {
                komut.Parameters.AddWithValue("@kul", ykul.Text);
                komut.Parameters.AddWithValue("@sifre", ysifre.Text);
                if (kk == Convert.ToInt32(textBox1.Text))
                {
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Yeni Kayıt Oluşturuldu!", "Lateris Pizza Sistem Mesajı");
                    ykul.Text = "";
                    ysifre.Text = "";
                    textBox1.Text = "";
                }

                else if (kk != Convert.ToInt32(textBox1.Text))
                {
                    MessageBox.Show("Güvenlik Kodu Yanlış Girildi!", "Lateris Pizza Sistem Mesajı");
                    baglanti.Close();
                    ykul.Text = "";
                    ysifre.Text = "";
                    textBox1.Text = "";
                    Random r = new Random();
                    kk = r.Next(1000, 9999);
                    label6.Text = kk.ToString();
                    baglanti.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Dolduralabilir Alanlar Boş Geçilemez", "Lateris Pizza Sistem Mesajı");
                ykul.Text = "";
                ysifre.Text = "";
                textBox1.Text = "";
                Random r = new Random();
                kk = r.Next(1000, 9999);
                label6.Text = kk.ToString();
            }
                
         
                    


                
                

            }
            
           
            
          
        }

      

      
    }

