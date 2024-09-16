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
    public partial class dangnhap : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;
        public dangnhap()
        {
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
            InitializeComponent();
        }
        public int dn(string tendn, string mk)
        {
            try
            {
                if (connn.State == ConnectionState.Closed)
                {
                    connn.Open();
                }
                string caulenh1 = "select count(*) from NHANVIEN where TENTAIKHOAN='" + tendn + "' and MATKHAU='" + mk + "'";
                SqlCommand cmd = new SqlCommand(caulenh1, connn);
                int kq1 = (int)cmd.ExecuteScalar();
                string caulenh2 = "select count(*) from NHANVIEN where TENTAIKHOAN='" + tendn + "' and MATKHAU='" + mk + "' and LOAITAIKHOAN=1";
                SqlCommand cmmd = new SqlCommand(caulenh2, connn);
                int kq2 = (int)cmmd.ExecuteScalar();
                string caulenh3 = "select count(*) from NHANVIEN where TENTAIKHOAN='" + tendn + "' and MATKHAU='" + mk + "' and LOAITAIKHOAN=0";
                SqlCommand commd = new SqlCommand(caulenh3, connn);
                int kq3 = (int)commd.ExecuteScalar();
                if (connn.State == ConnectionState.Open)
                    connn.Close();
                if (kq1 >= 1)
                {
                    if (kq2 >= 1)
                        return 1;
                    else if (kq3 >= 1)
                        return 0;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if(txttaikhoan.Text.Length == 0 || txtpass.Text.Length == 0)
            {
                MessageBox.Show("Yêu cầu nhập đủ tên tài khoản và mật khẩu!");
                return;
            } 
            int lays = dn(txttaikhoan.Text, txtpass.Text);
            if (lays == 1)
            {
               
                main a = new main();
                a.layso = lays;
                this.Hide();
                a.ShowDialog();
                this.Show();

            }
            else if (lays == 0)
            {
                main a = new main();
                a.layso = lays;
                this.Hide();
                a.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txttaikhoan.Text = string.Empty;
            txtpass.Text = string.Empty;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
