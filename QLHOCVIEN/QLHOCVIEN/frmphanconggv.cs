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
    public partial class frmphanconggv : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;

        public frmphanconggv()
        {
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
            InitializeComponent();
        }
        public DataTable LoadPhanCong()
        {
            SqlCommand sqlCommand = new SqlCommand("select lh.MaGiangVien,gv.HoTen,l.MaLop,TenLop,NgayHoc,lh.MaLichHoc  from GiangVien gv, LichHoc lh ,Lop l   where gv.MaGiangVien = lh.MaGiangVien and lh.Malop = l.Malop", connn) ;
            daa = new SqlDataAdapter(sqlCommand);
            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }

        private void frmphanconggv_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = LoadPhanCong();
            hienthimagiangvien();
            hienthitengiangvien();
            hienthiLop();
            hienngayhoc();
            //hienloaibuoi();
            
        }
        //cbo magv
        private void hienthimagiangvien()
        {
            cbo_mgv.Items.Clear();
            List<string> ds = LoadGiangVien();
            foreach (string item in ds)
            {
                cbo_mgv.Items.Add(item);
            }
        }
        public List<String>LoadGiangVien()
        {
            List<String> dsMaGV = new List<String>();
            try
            {
                if(connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select * from GiangVien";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string ketqua = rd["MaGiangVien"].ToString();
                    dsMaGV.Add(ketqua);
                    
                }
                rd.Close();
                if(connn.State == ConnectionState.Open)
                    connn.Close();
                return dsMaGV;

                
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //cbo tengv
        private void hienthitengiangvien()
        {
            cbo_mgv.Items.Clear();
            List<string> ds = LoadTenGiangVien();
            foreach (string item in ds)
            {
                cbo_mgv.Items.Add(item);
            }
        }
        public List<String> LoadTenGiangVien()
        {
            List<String> dsMaGV = new List<String>();
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select * from GiangVien";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string ketqua = rd["MaGiangVien"].ToString();
                    dsMaGV.Add(ketqua);

                }
                rd.Close();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                return dsMaGV;



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
                string caulenh = "select HoTen from GiangVien where MaGiangVien = '" + magv + "'";
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


        //cbo tenlop

        private void hienthiLop()
        {
            cbo_tl.Items.Clear();
            List<string> ds = LoadTenLop();
            foreach (string item in ds)
            {
                cbo_tl.Items.Add(item);
            }
        }
        public List<String> LoadTenLop()
        {
            List<String> dsMaL = new List<String>();
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select * from Lop";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string ketqua = rd["MaLop"].ToString();
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

        public string laytenlop(string mal)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select TenLop from Lop where MaLop = '" + mal + "'";
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

        public string laymalop(string mal)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select MaLop from Lop where TenLop = '" + mal + "'";
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

        //cbo ngayhoc
        private void hienngayhoc()
        {
            cbo_mlh.Items.Clear();
            List<string> ds = loadngayhoc();
            foreach (string item in ds)
            {
                cbo_mlh.Items.Add(item);
            }
        }
        public List<String> loadngayhoc()
        {
            List<String> dsMaL = new List<String>();
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select * from LichHoc";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string ketqua = rd["MaLichHoc"].ToString();
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
        // cboloaibuoihoc

        //private void hienloaibuoi()
        //{
        //    cbo_loaibuoihoc.Items.Clear();
        //    List<string> ds = loadloaibuoihoc();
        //    foreach (string item in ds)
        //    {
        //        cbo_loaibuoihoc.Items.Add(item);
        //    }
        //}
        public List<String> loadloaibuoihoc()
        {
            List<String> dsMaL = new List<String>();
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh = "select * from LichHoc";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string ketqua = rd["LoaiBuoiHoc"].ToString();
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
      
        public bool themphancong(string magv,string ml,string malh)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                { connn.Open(); }
                string caulenh = "update LichHoc set MaGiangVien='" + magv + "', MaLop='" + ml + "' where MaLichHoc='" + malh + "'";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                cmd.ExecuteNonQuery();
                if (connn.State == ConnectionState.Open)
                {
                    connn.Close();
                }
                return true;

            }
            catch
            {

                return false;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (themphancong(cbo_mgv.Text, cbo_tl.Text, /*cbo_loaibuoihoc.Text,*/ cbo_mlh.Text))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = LoadPhanCong();
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void cbo_mgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_tengv.Text= laytengv(cbo_mgv.Text);
        }

        private void cbo_tl_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_tl.Text=laytenlop(cbo_tl.Text);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                { connn.Open(); }
                string caulenh = "delete from LichHoc  where MalichHoc= '"+ cbo_mlh.Text +"'" ;
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                cmd.ExecuteNonQuery();
                if (connn.State == ConnectionState.Open)
                {
                    connn.Close();
                }
                dataGridView1.DataSource = LoadPhanCong();
            }
            catch
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                cbo_mgv.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbo_mlh.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txt_tengv.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_tl.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //cbo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //cbo_loaibuoihoc.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                cbo_tl.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void txt_tl_TextChanged(object sender, EventArgs e)
        {
            
        }
        // sửa phân công
        public bool suaphancong(string magv, string ml, string malh)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }

                string caulenh = "update LichHoc set MaGiangVien='" + magv + "', MaLop='" + ml + "' where MaLichHoc='" + malh + "'";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                cmd.ExecuteNonQuery();

                if (connn.State == ConnectionState.Open)
                {
                    connn.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (suaphancong(cbo_mgv.Text, cbo_tl.Text,  cbo_mlh.Text))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = LoadPhanCong();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (themphancong(cbo_mgv.Text, cbo_tl.Text, cbo_mlh.Text))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = LoadPhanCong();
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                { connn.Open(); }
                string caulenh = "delete from LichHoc  where MalichHoc= '" + cbo_mlh.Text + "'";
                SqlCommand cmd = new SqlCommand(caulenh, connn);
                cmd.ExecuteNonQuery();
                if (connn.State == ConnectionState.Open)
                {
                    connn.Close();
                }
                dataGridView1.DataSource = LoadPhanCong();
            }
            catch
            {

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (suaphancong(cbo_mgv.Text, cbo_tl.Text, cbo_mlh.Text))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = LoadPhanCong();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Xác nhận đóng ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        //

    }
}
