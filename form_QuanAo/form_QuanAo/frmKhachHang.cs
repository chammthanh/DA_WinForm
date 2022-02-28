using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace form_QuanAo
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.DataSource = KhachHangBUS.LayDSKH();
            txtMaKH.Enabled = false;
            this.nut_Control(1);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.TenKH = txtHoTenKH.Text;
            kh.SDT = txtSDT.Text;
            if (KhachHangBUS.themkh(kh))
            {
                dgvKhachHang.DataSource = null;
                dgvKhachHang.DataSource = KhachHangBUS.LayDSKH();
                MessageBox.Show("Thêm Thành Công");
                this.Clear();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }

            this.nut_Control(1);
        }


        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow r = dgvKhachHang.SelectedRows[0];
            
            txtMaKH.Text = r.Cells["colMaKH"].Value.ToString();
            txtHoTenKH.Text = r.Cells["colTenKH"].Value.ToString();
            txtSDT.Text = r.Cells["colSDT"].Value.ToString();
            this.nut_Control(3);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            KhachHangDTO kh = new KhachHangDTO();
            DataGridViewRow r = dgvKhachHang.SelectedRows[0];
            kh.MaKH = Convert.ToInt32(r.Cells["colMaKH"].Value.ToString());
            if (KhachHangBUS.xoakh(kh))
            {
                dgvKhachHang.DataSource = null;
                dgvKhachHang.DataSource = KhachHangBUS.LayDSKH();
                MessageBox.Show("Xóa thành công");
                this.Clear();
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            this.nut_Control(1);
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = Convert.ToInt32(txtMaKH.Text);
            kh.TenKH = txtHoTenKH.Text;
            kh.SDT = txtSDT.Text;
            if (KhachHangBUS.suakh(kh))
            {
                dgvKhachHang.DataSource = null;
                dgvKhachHang.DataSource = KhachHangBUS.LayDSKH();
                MessageBox.Show("Sửa Thành Công");
                
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            this.Clear();
            this.nut_Control(1);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Clear();
            this.nut_Control(1);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void Clear()
        {
            txtMaKH.Clear();
            txtHoTenKH.Clear();
            txtSDT.Clear();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = Convert.ToInt32(txtTimKiem.Text);
            if(KhachHangBUS.KTMaKH(kh))
            {
                dgvKhachHang.DataSource = KhachHangBUS.LayDSTimKiem(kh);
                txtTimKiem.Clear();

            }   
            else
                MessageBox.Show("Mã Khách Hàng Không Hợp Lệ");
            txtTimKiem.Clear();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = KhachHangBUS.LayDSKH();
            txtTimKiem.Clear();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
        void nut_Control(int i)
        {
            switch (i)
            {
                case 1:
                    //load
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnHuy.Enabled = false;
                    break;
                case 2:
                    //text_change
                    if (btnSua.Enabled == true)
                    {
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = true;
                    }

                    break;
                case 3:
                    //sua
                    btnThem.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = true;
                    break;
                case 4:
                    //xoa
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = true;
                    btnHuy.Enabled = false;
                    break;
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.nut_Control(4);
        }

        private void txtHoTenKH_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }
    }
}

