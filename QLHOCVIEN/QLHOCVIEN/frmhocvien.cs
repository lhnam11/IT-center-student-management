using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QLHOCVIEN
{
    public partial class frmhocvien : Form
    {
        SqlConnection connn;
        SqlDataAdapter daa;
        public frmhocvien()
        {
            InitializeComponent();
            connn = new SqlConnection("Data Source=DESKTOP-S7I5A9E\\HOAINAM;Initial Catalog=Ql_HocVien;Integrated Security=True");
        }

        private void frmhocvien_Load(object sender, EventArgs e)
        {
            txtMaHV.Enabled = true;
            txtDiachi.Enabled = true;
            txtTenHV.Enabled = true;
            cbo_tthv.Enabled = true;
            rdo_nam.Enabled = true;
            rdo_nu.Enabled = true;
            txtDienthoai.Enabled = true;
            txt_email.Enabled = true;
            btnLuuHV.Enabled = true;
            LoadHocVienData();
            dataGridView1.DataSource = LoadHV();
            LoadTrangThaiHocVienToComboBox();
            listViewHocVien.SelectedIndexChanged += listViewHocVien_SelectedIndexChanged;

        }

        private void LoadHocVienData()
        {
            try
            {
                connn.Open();
                string query = "SELECT * FROM HocVien";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Clear existing items in the ListView
                listViewHocVien.Items.Clear();

                // Add data to the ListView
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaHocVien"].ToString());
                    item.SubItems.Add(row["HoTen"].ToString());
                    item.SubItems.Add(row["GioiTinh"].ToString());

                    // Chuyển đổi ngày sinh và ngày đăng ký sang định dạng ngày tháng năm (không chứa giờ, phút, giây)
                    DateTime ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                    DateTime ngayDangKy = DateTime.Parse(row["NgayDangKy"].ToString());

                    item.SubItems.Add(ngaySinh.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(row["DiaChi"].ToString());
                    item.SubItems.Add(row["SoDienThoai"].ToString());
                    item.SubItems.Add(row["Email"].ToString());
                    item.SubItems.Add(ngayDangKy.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(row["TrangThaiHocVien"].ToString());

                    listViewHocVien.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connn.Close();
            }
        }

        private void LoadTrangThaiHocVienToComboBox()
        {
            try
            {
                connn.Open();
                string query = "SELECT TrangThaiHocVien FROM HocVien GROUP BY TrangThaiHocVien";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Clear existing items in the ComboBox
                cbo_tthv.Items.Clear();

                // Add data to the ComboBox
                foreach (DataRow row in dt.Rows)
                {
                    cbo_tthv.Items.Add(row["TrangThaiHocVien"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connn.Close();
            }
        }
        private void ClearTextBoxes()
        {
            txtMaHV.Clear();
            txtTenHV.Clear();
            txt_ngaysinh.Clear();
            txt_ngaydk.Clear();
            txtDiachi.Clear();
            txtDienthoai.Clear();
            txt_email.Clear();
            // Đặt lại giá trị mặc định cho RadioButton
            rdo_nam.Checked = false;
            rdo_nu.Checked = false;

            // Đặt lại giá trị mặc định cho ComboBox
            cbo_tthv.SelectedIndex = -1;
        }
        private int ExtractIdFromMaHV(string maHocVien)
        {
            // Loại bỏ các ký tự không phải số từ chuỗi
            string numericPart = new string(maHocVien.Where(char.IsDigit).ToArray());

            // Chuyển đổi phần số thành số nguyên
            if (int.TryParse(numericPart, out int id))
            {
                return id;
            }

            // Nếu không thành công, trả về một giá trị mặc định hoặc xử lý theo cách khác tùy thuộc vào yêu cầu của bạn.
            return -1; // Hoặc bất kỳ giá trị khác để biểu thị sự thất bại
        }
        private int selectedHocVienId;

        private void listViewHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Đảm bảo có ít nhất một dòng được chọn
            if (listViewHocVien.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewHocVien.SelectedItems[0];

                // Lấy ID của học viên từ dòng được chọn
                int id = ExtractIdFromMaHV(selectedItem.SubItems[0].Text);

                // Kiểm tra xem lấy ID thành công hay không
                if (id != -1)
                {
                    selectedHocVienId = id;

                    // Hiển thị thông tin của học viên trong các TextBox, ComboBox, và RadioButton
                    txtMaHV.Text = selectedItem.SubItems[0].Text;
                    txtTenHV.Text = selectedItem.SubItems[1].Text;
                    txt_ngaysinh.Text = selectedItem.SubItems[3].Text; // Ví dụ, thay "3" bằng index tương ứng với ngày sinh trong ListView
                    txtDiachi.Text = selectedItem.SubItems[4].Text;
                    txtDienthoai.Text = selectedItem.SubItems[5].Text;
                    txt_email.Text = selectedItem.SubItems[6].Text;
                    txt_ngaydk.Text = selectedItem.SubItems[7].Text;

                    // Hiển thị giới tính
                    string gioiTinh = selectedItem.SubItems[2].Text;
                    //if(gioiTinh == "Nữ")
                    //{
                    //    rdo_nu.Checked = true;
                    //}
                    //if (gioiTinh == "Nam")
                    //{
                    //    rdo_nam.Checked = true;
                    //}
                    rdo_nam.Checked = gioiTinh.Equals("Nam", StringComparison.OrdinalIgnoreCase);
                    rdo_nu.Checked = gioiTinh.Equals("Nữ", StringComparison.OrdinalIgnoreCase);

                    // Hiển thị trạng thái học viên
                    cbo_tthv.SelectedItem = selectedItem.SubItems[8].Text;
                }
                else
                {
                    // Xử lý khi không lấy được ID
                    MessageBox.Show("Không thể lấy ID từ mã học viên.");
                }
            }
        }

        private bool KT_MaHV(string maHocVien)
        {
            try
            {
                //Mo ket noi
                connn.Open();
                string selectString = "SELECT COUNT(*) FROM HocVien WHERE MaHocVien = @MaHocVien";
                SqlCommand cmd = new SqlCommand(selectString, connn);
                //goi ham thuc thi truy van
                int count = (int)cmd.ExecuteScalar();
                //Dong ket noi
                connn.Close();
                //Xu ly ket qua truy van
                if (count >= 1)
                    return false;
                return true;
            }
            catch (Exception ex) { return false; }
        }

        private void btnThemHV_Click(object sender, EventArgs e)
        {
            try
            {
                connn.Open();

                string gioiTinh = rdo_nam.Checked ? "Nam" : "Nữ";

                DateTime ngaySinh = DateTime.ParseExact(txt_ngaysinh.Text, "dd/MM/yyyy", null);
                DateTime ngayDangKy = DateTime.ParseExact(txt_ngaydk.Text, "dd/MM/yyyy", null);

                string insertQuery = "INSERT INTO HocVien (MaHocVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, NgayDangKy, TrangThaiHocVien) " +
                                     "VALUES (@MaHocVien, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Email, @NgayDangKy, @TrangThaiHocVien)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connn))
                {
                    cmd.Parameters.AddWithValue("@MaHocVien", txtMaHV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtTenHV.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiachi.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtDienthoai.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@NgayDangKy", ngayDangKy);
                    cmd.Parameters.AddWithValue("@TrangThaiHocVien", cbo_tthv.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm học viên thành công.");
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connn.Close();
                LoadHocVienData();
            }
        }

        private void btnSuaHV_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                connn.Open();

                // Kiểm tra và thực hiện sửa thông tin học viên
                if (txtMaHV.Text != "" && txtTenHV.Text != "" && txt_ngaysinh.Text != "" && (rdo_nam.Checked || rdo_nu.Checked) && txtDiachi.Text != "" && txtDienthoai.Text != "" && txt_email.Text != "" && txt_ngaydk.Text != "" && cbo_tthv.Text != "")
                {
                    string gioiTinh = rdo_nam.Checked ? "Nam" : "Nữ"; // Lấy giới tính từ RadioButton

                    // Chuyển đổi chuỗi ngày thành kiểu DateTime
                    DateTime ngaySinh = DateTime.ParseExact(txt_ngaysinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime ngayDangKy = DateTime.ParseExact(txt_ngaydk.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string updateQuery = "UPDATE HocVien SET MaHocVien = @MaHocVien, HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email, NgayDangKy = @NgayDangKy, TrangThaiHocVien = @TrangThaiHocVien " +
                                         "WHERE MaHocVien = @MaHocVien";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connn))
                    {
                        cmd.Parameters.AddWithValue("@MaHocVien", txtMaHV.Text);
                        cmd.Parameters.AddWithValue("@HoTen", txtTenHV.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiachi.Text);
                        cmd.Parameters.AddWithValue("@SoDienThoai", txtDienthoai.Text);
                        cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                        cmd.Parameters.AddWithValue("@NgayDangKy", ngayDangKy);
                        cmd.Parameters.AddWithValue("@TrangThaiHocVien", cbo_tthv.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Sửa thông tin học viên thành công.");
                    ClearTextBoxes();

                    // Load lại danh sách học viên sau khi sửa

                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin học viên.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                connn.Close();
                LoadHocVienData();
            }
        }

        private void btnXoaHV_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                connn.Open();

                // Kiểm tra và thực hiện xóa thông tin học viên
                if (txtMaHV.Text != "")
                {
                    string deleteQuery = "DELETE FROM HocVien WHERE MaHocVien = @MaHocVien";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connn))
                    {
                        cmd.Parameters.AddWithValue("@MaHocVien", txtMaHV.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa thông tin học viên thành công.");
                    ClearTextBoxes();

                    // Load lại danh sách học viên sau khi xóa

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập Mã Học Viên để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                connn.Close();
                LoadHocVienData();
            }
        }

        private void btnLuuHV_Click(object sender, EventArgs e)
        {
            try
            {
                connn.Open();

                string gioiTinh = rdo_nam.Checked ? "Nam" : "Nữ";

                DateTime ngaySinh = DateTime.ParseExact(txt_ngaysinh.Text, "dd/MM/yyyy", null);
                DateTime ngayDangKy = DateTime.ParseExact(txt_ngaydk.Text, "dd/MM/yyyy", null);

                // Kiểm tra xem học viên đã tồn tại hay chưa
                string checkQuery = "SELECT COUNT(*) FROM HocVien WHERE MaHocVien = @MaHocVien";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connn))
                {
                    checkCmd.Parameters.AddWithValue("@MaHocVien", txtMaHV.Text);
                    int existingCount = (int)checkCmd.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        // Học viên đã tồn tại, thực hiện cập nhật
                        string updateQuery = "UPDATE HocVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email, NgayDangKy = @NgayDangKy, TrangThaiHocVien = @TrangThaiHocVien " +
                                             "WHERE MaHocVien = @MaHocVien";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, connn))
                        {
                            updateCmd.Parameters.AddWithValue("@MaHocVien", txtMaHV.Text);
                            updateCmd.Parameters.AddWithValue("@HoTen", txtTenHV.Text);
                            updateCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                            updateCmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                            updateCmd.Parameters.AddWithValue("@DiaChi", txtDiachi.Text);
                            updateCmd.Parameters.AddWithValue("@SoDienThoai", txtDienthoai.Text);
                            updateCmd.Parameters.AddWithValue("@Email", txt_email.Text);
                            updateCmd.Parameters.AddWithValue("@NgayDangKy", ngayDangKy);
                            updateCmd.Parameters.AddWithValue("@TrangThaiHocVien", cbo_tthv.Text);

                            updateCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Cập nhật thông tin học viên thành công.");
                    }
                    else
                    {
                        // Học viên chưa tồn tại, thực hiện thêm mới
                        string insertQuery = "INSERT INTO HocVien (MaHocVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, NgayDangKy, TrangThaiHocVien) " +
                                             "VALUES (@MaHocVien, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Email, @NgayDangKy, @TrangThaiHocVien)";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connn))
                        {
                            insertCmd.Parameters.AddWithValue("@MaHocVien", txtMaHV.Text);
                            insertCmd.Parameters.AddWithValue("@HoTen", txtTenHV.Text);
                            insertCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                            insertCmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                            insertCmd.Parameters.AddWithValue("@DiaChi", txtDiachi.Text);
                            insertCmd.Parameters.AddWithValue("@SoDienThoai", txtDienthoai.Text);
                            insertCmd.Parameters.AddWithValue("@Email", txt_email.Text);
                            insertCmd.Parameters.AddWithValue("@NgayDangKy", ngayDangKy);
                            insertCmd.Parameters.AddWithValue("@TrangThaiHocVien", cbo_tthv.Text);

                            insertCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm mới học viên thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                connn.Close();

                // Load lại danh sách học viên sau khi thêm hoặc cập nhật
                LoadHocVienData();
            }
        }

        private void btnTimHV_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                connn.Open();

                // Kiểm tra và thực hiện tìm thông tin học viên
                if (txtMaHV.Text != "")
                {
                    string selectQuery = "SELECT * FROM HocVien WHERE MaHocVien = @MaHocVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connn);
                    adapter.SelectCommand.Parameters.AddWithValue("@MaHocVien", txtMaHV.Text);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Kiểm tra xem có dữ liệu trả về hay không
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        // Hiển thị thông tin trong MessageBox
                        string thongTin = $"Mã Học Viên: {row["MaHocVien"]}\n" +
                                          $"Họ Tên: {row["HoTen"]}\n" +
                                          $"Ngày Sinh: {((DateTime)row["NgaySinh"]).ToShortDateString()}\n" +
                                          $"Giới Tính: {row["GioiTinh"]}\n" +
                                          $"Địa Chỉ: {row["DiaChi"]}\n" +
                                          $"Số Điện Thoại: {row["SoDienThoai"]}\n" +
                                          $"Email: {row["Email"]}\n" +
                                          $"Ngày Đăng Ký: {((DateTime)row["NgayDangKy"]).ToShortDateString()}\n" +
                                          $"Trạng Thái Học Viên: {row["TrangThaiHocVien"]}";

                        MessageBox.Show(thongTin, "Thông tin Học Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Học Viên với Mã Học Viên đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập Mã Học Viên để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                connn.Close();
            }
        }

        private void btnThoatHV_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận khi nhấn nút thoát
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra xem người dùng đã chọn "Yes" hay không
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;

            // Kiểm tra định dạng email bằng Regular Expression
            string pattern = @"^[a-zA-Z0-9._-]+@gmail\.com$";
            bool isEmailValid = System.Text.RegularExpressions.Regex.IsMatch(ctr.Text, pattern);

            // Hiển thị thông báo lỗi nếu định dạng không đúng
            if (!isEmailValid)
            {
                this.errorProvider1.SetError(ctr, "Định dạng email không hợp lệ. Vui lòng nhập email theo định dạng example@gmail.com");
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }
        private void txtTenHV_TextChanged(object sender, EventArgs e)
        {
            //string inputText = txtTenHV.Text;

            //// Check each character in the input text
            //foreach (char character in inputText)
            //{
            //    if (!char.IsLetter(character))
            //    {
            //        // Display an error message and remove the invalid character
            //        this.errorProvider1.SetError(txtTenHV, "Only letters are allowed in this field.");
            //        txtTenHV.Text = txtTenHV.Text.Remove(txtTenHV.Text.Length - 1);
            //        txtTenHV.SelectionStart = txtTenHV.Text.Length;
            //    }
            //    else
            //    {
            //        // Clear the error message if a valid input is provided
            //        this.errorProvider1.Clear();
            //    }
            //}
        }

        private void txtDienthoai_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Length > 0 && !Char.IsDigit(ctr.Text[ctr.Text.Length - 1]))
                this.errorProvider1.SetError(ctr, "‚This is not avalid number");
            else
                this.errorProvider1.Clear();
        }

        private void rdo_nam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_nam.Checked)
            {
                rdo_nu.Checked = false;
            }
        }

        private void rdo_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_nu.Checked)
            {
                rdo_nam.Checked = false;
            }
        }

        private void rdo_nam_Click(object sender, EventArgs e)
        {
            rdo_nam.Checked = true;
            rdo_nu.Checked = false;
        }

        private void rdo_nu_Click(object sender, EventArgs e)
        {
            rdo_nam.Checked = false;
            rdo_nu.Checked = true;
        }

        public DataTable LoadHV()
        {
            SqlCommand sqlCommand;

            if (txtMaHV_X.Text.Length <= 0)
            {
                sqlCommand = new SqlCommand("select * from HocVien", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }

            else if (txtMaHV_X.Text.Length > 0)
            {
                sqlCommand = new SqlCommand("select * from HocVien where MaHocVien ='" + txtMaHV_X.Text + "'", connn);
                daa = new SqlDataAdapter(sqlCommand);
            }

            DataTable tab = new DataTable();
            daa.Fill(tab);
            return tab;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }
    }
}
