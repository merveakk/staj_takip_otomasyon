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
    public partial class cv_pdf : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StajTakibi;Integrated Security=True");

        public cv_pdf()
        {
            InitializeComponent();
            con.Open();
            SqlCommand komut = new SqlCommand("Select *from staj_belge_yukleme where ogrenci_no= '123456'", con);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                axAcroPDF2.LoadFile(read["staj_defteri"].ToString());
            }
            con.Close();
            
        }
    }
}
