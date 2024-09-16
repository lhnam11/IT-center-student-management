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
    public partial class thongkebaocao : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;
        public thongkebaocao()
        {
            InitializeComponent();
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
        }

        private void thongkebaocao_Load(object sender, EventArgs e)
        {
            //mã sinh viên tên sinh viên với khóa học đó điểm tổng xếp loại là oke rồi
             CrystalReport1 a = new CrystalReport1();
          
            connn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("select d.MaDiem, hv.HoTen,kh.TenKhoaHoc, d.DiemLyThuyet, d.DiemThucHanh, d.DiemTong, d.XepLoai from Diem d, HocVien hv, KhoaHoc kh where hv.MaHocVien = d.MaHocVien and d.MaKhoaHoc = kh.MaKhoaHoc", connn);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            a.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = a;

            a.SetDatabaseLogon("sa", "023432657", "Data Source=DESKTOP-S7I5A9E\\HOAINAM","Ql_HocVien");

            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.DisplayStatusBar = false;
            //crpProducts rpt = new crpProducts();
        }
    }
}
