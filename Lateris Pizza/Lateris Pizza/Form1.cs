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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayit kayit = new kayit();
            this.Hide();
            kayit.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=access");//Access Veri bağlantınızı ekleyiniz
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("SELECT Kul,sifre FROM giris WHERE Kul=@kad AND sifre=@sifre",baglanti);
            sorgu.Parameters.AddWithValue("@kad", kuladi.Text);
            sorgu.Parameters.AddWithValue("@sifre", sifre.Text);
            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Lateris Pizza'ya Hoşgeldin!");
                anaekran anaekran = new anaekran();
                this.Hide();
                anaekran.Show();
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Yanlış Kullanıcı adı veya parola","Sistem Uyarısı");
            }
        }

        private void giris_Load(object sender, EventArgs e)
        {
            
        }
    }
}
