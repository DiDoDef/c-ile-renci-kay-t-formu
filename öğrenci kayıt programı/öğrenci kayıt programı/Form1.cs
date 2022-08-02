using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace öğrenci_kayıt_programı
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=pc-\sqlexpress;Initial Catalog=okul;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from ogrenciler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {// data grid seçilen satırdaki verileri texboxa aktar
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();//ad
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();//soyad
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();//tc no
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();//tel no
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();//öğrenci no

        }

        private void button3_Click(object sender, EventArgs e)
        {//ekle butonu

            string t1 = textBox1.Text;//ad
            string t2 = textBox2.Text;//soyad
            string t3 = textBox3.Text;//tc no
            string t4 = textBox4.Text;//tel no
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into ogrenciler (ogr_adi,ogr_soyadi,ogr_tc,ogr_tel)values('" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {//temizle button
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {//güncelle butonu
            string t1 = textBox1.Text;//ad
            string t2 = textBox2.Text;//soyad
            string t3 = textBox3.Text;//tc no
            string t4 = textBox4.Text;//tel no
            string t5 = textBox5.Text;//öğrenci no
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update ogrenciler set ogr_adi='" + t1 + "',ogr_tc='" + t3 + "',ogr_soyadi='" + t2 + "',ogr_tel='" + t4 + "'where ogr_no='" + t5 + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void button1_Click(object sender, EventArgs e)
        {//sil butonu
            string t5 = textBox5.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from ogrenciler where ogr_no=('" + t5 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }
    }
}
