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
    public partial class frmDSKQ : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;
        public frmDSKQ()
        {
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
            InitializeComponent();
        }
        public DataTable LoadHocVien()
        {
            SqlCommand sqlCommand;

            if(txt_tenhoakhoc.Text.Length <= 0 )
            {
                sqlCommand = new SqlCommand("select d.MaHocVien,h.HoTen,h.GioiTinh,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc ", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }   
            else if(txt_tenhoakhoc.Text.Length > 0)
            {
                sqlCommand = new SqlCommand("select d.MaHocVien,h.HoTen,h.GioiTinh,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc and TenKhoaHoc =N'"+txt_tenhoakhoc.Text+"'", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }
          
            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }
        public DataTable LoadHocVien2()
        {
            SqlCommand sqlCommand;

            if (txt_tenhoakhoc.Text.Length > 0)
            {
                if(rbtDau.Checked == true && rbtRot.Checked == false)
                {
                    sqlCommand = new SqlCommand("select d.MaHocVien,h.HoTen,h.GioiTinh,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc and d.DiemTong >= 5  and TenKhoaHoc =N'" + txt_tenhoakhoc.Text + "'", connn);
                    daa = new SqlDataAdapter(sqlCommand);
                }
                else
                {
                    sqlCommand = new SqlCommand("select d.MaHocVien,h.HoTen,h.GioiTinh,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc and d.DiemTong < 5  and TenKhoaHoc =N'" + txt_tenhoakhoc.Text + "'", connn);
                    daa = new SqlDataAdapter(sqlCommand);
                }
               
            }
            else 
            {
                if (rbtDau.Checked == true && rbtRot.Checked == false)
                {
                    sqlCommand = new SqlCommand("select d.MaHocVien,h.HoTen,h.GioiTinh,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc and d.DiemTong >= 5 ", connn);
                    daa = new SqlDataAdapter(sqlCommand);
                }
                else
                {
                    sqlCommand = new SqlCommand("select d.MaHocVien,h.HoTen,h.GioiTinh,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc and d.DiemTong < 5  ", connn);
                    daa = new SqlDataAdapter(sqlCommand);
                }
            }
            
            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }
        private void hienkhoahoc()
        {
            cbo_khoahoc.Items.Clear();
            List<string> ds = loadkhoahoc();
            foreach (string item in ds)
            {
                cbo_khoahoc.Items.Add(item);
            }
        }
        public List<String> loadkhoahoc()
        {
            List<String> dsMaL = new List<String>();
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select * from KhoaHoc";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string ketqua = rd["MaKhoaHoc"].ToString();
                    dsMaL.Add(ketqua);

                }
                rd.Close();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return dsMaL;



            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void frmDSKQ_Load(object sender, EventArgs e)
        {
            hienkhoahoc();
            dataGridView1.DataSource= LoadHocVien();
            txt_tenhoakhoc.Enabled= false;

        }
        public string laytenkhoahoc(string makh)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select TenKhoaHoc from KhoaHoc where MaKhoaHoc = '" + makh + "'";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                string laytenkh = (string)cmd.ExecuteScalar();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return laytenkh;
            }
            catch
            {
                return "";
            }
        }

        private void cbo_khoahoc_SelectedIndexChanged(object sender, EventArgs e)
        {
          txt_tenhoakhoc.Text = laytenkhoahoc(cbo_khoahoc.Text);
          dataGridView1.DataSource = LoadHocVien();
        }

        private void rbtDau_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtDau.Checked == true )
            {
                rbtRot.Checked = false;
                dataGridView1.DataSource = LoadHocVien2();

            }    
        }

        private void rbtRot_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRot.Checked == true)
            {
                rbtDau.Checked = false;
                dataGridView1.DataSource = LoadHocVien2();
            }
        }
        public bool locthangnam(string ngaydau, string ngaycuoi)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select d.MaHocVien,h.HoTen,h.GioiTinh,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc and NgayKetThuc >= convert(date,'" + ngaydau + "',101) and NgayKetThuc <= convert(date,'" + ngaycuoi + "',101) ";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                cmd.ExecuteNonQuery();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable Loadthongke2(string ngaydau, string ngaycuoi)
        {
            SqlCommand cmd = new SqlCommand("select d.MaHocVien,h.HoTen,h.GioiTinh,k.TenKhoaHoc,d.DiemLyThuyet,d.DiemThucHanh,d.DiemTong,d.XepLoai  from  HocVien h, Diem d, KhoaHoc k where h.MaHocVien = d.MaHocVien and d.MaKhoaHoc = k.MaKhoaHoc and NgayKetThuc >= convert(date,'" + ngaydau + "',101) and NgayKetThuc <= convert(date,'" + ngaycuoi + "',101) ", connn);
            daa = new SqlDataAdapter(cmd);
            DataTable tab = new DataTable();

            daa.Fill(tab);
            return tab;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime ngayDau = dateTimePicker1.Value;
            DateTime ngayCuoi = dateTimePicker2.Value;
            DateTime ngayHienTai = DateTime.Now;

            if (ngayDau > ngayCuoi)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ngayDau > ngayHienTai || ngayCuoi > ngayHienTai)
            {
                MessageBox.Show("Ngày không thể lớn hơn ngày hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (locthangnam(dateTimePicker1.Text, dateTimePicker2.Text))
            {
                dataGridView1.DataSource = Loadthongke2(dateTimePicker1.Text, dateTimePicker2.Text);
                MessageBox.Show("Thống kê thành công");
            }

            else
                MessageBox.Show("Không thành công");
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadHocVien();
        }
    }
}
