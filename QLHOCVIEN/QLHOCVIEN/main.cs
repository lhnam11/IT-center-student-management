using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHOCVIEN
{
    public partial class main : Form
    {
        public int layso;
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            if (layso == 1)
            {
               

               // cái này ông tự chọn cái tool bõ nào để ẩn hoặc hiện dựa vô loại tk  layso là gì ă
            }
            else
            {
                quảnLýTàiKhoảnToolStripMenuItem.Enabled = true;
            }
        }

        private void họcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmphanconggv a=new frmphanconggv();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void quảnLýHọcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmhocvien a = new frmhocvien();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void tìmKiếmHọcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmtimthongtinHV_Ketqua a = new FrmtimthongtinHV_Ketqua();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void quảnLýGVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmtimthongtinHV_Ketqua a = new FrmtimthongtinHV_Ketqua();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void traCứuThôngTinGVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmtimgv a = new Frmtimgv();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void thốngKêBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongkebaocao a = new thongkebaocao();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmtimLichHoc a = new FrmtimLichHoc();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void phânCôngChoGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmphanconggv a = new frmphanconggv();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void kếtQuảPhânLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKQ a = new frmDSKQ();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void tìmThôngTinKhóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKH a = new FrmTimKH();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void đăngKýKhóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdkkhoahoc a = new frmdkkhoahoc();
            this.Hide(); a.ShowDialog();
            this.Show();

        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmquanlytaikhoan a = new frmquanlytaikhoan();
            this.Hide(); a.ShowDialog();
            this.Show();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
