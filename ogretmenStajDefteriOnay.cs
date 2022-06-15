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
    public partial class ogretmenStajDefteriOnay : Form
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StajTakibi;Integrated Security=True");
        DataTable dt = new DataTable();

        public ogretmenStajDefteriOnay()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ogretmenStajDefteriOnay_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from staj_belge_yukleme";
            dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            
            con.Close();

            comboBox1.Items.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from staj_belge_yukleme";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            SqlDataAdapter listele = new SqlDataAdapter("select * from staj_belge_yukleme where staj_danismani='" + textBox6.Text + "'", con);
            listele.Fill(dt);
            dataGridView1.DataSource = dt;
            listele.Dispose();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;

            dataGridView1.Columns[0].Width = 150;
          //  dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[0].HeaderText = "Öğrenci numarası";
           // dataGridView1.Columns[2].HeaderText = "Öğrenci staj belgesi";
            dataGridView1.Columns[3].HeaderText = "Staj onay durumu";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update staj_belge_yukleme set staj_onay ='" + "Onaylandı" + "' where ogrenci_no='" + comboBox2.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Staj kabul edildi.");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update staj_belge_yukleme set staj_onay ='" + "Reddedildi" + "' where ogrenci_no='" + comboBox2.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Staj reddedildi.");
            con.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cv_pdf gor = new cv_pdf();
            gor.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            anamenu frm = new anamenu();
            frm.Show();
            this.Hide();
        }
    }
}
