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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            dgvNhanVien.AutoGenerateColumns = false;
            this.formLoad();
            this.nut_Control(1);


        }
        private void formLoad()
        {
            dgvNhanVien.DataSource = NhanvienBUS.layDSNV();
            txtMaNV.Enabled = false;
            radNam.Checked = true;
            chkTrangThai.Checked = true;

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanvienDTO nv = new NhanvienDTO();
            nv.HOTENNV = txtHoTenNV.Text;
            nv.NGSINH = dtpNgSinh.Value;
            nv.DCHI = txtDiaChi.Text;
            nv.GIOITINH = radNam.Checked;
            nv.LUONG = txtLuong.Text;
            nv.TRANGTHAI = chkTrangThai.Checked;
            nv.USERNAME = txtUsername.Text;
            nv.PASSWORD = txtPassword.Text;
            if (NhanvienBUS.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm  nhân viên thành công ");
                this.formLoad();
                this.ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm  nhân viên thất bại");
            }
            this.nut_Control(1);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            NhanvienDTO nv = new NhanvienDTO();
            nv.MANV = Convert.ToInt32(txtMaNV.Text);
            nv.HOTENNV = txtHoTenNV.Text;
            nv.NGSINH = dtpNgSinh.Value;
            nv.DCHI = txtDiaChi.Text;
            nv.GIOITINH = radNam.Checked;
            nv.LUONG = txtLuong.Text;
            nv.USERNAME = txtUsername.Text;
            nv.PASSWORD = txtPassword.Text;
            nv.TRANGTHAI = chkTrangThai.Checked;
            if (NhanvienBUS.SuaNV(nv))
            {
                MessageBox.Show("sửa thành công");
                this.formLoad();
                this.ClearForm();

            }
            else
            {
                MessageBox.Show("sửa thất bại");
            }
            this.nut_Control(1);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvNhanVien.SelectedRows[0];
            int MANV = Convert.ToInt32(row.Cells["colMANV"].Value.ToString());
            if (NhanvienBUS.XoaNV(MANV))
            {
                MessageBox.Show("Xóa thành công");
                this.formLoad();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            this.ClearForm();
            this.nut_Control(1);
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.nut_Control(1);

        }

        private void ClearForm()
        {
            txtHoTenNV.Clear();
            txtMaNV.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            radNam.Checked = true;


        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvNhanVien.SelectedRows[0];
            txtMaNV.Text = r.Cells["colMANV"].Value.ToString();
            txtHoTenNV.Text = r.Cells["colHOTENNV"].Value.ToString();
            dtpNgSinh.Text = r.Cells["colNGSINH"].Value.ToString();
            txtDiaChi.Text = r.Cells["colDIACHI"].Value.ToString();
            if (r.Cells["colGIOITINH"].Value.ToString() == "True")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;


            }
            txtLuong.Text = r.Cells["colLUONG"].Value.ToString();
            txtUsername.Text = r.Cells["colUsername"].Value.ToString();
            txtPassword.Text = r.Cells["colPassword"].Value.ToString();
            chkTrangThai.Checked = Convert.ToBoolean(r.Cells["colTRANGTHAI"].Value.ToString());
            this.nut_Control(3);

        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlgThoat == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvNhanVien.Columns["colGIOITINH"].Index)
            {
                if (Convert.ToBoolean(e.Value) == true)
                {

                    e.Value = "Nam";
                }
                else
                {
                    e.Value = "Nữ";
                }

            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (NhanvienBUS.KTMaNV(Convert.ToInt32(txtTimKiem.Text)))
            {
                dgvNhanVien.DataSource = NhanvienBUS.TimKiemNV(Convert.ToInt32(txtTimKiem.Text));
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
            this.formLoad();
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
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
                    if(btnSua.Enabled == true)
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

        private void txtHoTenNV_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.nut_Control(4);
        }
    }
}