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
    public partial class frmNhaSanXuat : Form
    {
        public frmNhaSanXuat()
        {
            InitializeComponent();
            dgvNSX.DataSource = NSXBUS.LayDSNSX();
            txtMaSX.Enabled = false;
            this.nut_Control(1);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NSXDTO nsx = new NSXDTO();
            nsx.TenNSX = txtTenNSX.Text;
            if (NSXBUS.ThemNSX(nsx))
            {
                dgvNSX.DataSource = NSXBUS.LayDSNSX();
                MessageBox.Show("Thêm Thành Công");
                this.Clear();
            }
            else
                MessageBox.Show("Thêm Thát Bại");
            this.nut_Control(1);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NSXDTO nsx = new NSXDTO();
            nsx.MaSX = Convert.ToInt32(txtMaSX.Text);
            nsx.TenNSX = txtTenNSX.Text;
            if (NSXBUS.SuaNSX(nsx))
            {
                dgvNSX.DataSource = NSXBUS.LayDSNSX();
                MessageBox.Show("Sửa Thành Công");
                this.Clear();
                this.nut_Control(1);
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
               
            }    
                


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NSXDTO nsx = new NSXDTO();
            DataGridViewRow r = dgvNSX.SelectedRows[0];
            nsx.MaSX = Convert.ToInt32(r.Cells["colMaNSX"].Value.ToString());
            if (NSXBUS.XoaNSX(nsx))
            {
                dgvNSX.DataSource = NSXBUS.LayDSNSX();
                MessageBox.Show("Xóa Thành Công");
                this.Clear();
            }
            else
                MessageBox.Show("Xóa Thát Bại");
            this.nut_Control(1);

        }

        private void dgvNSX_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvNSX.SelectedRows[0];
            txtMaSX.Text = r.Cells["colMaNSX"].Value.ToString();
            txtTenNSX.Text = r.Cells["colTenNSX"].Value.ToString();
            this.nut_Control(3);
        }
        public void Clear()
        {
            txtTenNSX.Clear();
            txtMaSX.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Clear();
            this.nut_Control(1);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (NSXBUS.KT(Convert.ToInt32(txtTimKiem.Text)))
            {
                dgvNSX.DataSource = NSXBUS.TimKiem(Convert.ToInt32(txtTimKiem.Text));
            }
            else
            {
                MessageBox.Show("Mã Không hợp lệ");

            }

        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvNSX.DataSource = NSXBUS.LayDSNSX();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNhaSanXuat_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgThoat;
            dlgThoat = MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlgThoat == DialogResult.Cancel)
                e.Cancel = true;
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

        private void dgvNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.nut_Control(4);
        }

        private void txtTenNSX_TextChanged(object sender, EventArgs e)
        {
            this.nut_Control(2);
        }
    }
}
