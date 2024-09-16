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
    public partial class frmdkkhoahoc : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;
        public frmdkkhoahoc()
        {
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
            InitializeComponent();
        }
        public DataTable LoadHV()
        {
            SqlCommand sqlCommand;
            sqlCommand = new SqlCommand("SELECT * FROM DangKyHoc;", connn);
            daa = new SqlDataAdapter(sqlCommand);   
            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }

        private void frmdkkhoahoc_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadHV();
            hienthiLop();
            hienthiten();
        }
        private void hienthiLop()
        {
            cbo_khoahoc.Items.Clear();
            List<string> ds = LoadTenKhoaHoc();
            if (ds != null)
            {
                foreach (string item in ds)
                {
                    cbo_khoahoc.Items.Add(item);
                }
            }
        }
        public List<String> LoadTenKhoaHoc()
        {
            List<String> dsTenKhoaHoc = new List<String>();
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select TenKhoaHoc from KhoaHoc";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string ketqua = rd["TenKhoaHoc"].ToString();
                    dsTenKhoaHoc.Add(ketqua);
                }
                rd.Close();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return dsTenKhoaHoc;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void hienthiten()
        {
            cbo_thv.Items.Clear();
            List<string> ds = LoadTen();
            if (ds != null)
            {
                foreach (string item in ds)
                {
                    cbo_thv.Items.Add(item);
                }
            }
        }
        public List<String> LoadTen()
        {
            List<String> dsTenKhoaHoc = new List<String>();
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select HoTen from HocVien";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string ketqua = rd["HoTen"].ToString();
                    dsTenKhoaHoc.Add(ketqua);
                }
                rd.Close();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return dsTenKhoaHoc;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string laytengv(string magv)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select HoTen from HocVien where  MaHocVien= '" + magv + "'";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                string laymagv = (string)cmd.ExecuteScalar();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return laymagv;
            }
            catch
            {
                return "";
            }
        }
        public string laytengv1(string magv)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select TenKhoaHoc from KhoaHoc where MaKhoaHoc = '" + magv + "'";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                string laymagv = (string)cmd.ExecuteScalar();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return laymagv;
            }
            catch
            {
                return "";
            }
        }

        public string laymagv(string magv)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select MaHocVien from HocVien where  HoTen= N'" + magv + "'";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                string laymagv = (string)cmd.ExecuteScalar();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return laymagv;
            }
            catch
            {
                return "";
            }
        }
        public string laymagv1(string magv)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select MaKhoaHoc from KhoaHoc where TenKhoaHoc = N'" + magv + "'";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                string laymagv = (string)cmd.ExecuteScalar();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return laymagv;
            }
            catch
            {
                return "";
            }
        }

        public bool themdkykhoahoc(string madky, string mahv, string makh, string ngaydky)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "insert into DangKyHoc values('" + madky + "','" + mahv + "','" + makh + "',convert(date,'" + ngaydky + "',101))";
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

        private void btn_ĐK_Click(object sender, EventArgs e)
        {
            if (themdkykhoahoc(txt_madk.Text, laymagv(cbo_thv.Text), laymagv1(cbo_khoahoc.Text), dateTimePicker1.Value.ToShortDateString()))
            {
                dataGridView1.DataSource = LoadHV();
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txt_madk.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbo_thv.Text = laytengv(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                cbo_khoahoc.Text = laytengv1(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //cbo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //cbo_loaibuoihoc.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Xác nhận đóng kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Close();
            }
        }
        public bool xoaDangKyKhoaHoc(string madk)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }

                string sqlCommand = "DELETE FROM DangKyHoc WHERE MaDangKy = '" + madk + "'";
                SqlCommand cmd = new SqlCommand(sqlCommand, connn);
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string madk = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    // Call a method to delete the row from the database
                    if (xoaDangKyKhoaHoc(madk))
                    {
                        MessageBox.Show("Xóa thành công!");
                        dataGridView1.DataSource = LoadHV(); // Reload the DataGridView after deletion
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
