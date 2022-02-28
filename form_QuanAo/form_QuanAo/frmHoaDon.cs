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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
            txtMaHD.ReadOnly = true;
            txtMaHD.Enabled = false;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.DataSource = HoaDonBUS.laydshd();
            this.makh();
            this.LoadCT();
            chkHoatDong.Checked = true;
            this.manv();
            this.nut_Control(1);

        }

        public void manv()
        {
            DataTable dt = new DataTable();
            dt = HoaDonBUS.LayMaNV();
            cboMaNV.DataSource = dt;
            cboMaNV.DisplayMember = "MANV";
            cboMaNV.ValueMember = "MANV";
        }
        public void makh()
        {
            DataTable dt = new DataTable();
            dt = HoaDonBUS.LayDSKH();
            cboMaKH.DataSource = dt;
            cboMaKH.DisplayMember = "MAKH";
            cboMaKH.ValueMember = "MAKH";
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            HoaDonDTO hd = new HoaDonDTO();
            hd.MaKH = Convert.ToInt32(cboMaKH.Text);
            hd.NgLap = dtpNgayLap.Value;
            hd.MaNV = Convert.ToInt32(cboMaNV.SelectedValue.ToString());
            hd.TongTien = Convert.ToInt32(txtTongTien.Text);
            hd.TrangThai = chkHoatDong.Checked;
            if (HoaDonBUS.themhd(hd))
            {
                MessageBox.Show("Thêm thành công");
                this.frmHoaDon_Load(sender, e);
                this.Clear();
                txtMaCTHD.Text = HoaDonBUS.LayMaHD().ToString();
                this.nut_Control(1);
            }
            else
            {
                MessageBox.Show("thêm hóa đơn thất bại");
            }

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            HoaDonDTO hd = new HoaDonDTO();
            DataGridViewRow r = dgvHoaDon.SelectedRows[0];
            hd.MaHD = Convert.ToInt32(r.Cells["colMaHD"].Value);
            if (HoaDonBUS.xoahd(hd))
            {
                this.frmHoaDon_Load(sender, e);
                MessageBox.Show("Xóa thành công");
                this.nut_Control(1);
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
        }

        private void dgvHoaDon_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvHoaDon.SelectedRows[0];
            txtMaHD.Text = r.Cells["colMaHD"].Value.ToString();
            cboMaKH.Text = r.Cells["colMaKH"].Value.ToString();
            dtpNgayLap.Value = Convert.ToDateTime(r.Cells["colNgayLap"].Value.ToString());
            cboMaNV.Text = r.Cells["colMaNV"].Value.ToString();
            txtTongTien.Text = r.Cells["colTongTien"].Value.ToString();
            chkHoatDong.Checked = Convert.ToBoolean(r.Cells["colTrangThai"].Value.ToString());
            txtMaCTHD.Text = txtMaHD.Text;
            btnSua.Enabled = true;
            this.nut_Control(2);
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            HoaDonDTO hd = new HoaDonDTO();
            hd.MaHD = Convert.ToInt32(txtMaHD.Text);
            hd.MaKH = Convert.ToInt32(cboMaKH.Text);
            hd.NgLap = dtpNgayLap.Value;
            hd.MaNV = Convert.ToInt32(cboMaNV.SelectedValue.ToString());
            hd.TongTien = Convert.ToInt32(txtTongTien.Text);
            hd.TrangThai = chkHoatDong.Checked;
            if (HoaDonBUS.suahd(hd))
            {
                MessageBox.Show("Sửa thành công");
                this.frmHoaDon_Load(sender, e);
                this.Clear();
                this.nut_Control(1);

            }
            else
            {
                MessageBox.Show("sửa hóa đơn thất bại");
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Clear();
            this.nut_Control(1);
        }
        public void Clear()
        {
            txtMaHD.Clear();
            cboMaNV.SelectedValue = 0;
            cboMaKH.SelectedValue = 0;
            txtTongTien.Clear();
        }
        public void LoadCT()
        {
            txtMaHD.Enabled = false;
            txtMaHD.ReadOnly = true;
            dgvcthd.DataSource = HoaDonBUS.LayDSCTHD();
            this.nut_Control(5);
            btnXong.Enabled = false;
        }
        private void btnThemCT_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
            cthd.MaHD = Convert.ToInt32(txtMaCTHD.Text);
            cthd.MaSP = Convert.ToInt32(txtMaSP.Text);
            cthd.SoLuong = Convert.ToInt32(numSL.Value);
            cthd.DonGia = Convert.ToDecimal(lblDonGia.Text);
            if (HoaDonBUS.ThemCTHD(cthd))
            {
                MessageBox.Show("Thêm thành công");
                this.LoadCT();
                this.Clear_CT();
                this.nut_Control(5);

            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            txtMaCTHD.Clear();
            this.Clear_CT();
            btnXong.Enabled = false;
            this.nut_Control(5);

        }
        public void Clear_CT()
        {
            txtMaCTHD.Clear();
            lblDonGia.Text = "";
            txtMaSP.Clear();
            numSL.Value = 0;
            
        }
        private void dgvcthd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvcthd.SelectedRows[0];
            txtMaCTHD.Text = r.Cells["colMaCTHD"].Value.ToString();
            txtMaSP.Text = r.Cells["colMaSP"].Value.ToString();
            numSL.Text = r.Cells["colSoLuong"].Value.ToString();
            lblDonGia.Text = r.Cells["colDonGia"].Value.ToString();
            btnSuaCT.Enabled = true;
            this.nut_Control(7);
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
            cthd.MaHD = Convert.ToInt32(txtMaCTHD.Text);
            cthd.MaSP = Convert.ToInt32(txtMaSP.Text);
            cthd.SoLuong = Convert.ToInt32(numSL.Value.ToString());
            cthd.DonGia = Convert.ToDecimal(lblDonGia.Text);
            if (HoaDonBUS.SuaCTHD(cthd))
            {
                MessageBox.Show("Sửa Thành Công");
                this.LoadCT();
                this.Clear_CT();
                this.nut_Control(5);

            }
            else
                MessageBox.Show("Sửa Thất Bại");
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();

            DataGridViewRow r = dgvcthd.SelectedRows[0];
            cthd.MaHD = Convert.ToInt32(r.Cells["colMaCTHD"].Value.ToString());
            cthd.MaSP = Convert.ToInt32(r.Cells["colMaSP"].Value.ToString());

            if (HoaDonBUS.XoaCTHD(cthd))
            {
                MessageBox.Show("Xóa Thành Công");
                this.LoadCT();
                this.Clear_CT();
                this.nut_Control(5);

            }
            else
                MessageBox.Show("Xóa Thất bại");
        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtMaHD.Clear();
            this.Clear_CT();
            this.nut_Control(5);

        }

        private void btnTimMA_Click(object sender, EventArgs e)
        {
            int masp = Convert.ToInt32(txtMaSP.Text);
            if (HoaDonBUS.KTMASP(masp))
            {
                lblDonGia.Text = HoaDonBUS.LayDonGia(masp);
            }
            else
                MessageBox.Show("Mã không hợp lệ");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlgThoat == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.nut_Control(4);
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void numSL_ValueChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);

        }

        private void txtMaCTHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int mahd = Convert.ToInt32(txtTimKiem.Text);
            if (HoaDonBUS.KTMaHD(mahd))
            {
                dgvHoaDon.DataSource = HoaDonBUS.TimKiemHD(mahd);
                dgvcthd.DataSource = HoaDonBUS.TimKiemCT(mahd);
                txtTimKiem.Clear();
                txtTimKiem.Focus();

            }
            else
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ");
                txtTimKiem.Clear();
                txtTimKiem.Focus();

            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtMaSP.Focus();
            dgvHoaDon.DataSource = HoaDonBUS.laydshd();
            dgvcthd.DataSource = HoaDonBUS.LayDSCTHD();
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
                        btnHuy.Enabled = true;
                        btnXoa.Enabled = true;
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

                //cthd
                case 5:
                    //ct_xong
                    btnThemCT.Enabled = false;
                    btnSuaCT.Enabled = false;
                    btnXoaCT.Enabled = false;
                    btnHuyCT.Enabled = false;
                    btnXong.Enabled = true;
                    break;
                case 6:
                    //xoa_ct
                    btnXoaCT.Enabled = true;
                    btnHuyCT.Enabled = false;
                    btnXong.Enabled = true;
                    break;
                case 7:
                    //text_change
                    if (btnSuaCT.Enabled == true)
                    {
                        btnThemCT.Enabled = false;
                        btnHuyCT.Enabled = true;
                        btnXong.Enabled = true;
                        btnXoaCT.Enabled = true;
                    }
                    else
                    {
                        btnThemCT.Enabled = true;
                        btnSuaCT.Enabled = false;
                        btnXoaCT.Enabled = false;
                        btnXong.Enabled = true;
                    }
                    break;
            }
        }

        private void lblDonGia_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(7);
        }
    }
}
