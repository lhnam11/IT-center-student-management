namespace QLHOCVIEN
{
    partial class frmDSKQ
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemLyThuyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemThucHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XepLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtRot = new System.Windows.Forms.RadioButton();
            this.rbtDau = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_khoahoc = new System.Windows.Forms.ComboBox();
            this.txt_tenhoakhoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(15, 215);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1354, 437);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách kết quả học tập học viên";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHocVien,
            this.HoTen,
            this.Column1,
            this.TenKhoaHoc,
            this.DiemLyThuyet,
            this.DiemThucHanh,
            this.DiemTong,
            this.XepLoai});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            this.dataGridView1.Location = new System.Drawing.Point(6, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1348, 437);
            this.dataGridView1.TabIndex = 0;
            // 
            // MaHocVien
            // 
            this.MaHocVien.DataPropertyName = "MaHocVien";
            this.MaHocVien.HeaderText = "Mã học viên";
            this.MaHocVien.MinimumWidth = 10;
            this.MaHocVien.Name = "MaHocVien";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Tên Học viên";
            this.HoTen.MinimumWidth = 10;
            this.HoTen.Name = "HoTen";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "GioiTinh";
            this.Column1.HeaderText = "Giới tính";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            // 
            // TenKhoaHoc
            // 
            this.TenKhoaHoc.DataPropertyName = "TenKhoaHoc";
            this.TenKhoaHoc.HeaderText = "Tên Khóa học";
            this.TenKhoaHoc.MinimumWidth = 10;
            this.TenKhoaHoc.Name = "TenKhoaHoc";
            // 
            // DiemLyThuyet
            // 
            this.DiemLyThuyet.DataPropertyName = "DiemLyThuyet";
            this.DiemLyThuyet.HeaderText = "Điểm LT";
            this.DiemLyThuyet.MinimumWidth = 10;
            this.DiemLyThuyet.Name = "DiemLyThuyet";
            // 
            // DiemThucHanh
            // 
            this.DiemThucHanh.DataPropertyName = "DiemThucHanh";
            this.DiemThucHanh.HeaderText = "Điểm TH";
            this.DiemThucHanh.MinimumWidth = 10;
            this.DiemThucHanh.Name = "DiemThucHanh";
            // 
            // DiemTong
            // 
            this.DiemTong.DataPropertyName = "DiemTong";
            this.DiemTong.HeaderText = "Điểm tổng";
            this.DiemTong.MinimumWidth = 10;
            this.DiemTong.Name = "DiemTong";
            // 
            // XepLoai
            // 
            this.XepLoai.DataPropertyName = "XepLoai";
            this.XepLoai.HeaderText = "XepLoai";
            this.XepLoai.MinimumWidth = 10;
            this.XepLoai.Name = "XepLoai";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtRot);
            this.groupBox2.Controls.Add(this.rbtDau);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(724, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(632, 88);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống kê danh sách";
            // 
            // rbtRot
            // 
            this.rbtRot.AutoSize = true;
            this.rbtRot.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtRot.ForeColor = System.Drawing.Color.Navy;
            this.rbtRot.Location = new System.Drawing.Point(309, 38);
            this.rbtRot.Margin = new System.Windows.Forms.Padding(6);
            this.rbtRot.Name = "rbtRot";
            this.rbtRot.Size = new System.Drawing.Size(165, 28);
            this.rbtRot.TabIndex = 1;
            this.rbtRot.Text = "Học viên rớt";
            this.rbtRot.UseVisualStyleBackColor = true;
            this.rbtRot.CheckedChanged += new System.EventHandler(this.rbtRot_CheckedChanged);
            // 
            // rbtDau
            // 
            this.rbtDau.AutoSize = true;
            this.rbtDau.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtDau.ForeColor = System.Drawing.Color.Navy;
            this.rbtDau.Location = new System.Drawing.Point(22, 38);
            this.rbtDau.Margin = new System.Windows.Forms.Padding(6);
            this.rbtDau.Name = "rbtDau";
            this.rbtDau.Size = new System.Drawing.Size(173, 28);
            this.rbtDau.TabIndex = 0;
            this.rbtDau.Text = "Học viên đậu";
            this.rbtDau.UseVisualStyleBackColor = true;
            this.rbtDau.CheckedChanged += new System.EventHandler(this.rbtDau_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Chọn Khóa học cần xem";
            // 
            // cbo_khoahoc
            // 
            this.cbo_khoahoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_khoahoc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_khoahoc.FormattingEnabled = true;
            this.cbo_khoahoc.Location = new System.Drawing.Point(324, 24);
            this.cbo_khoahoc.Margin = new System.Windows.Forms.Padding(6);
            this.cbo_khoahoc.Name = "cbo_khoahoc";
            this.cbo_khoahoc.Size = new System.Drawing.Size(388, 34);
            this.cbo_khoahoc.TabIndex = 21;
            this.cbo_khoahoc.SelectedIndexChanged += new System.EventHandler(this.cbo_khoahoc_SelectedIndexChanged);
            // 
            // txt_tenhoakhoc
            // 
            this.txt_tenhoakhoc.Location = new System.Drawing.Point(324, 80);
            this.txt_tenhoakhoc.Name = "txt_tenhoakhoc";
            this.txt_tenhoakhoc.Size = new System.Drawing.Size(387, 31);
            this.txt_tenhoakhoc.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(145, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tên khóa học";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.97452F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.02547F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 85);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(139, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(468, 33);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 43);
            this.label4.TabIndex = 1;
            this.label4.Text = "Đến";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(139, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(468, 33);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(724, 115);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(633, 123);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thống kê danh sách";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(786, 690);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 52);
            this.button1.TabIndex = 28;
            this.button1.Text = "Thống kê ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_reset.Location = new System.Drawing.Point(1098, 690);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(274, 52);
            this.btn_reset.TabIndex = 29;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // frmDSKQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1384, 759);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_tenhoakhoc);
            this.Controls.Add(this.cbo_khoahoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDSKQ";
            this.Text = "frmDSKQ";
            this.Load += new System.EventHandler(this.frmDSKQ_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtRot;
        private System.Windows.Forms.RadioButton rbtDau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_khoahoc;
        private System.Windows.Forms.TextBox txt_tenhoakhoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHocVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemLyThuyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemThucHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn XepLoai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_reset;
    }
}