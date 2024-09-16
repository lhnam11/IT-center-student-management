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
    public partial class frmquanlytaikhoan : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;
        public frmquanlytaikhoan()
        {
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
            InitializeComponent();
        }
        public DataTable LoadHV()
        {
            SqlCommand sqlCommand;
            sqlCommand = new SqlCommand("SELECT * FROM NHANVIEN;", connn);
            daa = new SqlDataAdapter(sqlCommand);
            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }

        private void frmquanlytaikhoan_Load(object sender, EventArgs e)
        {
           
           dataGridView1.DataSource = LoadHV();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from textboxes
                string tenTaiKhoan = txt_madk.Text;
                string matKhau = txt_mk.Text;
                int loaiTaiKhoan = Convert.ToInt32(txt_quyền.Text); // Assuming txt_loaiTaiKhoan is a TextBox for LOAITAIKHOAN

                // Insert into the database
                connn.Open();

                string insertQuery = "INSERT INTO NHANVIEN (TENTAIKHOAN, MATKHAU, LOAITAIKHOAN) VALUES (@tenTaiKhoan, @matKhau, @loaiTaiKhoan)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connn))
                {
                    cmd.Parameters.AddWithValue("@tenTaiKhoan", tenTaiKhoan);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);
                    cmd.Parameters.AddWithValue("@loaiTaiKhoan", loaiTaiKhoan);

                    cmd.ExecuteNonQuery();
                }

                connn.Close();

                // Refresh the DataGridView to reflect the changes
                dataGridView1.DataSource = LoadHV();

                // Optionally, clear the textboxes after adding a new record
                txt_madk.Clear();
                txt_mk.Clear();
                txt_quyền.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txt_madk_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from textboxes
                string tenTaiKhoan = txt_madk.Text;
                string matKhau = txt_mk.Text;
                int loaiTaiKhoan = Convert.ToInt32(txt_quyền.Text); // Assuming txt_loaiTaiKhoan is a TextBox for LOAITAIKHOAN

                // Insert into the database
                connn.Open();

                string insertQuery = "INSERT INTO NHANVIEN (TENTAIKHOAN, MATKHAU, LOAITAIKHOAN) VALUES (@tenTaiKhoan, @matKhau, @loaiTaiKhoan)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connn))
                {
                    cmd.Parameters.AddWithValue("@tenTaiKhoan", tenTaiKhoan);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);
                    cmd.Parameters.AddWithValue("@loaiTaiKhoan", loaiTaiKhoan);

                    cmd.ExecuteNonQuery();
                }

                connn.Close();

                // Refresh the DataGridView to reflect the changes
                dataGridView1.DataSource = LoadHV();

                // Optionally, clear the textboxes after adding a new record
                txt_madk.Clear();
                txt_mk.Clear();
                txt_quyền.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected TENTAIKHOAN from the textbox
                string tenTaiKhoan = txt_madk.Text;

                // Delete from the database
                connn.Open();

                string deleteQuery = "DELETE FROM NHANVIEN WHERE TENTAIKHOAN = @tenTaiKhoan";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connn))
                {
                    cmd.Parameters.AddWithValue("@tenTaiKhoan", tenTaiKhoan);
                    cmd.ExecuteNonQuery();
                }

                connn.Close();

                // Refresh the DataGridView to reflect the changes
                dataGridView1.DataSource = LoadHV();

                // Optionally, clear the textboxes after deleting a record
                txt_madk.Clear();
                txt_mk.Clear();
                txt_quyền.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txt_madk.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_mk.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_quyền.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           
                //cbo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //cbo_loaibuoihoc.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có muốn đóng form không", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from textboxes
                string tenTaiKhoan = txt_madk.Text;
                string matKhau = txt_mk.Text;
                int loaiTaiKhoan = Convert.ToInt32(txt_quyền.Text); // Assuming txt_loaiTaiKhoan is a TextBox for LOAITAIKHOAN

                // Check if the selected record is valid
                if (string.IsNullOrEmpty(tenTaiKhoan))
                {
                    MessageBox.Show("Please select a record to update.");
                    return;
                }

                // Update the database
                connn.Open();

                string updateQuery = "UPDATE NHANVIEN SET MATKHAU = @matKhau, LOAITAIKHOAN = @loaiTaiKhoan WHERE TENTAIKHOAN = @tenTaiKhoan";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connn))
                {
                    cmd.Parameters.AddWithValue("@tenTaiKhoan", tenTaiKhoan);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);
                    cmd.Parameters.AddWithValue("@loaiTaiKhoan", loaiTaiKhoan);

                    cmd.ExecuteNonQuery();
                }

                connn.Close();

                // Refresh the DataGridView to reflect the changes
                dataGridView1.DataSource = LoadHV();

                // Clear the textboxes after updating the record
                txt_madk.Clear();
                txt_mk.Clear();
                txt_quyền.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
