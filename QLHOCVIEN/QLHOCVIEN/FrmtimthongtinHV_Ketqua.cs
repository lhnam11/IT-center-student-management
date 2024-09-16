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
    public partial class FrmtimthongtinHV_Ketqua : Form
    {

        SqlConnection connn;
        SqlDataAdapter daa;
        public FrmtimthongtinHV_Ketqua()
        {
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
            InitializeComponent();
        }
        public DataTable LoadHV()
        {
            SqlCommand sqlCommand;

            if (txt_mahocvien.Text.Length <= 0)
            {
                sqlCommand = new SqlCommand("select * from HocVien", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }

            else if (txt_mahocvien.Text.Length > 0)
            {
                sqlCommand = new SqlCommand("select * from HocVien where MaHocVien ='" + txt_mahocvien.Text + "'", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }

            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }
        public DataTable LoadKQHV()
        {
            SqlCommand sqlCommand;

            if (txt_mhv.Text.Length <= 0)
            {
                sqlCommand = new SqlCommand("select d.MaHocVien,h.HoTen,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }

            else if (txt_mhv.Text.Length > 0)
            {
                sqlCommand = new SqlCommand("select d.MaHocVien,h.HoTen,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc and d.MaHocVien ='" + txt_mhv.Text + "'", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }

            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }
        private void FrmtimthongtinHV_Ketqua_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadHV();
            dataGridView2.DataSource = LoadKQHV();
        }

        private void btn_xemtthv_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadHV();
        }

        private void btndonghv_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Xác nhận đóng kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Close();
            }

        }

        private void btnDongXKQ_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Xác nhận đóng kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void btn_xemkq_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = LoadKQHV();
        }
    }

}
