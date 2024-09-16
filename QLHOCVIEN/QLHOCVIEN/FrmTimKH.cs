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
    public partial class FrmTimKH : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;
        public FrmTimKH()
        {
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
            InitializeComponent();
        }
        public DataTable LoadGV()
        {
            SqlCommand sqlCommand;

            if (string.IsNullOrEmpty(txt_thongtin.Text))
            {
                sqlCommand = new SqlCommand("select * from KhoaHoc", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }
            else
            {
                if (rdokh.Checked)
                {
                    sqlCommand = new SqlCommand("select * from KhoaHoc where MaKhoaHoc = @MaKhoaHoc", connn);
                    sqlCommand.Parameters.AddWithValue("@MaKhoaHoc", txt_thongtin.Text);
                    daa = new SqlDataAdapter(sqlCommand);
                }
                else if (rdotenkh.Checked)
                {
                    sqlCommand = new SqlCommand("select * from KhoaHoc where TenKhoaHoc LIKE @TenKhoaHoc", connn);
                    sqlCommand.Parameters.AddWithValue("@TenKhoaHoc", "%" + txt_thongtin.Text + "%");
                    daa = new SqlDataAdapter(sqlCommand);
                }
            }

            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }

        private void FrmTimKH_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadGV();
        }

        private void btn_xemgv_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadGV();
        }

        private void rdokh_CheckedChanged(object sender, EventArgs e)
        {
            if(rdokh.Checked == true)
            {
               
            }    
         
        }

        private void rdotenkh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdotenkh.Checked == true)
            {
               
            }
        }
    }
}
