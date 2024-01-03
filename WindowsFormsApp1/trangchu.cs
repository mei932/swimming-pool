using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace QLbeboi
{
    public partial class trangchu : Form
    {
        public trangchu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Form currentFormChild;

        // Sử lí sự kiện bấm vào icon logo
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblNhanVien());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblKhachHang());
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblDichVu());
        }

        private void btbHoatDong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblHoatDong());
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblDoanhThu());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            tblDangNhap tc = new tblDangNhap();
            tc.Show();
            this.Hide();
        }

        private void thốngKêDoanhThuTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêDoanhThuTheoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tblTKtheongay());
        }

        private void thốngKêDoanhThuTheoNămToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new inhoadon());
        }



        //chuyển sang form nhân viên\

    }
}
