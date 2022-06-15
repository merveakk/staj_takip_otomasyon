using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace staj_takip
{
    public partial class anamenu : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StajTakibi;Integrated Security=True");


        public anamenu()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void button5_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox5.Text;
            string sifre = textBox6.Text;

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select *From ogrenci_giris where ogrenci_no= '" + textBox5.Text + "' And ogrenci_sifre= '" + textBox6.Text + "'";
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                ogrenci_menu frm = new ogrenci_menu();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya Şifre");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tcKimlik = textBox4.Text;
            string sifre = textBox3.Text;

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select *From ogretmen_giris where ogretmen_tc= '" + textBox4.Text + "' And ogretmen_sifre= '" + textBox3.Text + "'";
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                ogretmen_menu frm = new ogretmen_menu();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kimlik numarası veya Şifre");
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

