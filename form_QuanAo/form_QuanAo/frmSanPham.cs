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
using System.IO;
namespace form_QuanAo
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();

            dgvSanPham.AutoGenerateColumns = false;
            chkTrangThai.Checked = true;
            this.formLoad();
            this.Load_CT();
            txtMaCT.Enabled = false;
           
        }

        public void formLoad()
        {

            dgvSanPham.DataSource = SanPhamBUS.LayDSSanPham();
            this.loai();
            this.nsx();
            this.size();
            this.nut_Control(1);

        }
        public void nsx()
        {
            DataTable dt = new DataTable();
            dt = SanPhamBUS.DSNSX();
            cboNSX.DataSource = dt;
            cboNSX.DisplayMember = "TENNHASX";
            cboNSX.ValueMember = "MASX";
        }
        public void loai()
        {
            DataTable dt = new DataTable();
            dt = SanPhamBUS.DSLoaiSP();
            cboLoaiSP.DataSource = dt;
            cboLoaiSP.DisplayMember = "TENLOAI";
            cboLoaiSP.ValueMember = "MALOAI";
        }

        public void size()
        {
            DataTable dt = new DataTable();
            dt = SanPhamBUS.DSSIZE();
            cboSize.DataSource = dt;
            cboSize.DisplayMember = "SIZE";
            cboSize.ValueMember = "SIZE";
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //SANPHAM

            SanPhamDTO sp = new SanPhamDTO();
            sp.Tensp = txtTenSP.Text;
            sp.Maloai = Convert.ToInt32(cboLoaiSP.SelectedValue.ToString());
            sp.DonGia = txtDonGia.Text;
            sp.SoLuongTon = txtSoLuong.Text;
            sp.Masx = Convert.ToInt32(cboNSX.SelectedValue.ToString());

            int ten = Convert.ToInt32(SanPhamBUS.LayMaSP()) + 1;
            sp.HinhAnh = ten.ToString() + ".jpg";
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\img\" + sp.HinhAnh;
            picHinhAnh.Image.Save(path);

            sp.TrangThai = chkTrangThai.Checked;


            if (SanPhamBUS.ThemSanPham(sp))
            {

                MessageBox.Show("Thêm Thành Công");
                txtMaCT.Text = SanPhamBUS.LayMaSP();
                this.formLoad();
                this.ClearForm();
                this.Load_CT();
                this.nut_Control(1);

            }
            else
            {
                MessageBox.Show("Thêm thất bại");
                btnHuy.Enabled = true;
            }

            ClearForm();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvSanPham.SelectedRows[0];
            int masp = Convert.ToInt32(row.Cells["colMaSP"].Value.ToString());
            if (SanPhamBUS.XoaSP(masp))
            {
                MessageBox.Show("Xóa thành công");
                this.formLoad();
                this.nut_Control(1);

            }
            else
            {
                MessageBox.Show("Xóa thất bại");
                btnHuy.Enabled = true;
            }

        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvSanPham.Columns["colHinhANh"].Index)
            {
                e.Value = Image.FromFile(@"img\" + e.Value);
            }

            //if (e.ColumnIndex == dgvSanPham.Columns["colMaSP"].Index)
            //{
            //    if (Convert.ToBoolean(e.Value) == true)
            //    {
            //        if ((Convert.ToInt32(e.Value)) + 1 < 10)
            //        {
            //            e.Value = "SP00" + e.Value;
            //        }
            //        else if ((Convert.ToInt32(e.Value)) + 1 <= 100)
            //        {
            //            e.Value = "SP0" + e.Value;
            //        }
            //        else
            //        {
            //            e.Value = "SP" + e.Value;
            //        }
            //    }
            //}


        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvSanPham.SelectedRows[0];
            txtMaSP.Text = r.Cells["colMaSP"].Value.ToString();
            txtTenSP.Text = r.Cells["colTenSP"].Value.ToString();
            cboLoaiSP.Text = SanPhamBUS.LayLoai(Convert.ToInt32(r.Cells["colMaLoai"].Value.ToString()));
            txtDonGia.Text = r.Cells["colDonGia"].Value.ToString();
            txtSoLuong.Text = r.Cells["colSoluongTon"].Value.ToString();
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\img\" + r.Cells["colHinhAnh"].Value.ToString();
            picHinhAnh.Image = Image.FromFile(path);

            chkTrangThai.Checked = Convert.ToBoolean(r.Cells["colTrangThai"].Value);
            cboNSX.Text = SanPhamBUS.Laynsx(Convert.ToInt32(r.Cells["colMaSX"].Value.ToString()));
            txtMaCT.Text = txtMaSP.Text;
            this.nut_Control(3);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SanPhamDTO sp = new SanPhamDTO();
            int num;
            Random rd = new Random();
            num = rd.Next(1, 1000);
            sp.Masp = Convert.ToInt32(txtMaSP.Text);
            sp.Tensp = txtTenSP.Text;
            sp.Maloai = Convert.ToInt32(cboLoaiSP.SelectedValue.ToString());
            sp.DonGia = txtDonGia.Text;
            sp.SoLuongTon = txtSoLuong.Text;
            sp.Masx = Convert.ToInt32(cboNSX.SelectedValue.ToString());

            sp.HinhAnh = num + ".jpg";
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\img\" + num + ".jpg";
            picHinhAnh.Image.Save(path);
            sp.TrangThai = chkTrangThai.Checked;

            ChiTietSanPhamDTO ctsp = new ChiTietSanPhamDTO();
            ctsp.MaSP = Convert.ToInt32(txtMaSP.Text);
            ctsp.Size = cboSize.SelectedValue.ToString();
            ctsp.Mau = txtMau.Text;



            if (SanPhamBUS.SuaSanPham(sp))
            {
                MessageBox.Show("Sửa thành công");
                this.formLoad();
                this.ClearForm();
                this.Load_CT();
                this.nut_Control(1);
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            ClearForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlgThoat == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.nut_Control(1);


        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
        public void ClearForm()
        {
            txtMaSP.Clear();
            txtDonGia.Clear();
            txtTenSP.Clear();
            txtSoLuong.Clear();
            cboLoaiSP.SelectedIndex = 0;
            cboNSX.SelectedIndex = 0;
            cboSize.SelectedIndex = 0;
            txtMau.Clear();
            picHinhAnh.Image = null;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int masp = Convert.ToInt32(txtTimKiem.Text);
            if (SanPhamBUS.KTMaSP(masp))
            {
                dgvSanPham.DataSource = SanPhamBUS.TimKiemSP(masp);
                dgvctsp.DataSource = SanPhamBUS.TimKiemCT(masp);
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
            this.formLoad();
            this.Load_CT();
        }

        private void btnThuMuc_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdHinhAnh.ShowDialog();
            if (dr == DialogResult.OK)
            {
                picHinhAnh.Image = Image.FromFile(ofdHinhAnh.FileName);
                picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;

            }

        }
        public void Load_CT()
        {
            dgvctsp.DataSource = SanPhamBUS.LayDSCT();
            this.nut_Control(5);
        }

        private void dgvctsp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvctsp.SelectedRows[0];
            txtMaCT.Text = r.Cells["colMaCTSP"].Value.ToString();
            txtMau.Text = r.Cells["colMau"].Value.ToString();
            cboSize.Text = r.Cells["colSize"].Value.ToString();
            btnSuaCT.Enabled = true;
            this.nut_Control(7);

        }
        public void clear_CT()
        {
            txtMau.Clear();
            cboSize.SelectedValue = 0;
        }
        private void btnThemCT_Click(object sender, EventArgs e)
        {
            ChiTietSanPhamDTO ctsp = new ChiTietSanPhamDTO();
            ctsp.MaSP = Convert.ToInt32(txtMaCT.Text);
            ctsp.Size = cboSize.SelectedValue.ToString();
            ctsp.Mau = txtMau.Text;
            if (SanPhamBUS.ThemCTSP(ctsp))
            {
                MessageBox.Show("Thêm Thành Công");
                this.Load_CT();
                this.clear_CT();
                this.nut_Control(5);

            }
            else
                MessageBox.Show("Thêm Thất Bại");

        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            txtMaCT.Clear();
            btnXong.Enabled = false;
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            ChiTietSanPhamDTO ctsp = new ChiTietSanPhamDTO();
            ctsp.MaSP = Convert.ToInt32(txtMaCT.Text);
            ctsp.Mau = txtMau.Text;
            ctsp.Size = cboSize.SelectedValue.ToString();
            if (SanPhamBUS.SuaCTSP(ctsp))
            {
                MessageBox.Show("Sửa Thành Công");
                this.Load_CT();
                this.clear_CT();
                txtMaCT.Clear();
                this.nut_Control(5);

            }
            else
                MessageBox.Show("Sửa Thất Bại");

        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            ChiTietSanPhamDTO ctsp = new ChiTietSanPhamDTO();
            DataGridViewRow r = dgvctsp.SelectedRows[0];
            ctsp.MaSP = Convert.ToInt32(r.Cells["colMaCTSP"].Value.ToString());
            ctsp.Mau = r.Cells["colMau"].Value.ToString();
            ctsp.Size = r.Cells["colSize"].Value.ToString();

            if (SanPhamBUS.XoaCTSP(ctsp))
            {
                MessageBox.Show("Xóa Thành Công");
                this.Load_CT();
                this.nut_Control(5);

            }
            else
                MessageBox.Show("Xóa Thất Bại");
        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            this.clear_CT();
            txtMaCT.Clear();
            this.nut_Control(5);

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
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

                    //cthd
                case 5:
                    //ct_xong
                    btnThemCT.Enabled = false;
                    btnSuaCT.Enabled = false;
                    btnXoaCT.Enabled = false;
                    btnHuyCT.Enabled = false;
                    break;
                case 6:
                    //xoa_ct
                    btnXoaCT.Enabled = true;
                    btnHuyCT.Enabled = false;
                    break;
                case 7:
                    //text_change
                    if (btnSuaCT.Enabled == true)
                    {
                        btnThemCT.Enabled = false;
                        btnHuyCT.Enabled = true;
                    }
                    else
                    {
                        btnThemCT.Enabled = true;
                        btnSuaCT.Enabled = false;
                        btnXoaCT.Enabled = false;
                    }
                    break;
                
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.nut_Control(4);
        }
        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);

        }

        private void cboNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);

        }

        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);

        }

        private void dgvctsp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.nut_Control(6);
        }

        private void txtMau_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(7);
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nut_Control(7);
        }
    }
}
