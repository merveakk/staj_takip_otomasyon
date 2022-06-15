using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace staj_takip
{
    public partial class ogretmenBasvurular : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StajTakibi;Integrated Security=True");
        DataTable dt = new DataTable();
        public ogretmenBasvurular()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            SqlDataAdapter listele = new SqlDataAdapter("select * from staj_basvuru where staj_danismani='" + textBox6.Text + "'", con);
            listele.Fill(dt);
            dataGridView1.DataSource = dt;
            listele.Dispose();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[6].Visible = false;

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[0].HeaderText = "Öğrenci numarası";
            dataGridView1.Columns[1].HeaderText = "Firma adı";
            dataGridView1.Columns[2].HeaderText = "Başlangıç tarihi";
            dataGridView1.Columns[3].HeaderText = "Bitiş tarihi";
            dataGridView1.Columns[4].HeaderText = "Staj birimi";
            dataGridView1.Columns[5].HeaderText = "Staj konusu";
            dataGridView1.Columns[7].HeaderText = "Başvuru onay durumu";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update staj_basvuru set basvuru_onay ='" + "Onaylandı" + "' where ogrenci_no='" + comboBox2.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Staj başvurusu kabul edildi.");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update staj_basvuru set basvuru_onay ='" + "Reddedildi" + "' where ogrenci_no='" + comboBox2.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Staj başvurusu reddedildi.");
            con.Close();
        }

        private void ogretmenBasvurular_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from staj_basvuru";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            anamenu frm = new anamenu();
            frm.Show();
            this.Hide();
        }
    }
}
