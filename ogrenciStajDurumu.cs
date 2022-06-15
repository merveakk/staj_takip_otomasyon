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
    public partial class ogrenciStajDurumu : Form
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StajTakibi;Integrated Security=True");
        DataTable dt = new DataTable();

        public ogrenciStajDurumu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            SqlDataAdapter listele = new SqlDataAdapter("select * from staj_belge_yukleme where ogrenci_no='" + textBox6.Text + "'", con);
            listele.Fill(dt);
            dataGridView1.DataSource = dt;
            listele.Dispose();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;

            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[3].Width = 150;

            dataGridView1.Columns[1].HeaderText = "Staj Danışmanı";
            dataGridView1.Columns[3].HeaderText = "Staj onay durumu";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anamenu frm = new anamenu();
            frm.Show();
            this.Hide();
        }
    }
}
