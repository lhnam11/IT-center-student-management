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

namespace QLHOCVIEN
{
    public partial class Frmtimgv : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;
        public Frmtimgv()
        {

            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
            InitializeComponent();
        }
        public DataTable LoadGV()
        {
            SqlCommand sqlCommand;

            if (txt_mgv.Text.Length <= 0)
            {
                sqlCommand = new SqlCommand("select * from GiangVien", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }

            else if (txt_mgv.Text.Length > 0)
            {
                sqlCommand = new SqlCommand("select * from GiangVien where MaGiangVien ='" + txt_mgv.Text + "'", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }

            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }

        private void Frmtimgv_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadGV();
        }

        private void btn_xemgv_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadGV();
        }

        private void btndongkq_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Xác nhận đóng kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
         
                this.Close();
            }
        }
    }
}
