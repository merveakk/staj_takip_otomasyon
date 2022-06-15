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
using System.IO;

namespace staj_takip
{
    public partial class ogrenciStajBelgesiYukle : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StajTakibi;Integrated Security=True");

        public ogrenciStajBelgesiYukle()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anamenu frm = new anamenu();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "PDF Documents(*.pdf)|*.pdf", ValidateNames = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Bu dosyayı eklemek istediğinize emin misiniz?", "Belge yükle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        string filename=dlg.FileName;
                        UploadFile(filename);
                    }
                }
            }
        }

        public void UploadFile(string file)
        {
            con.Open();
            FileStream fstream = File.OpenRead(file);
            byte[] contents = new byte[fstream.Length];
            fstream.Read(contents, 0, (int)contents.Length);
            fstream.Close();
            using (cmd = new SqlCommand("insert into staj_belge_yukleme(ogrenci_no,staj_danismani,staj_defteri,staj_onay) values(@ogrenci_no,@staj_danismani,@pdf,'Onay bekleniyor')", con))
            {
                cmd.Parameters.AddWithValue("@ogrenci_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@staj_danismani", textBox2.Text);
                cmd.Parameters.AddWithValue("@pdf", contents);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Başarıyla gönderildi.");
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
