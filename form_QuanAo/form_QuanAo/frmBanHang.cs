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
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
            this.formLoad();
        }
        public void formLoad()
        {
            dgvSanPham.DataSource = BanHangBUS.LayDSSP();

            this.manv();


        }

        public void manv()
        {
            DataTable dt = new DataTable();
            dt = HoaDonBUS.LayMaNV();
            cboMaNV.DataSource = dt;
            cboMaNV.DisplayMember = "MANV";
            cboMaNV.ValueMember = "MANV";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (BanHangBUS.KTMaSP(Convert.ToInt32(txtMaSP.Text)))
            {
                dgvSanPham.DataSource = BanHangBUS.TimKiemSP(Convert.ToInt32(txtMaSP.Text));

            }
            else
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ");
                txtMaSP.Clear();
                txtMaSP.Focus();
                this.formLoad();
            }

            txtMaSP.Clear();
            txtMaSP.Focus();


        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtMaSP.Focus();
            this.formLoad();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvSanPham.SelectedRows[0];
            lblGia.Text = r.Cells["colDonGia"].Value.ToString();
            lblTenSP.Text = r.Cells["colTenSP"].Value.ToString();
            lblSize.Text = r.Cells["colSizeSP"].Value.ToString();
            lblMaSP.Text = r.Cells["colMaSP"].Value.ToString();

        }


        private void btnThem_Click(object sender, EventArgs e)
        {

            BanHangDTO sp = new BanHangDTO();
            sp.DonGia = lblGia.Text;
            sp.soluong = Convert.ToInt32(numSL.Value);
            decimal tt = sp.soluong * Convert.ToInt32(sp.DonGia);

            dgvDatHang.Rows.Add(lblMaSP.Text, lblTenSP.Text, numSL.Value.ToString(), lblSize.Text, lblGia.Text, tt.ToString());
            int sum = 0;
            for (int i = 0; i < dgvDatHang.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvDatHang.Rows[i].Cells["colTong"].Value);
            }
            lblTongTien.Text = string.Format("{0} VNĐ", sum.ToString());
            this.Clear();



        }

        private void btnSDT_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text;

            if (BanHangBUS.KTKH(sdt))
            {
                string tenkh = BanHangBUS.LayTenKH(sdt);
                txtTenKH.Text = tenkh.ToString();
            }
            else
            {
                MessageBox.Show("Chưa có khách hàng");
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.TenKH = txtTenKH.Text;
            kh.SDT = txtSDT.Text;
            if (BanHangBUS.ThemKH(kh))
            {
                MessageBox.Show("Đã Thêm 1 Khách Hàng");
            }
        }

        private void dgvDatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow r = dgvDatHang.SelectedRows[0];
            lblMaSP.Text = r.Cells["colMa"].Value.ToString();
            lblGia.Text = r.Cells["colGia"].Value.ToString();
            lblTenSP.Text = r.Cells["colTen"].Value.ToString();
            numSL.Text = r.Cells["colSL"].Value.ToString();
            lblSize.Text = r.Cells["colSize"].Value.ToString();


        }
        public void Clear()
        {
            numSL.Value = 0;
            lblMaSP.Text = "";
            lblSize.Text = "";
            lblTenSP.Text = "";
            lblGia.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            BanHangDTO sp = new BanHangDTO();
            sp.DonGia = lblGia.Text;
            sp.soluong = Convert.ToInt32(numSL.Value);
            decimal tt = sp.soluong * Convert.ToInt32(sp.DonGia);

            DataGridViewRow newDataRow = dgvDatHang.Rows[0];
            newDataRow.Cells[0].Value = lblMaSP.Text;
            newDataRow.Cells[1].Value = lblTenSP.Text;
            newDataRow.Cells[2].Value = numSL.Text;
            newDataRow.Cells[3].Value = lblSize.Text;
            newDataRow.Cells[4].Value = lblGia.Text;
            newDataRow.Cells[5].Value = tt.ToString();
            int sum = 0;
            for (int i = 0; i < dgvDatHang.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvDatHang.Rows[i].Cells["colTong"].Value);
            }
            lblTongTien.Text = string.Format("{0} VNĐ", sum.ToString());
            this.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgvDatHang.SelectedRows[0];
            dgvDatHang.Rows.Remove(r);
            int sum = 0;
            for (int i = 0; i < dgvDatHang.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvDatHang.Rows[i].Cells["colTong"].Value);
            }
            lblTongTien.Text = string.Format("{0} VNĐ", sum.ToString());
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

           
            //HOADON
            HoaDonDTO hd = new HoaDonDTO();
            string sdt = txtSDT.Text;
            string makh = BanHangBUS.LayMaKH(sdt).ToString();
            hd.MaKH = Convert.ToInt32(makh);
            hd.NgLap = dtpNgayLap.Value;
            hd.MaNV = Convert.ToInt32(cboMaNV.SelectedValue.ToString());

            int sum = 0;
            for (int i = 0; i < dgvDatHang.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvDatHang.Rows[i].Cells["colTong"].Value);
            }
            hd.TongTien = Convert.ToDecimal(sum);
            hd.TrangThai = true;
            //ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
            List<clsSanPham> lstsanpham = new List<clsSanPham>();
            for (int i = 0; i < dgvDatHang.Rows.Count; i++)
            {
                //cthd.MaHD = Convert.ToInt32(BanHangBUS.LayMaHD());
                //cthd.MaSP = Convert.ToInt32(r.Cells["colMa"].Value);
                //cthd.SoLuong = Convert.ToInt32(r.Cells["colSL"].Value);
                //cthd.DonGia = Convert.ToDecimal(r.Cells["colGia"].Value);
                clsSanPham sp = new clsSanPham();
                sp.MASP = Convert.ToInt32(dgvDatHang.Rows[i].Cells["colMa"].Value);
                sp.SOLUONG = Convert.ToInt32(dgvDatHang.Rows[i].Cells["colSL"].Value);
                sp.DONGIA = Convert.ToDecimal(dgvDatHang.Rows[i].Cells["colGia"].Value);

                lstsanpham.Add(sp);


            }
            if (BanHangBUS.ThemHD(hd, lstsanpham))
            {
                MessageBox.Show("Tạo hóa đơn thành công");
                lstsanpham.Clear();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }


            int t = 0;
            for (int i = 0; i < dgvDatHang.Rows.Count; ++i)
            {
                t += Convert.ToInt32(dgvDatHang.Rows[i].Cells["colTong"].Value);
            }

            int mahd = HoaDonBUS.MaHD();
            frmRptHoaDon frm = new frmRptHoaDon(mahd);
            frm.Show();


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lblMaSP.Text = "";
            lblTenSP.Text = "";
            lblTongTien.Text = "";
            lblGia.Text = "";
            numSL.Value = 0;
            txtSDT.Clear();
            txtTenKH.Clear();
            lblSize.Text = "";
            dgvDatHang.Rows.Clear();
            


        }
    }
}
