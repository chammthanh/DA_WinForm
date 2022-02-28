using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
namespace form_QuanAo
{
    public partial class frmMain : Form
    {
        public Form frmparent;
        public frmMain()
        {
            InitializeComponent();
            frmparent = this;
            quanLyToolStripMenuItem.Enabled = false;
            bánHàngToolStripMenuItem.Enabled = false;
            tìmKiếmToolStripMenuItem.Enabled = false;
           

        }
        public static bool trangthai = false;
        private void formMain_Load(object sender, EventArgs e)
        {
            tssDate.Text = "Ngày " + DateTime.Today.ToShortDateString();

            if (!CheckMdiChildForm("frmDangNhap"))
            {
                frmDangNhap f = new frmDangNhap(this);
                ShowMdiChildForm(f);
            }

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckMdiChildForm("frmNhanVien"))
            {
                frmNhanVien f = new frmNhanVien();
                ShowMdiChildForm(f);
            }
        }

        private void ShowMdiChildForm(Form f)
        {
            Program.frmparent = new frmMain();
            foreach (Form frm in frmparent.MdiChildren)
            {
                frm.Hide();
            };
            f.MdiParent = frmparent;
            f.ShowIcon = false;
            f.ControlBox = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.CenterParent;
            f.Show();
            f.Dock = DockStyle.Fill;

        }


        private bool CheckMdiChildForm(string name)
        {
            foreach(Form f in frmparent.MdiChildren)
            {
                if (f.Name == name)
                {
                    ShowMdiChildForm(f);
                    return true;
                }
  
            }
            return false;
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckMdiChildForm("frmSanPham"))
            {
                frmSanPham f = new frmSanPham();
                ShowMdiChildForm(f);
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckMdiChildForm("frmKhachHang"))
            {
                frmKhachHang f = new frmKhachHang();
                ShowMdiChildForm(f);
            }
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckMdiChildForm("frmBanHang"))
            {
                frmBanHang f = new frmBanHang();
                ShowMdiChildForm(f);
            }
        }

        private void hoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckMdiChildForm("frmHoaDon"))
            {
                frmHoaDon f = new frmHoaDon();
                ShowMdiChildForm(f);
            }
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckMdiChildForm("frmTimKiem"))
            {
                frmTimKiem f = new frmTimKiem();
                ShowMdiChildForm(f);
            }
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(đăngNhậpToolStripMenuItem.Text == "Đăng Xuất")
            {
                đăngNhậpToolStripMenuItem.Text = "Đăng nhập";
                quanLyToolStripMenuItem.Enabled = false;
                bánHàngToolStripMenuItem.Enabled = false;
                tìmKiếmToolStripMenuItem.Enabled = false;
                MessageBox.Show("Đăng xuất thành công");
                tssName.Text = "Phải đăng nhập mới xài được app nha";
            }

            if (!CheckMdiChildForm("frmDangNhap"))
            {
                frmDangNhap f = new frmDangNhap(this);
                ShowMdiChildForm(f);
            }
        }

        internal void hienthi(string name)
        {
           
            tssName.Text = "Tên Nhân Viên: " + name;
            quanLyToolStripMenuItem.Enabled = true;
            bánHàngToolStripMenuItem.Enabled = true;
            tìmKiếmToolStripMenuItem.Enabled = true;
            đăngNhậpToolStripMenuItem.Text = "Đăng Xuất";
        }

        private void nhàSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckMdiChildForm("frmNhaSanXuat"))
            {
                frmNhaSanXuat f = new frmNhaSanXuat();
                ShowMdiChildForm(f);
            }
        }
    }
}
