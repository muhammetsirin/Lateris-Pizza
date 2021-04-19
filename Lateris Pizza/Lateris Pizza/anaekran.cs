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
    public partial class anaekran : Form
    {

        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataAdapter da;
         void goruntule()
        {
          
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=access");////access veri bağlanıtınızı ekleyiniz data source kısmına
            baglanti.Open();
            da = new OleDbDataAdapter("SELECT * FROM  bilgiler",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        public anaekran()
        {
            InitializeComponent();

        }
     

        private void anaekran_Load(object sender, EventArgs e)
        {
            goruntule();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void yenisiparis_Click(object sender, EventArgs e)
        {   
            adtext.Clear();
            soyadText.Clear();
            telText.Clear();
            adresText.Clear();
            postaText.Clear();
            ekstra.Clear();
            malzemetext.Clear();
            icecek.Clear();
            pizzasec.Clear();
            id.Text = "";
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            giris giris = new giris();
            giris.Show();

        }
       
        private void kaydet_Click(object sender, EventArgs e)
        {
            string sorgu= "INSERT INTO bilgiler (Ad,Soyad,Telefon,Eposta,Adres,PizzaSecim,Malzeme,EkstraMalzeme,Icecek) VALUES(@ad,@soyad,@tel,@eposta,@adres,@pizza,@malzeme,@ekstra,@icecek)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", adtext.Text);
            komut.Parameters.AddWithValue("@soyad", soyadText.Text);
            komut.Parameters.AddWithValue("@tel", telText.Text);
            komut.Parameters.AddWithValue("@eposta", postaText.Text);
            komut.Parameters.AddWithValue("@adres", adresText.Text);
            komut.Parameters.AddWithValue("@pizza", pizzasec.Text);
            komut.Parameters.AddWithValue("@malzeme", malzemetext.Text);
            komut.Parameters.AddWithValue("@ekstra", ekstra.Text);
            komut.Parameters.AddWithValue("@icecek", icecek.Text);




            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            goruntule();


        }

        private void sipgüncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE bilgiler SET Ad=@ad,Soyad=@soyad,Telefon=@tel,Eposta=@eposta,Adres=@adres,PizzaSecim=@pizza,Malzeme=@malzeme,EkstraMalzeme=@ekstra,Icecek=@icecek WHERE id=@id";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", adtext.Text);
            komut.Parameters.AddWithValue("@soyad", soyadText.Text);
            komut.Parameters.AddWithValue("@tel", telText.Text);
            komut.Parameters.AddWithValue("@eposta", postaText.Text);
            komut.Parameters.AddWithValue("@adres", adresText.Text);
            komut.Parameters.AddWithValue("@pizza", pizzasec.Text);
            komut.Parameters.AddWithValue("@malzeme", malzemetext.Text);
            komut.Parameters.AddWithValue("@ekstra", ekstra.Text);
            komut.Parameters.AddWithValue("@icecek", icecek.Text);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(id.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            goruntule();
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM bilgiler WHERE id=@id";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            goruntule();
                }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            adtext.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            soyadText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            telText.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            postaText.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            adresText.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pizzasec.Text= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            malzemetext.Text= dataGridView1.CurrentRow.Cells[7].Value.ToString();
            ekstra.Text= dataGridView1.CurrentRow.Cells[8].Value.ToString();
            icecek.Text= dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void teslim_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM bilgiler WHERE id=@id";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Süper Siparinişiniz Tamamlandı!", "Lateris Pizza");
            goruntule();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
