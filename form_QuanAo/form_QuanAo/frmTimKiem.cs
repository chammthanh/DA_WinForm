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
namespace form_QuanAo
{
    public partial class frmTimKiem : Form
    {
        public frmTimKiem()
        {
            InitializeComponent();
        }

        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            

        }


        private void cboBang_Format(object sender, ListControlConvertEventArgs e)
        {
            int num = Convert.ToInt32(cboBang.SelectedIndex.ToString());
            switch (num)
            {
                case 0:
                    dgvLoad.DataSource = TimKiemBUS.KHACHHANG();
                    break;
                case 1:
                    dgvLoad.DataSource = TimKiemBUS.HOADON();
                    break;
                case 2:
                    dgvLoad.DataSource = TimKiemBUS.NHANVIEN();
                    
                    break;
                case 3:
                    dgvLoad.DataSource = TimKiemBUS.SANPHAM();
                    break;
                case 4:
                    dgvLoad.DataSource = TimKiemBUS.CHITIETHOADON();
                    break;
                case 5:
                    dgvLoad.DataSource = TimKiemBUS.CHITIETSANPHAM();
                    break;
                case 6:
                    dgvLoad.DataSource = TimKiemBUS.NHASANXUAT();
                    break;

            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(cboBang.SelectedIndex.ToString());
            int ma = Convert.ToInt32(txtMa.Text);
            switch (num)
            {
                case 0:
                   
                    if(TimKiemBUS.KTMaKH(ma))
                    {
                        dgvLoad.DataSource = TimKiemBUS.TimKiemKH(ma);
                    }    
                    else
                        MessageBox.Show("Không tìm thấy");
                    break;
                case 1:
           
                    if (TimKiemBUS.KTMaHD(ma))
                    {
                        dgvLoad.DataSource = TimKiemBUS.TimKiemHD(ma);
                    }
                    else
                        MessageBox.Show("Không tìm thấy");
                    break;
                case 2:
               
                    if (TimKiemBUS.KTMaNV(ma))
                    {
                        dgvLoad.DataSource = TimKiemBUS.TimKiemNV(ma);
                    }
                    else
                        MessageBox.Show("Không tìm thấy");
                    break;
                case 3:
                    dgvLoad.DataSource = TimKiemBUS.SANPHAM();
                    if (TimKiemBUS.KTMaSP(ma))
                    {
                        dgvLoad.DataSource = TimKiemBUS.TimKiemSP(ma);
                    }
                    else
                        MessageBox.Show("Không tìm thấy");
                    break;
                case 4:
                    dgvLoad.DataSource = TimKiemBUS.CHITIETHOADON();
                    if (TimKiemBUS.KTMaCTHD(ma))
                    {
                        dgvLoad.DataSource = TimKiemBUS.TimKiemCTHD(ma);
                    }
                    else
                        MessageBox.Show("Không tìm thấy");
                    break;
                case 5:
                    if (TimKiemBUS.KTMaCTSP(ma))
                    {
                        dgvLoad.DataSource = TimKiemBUS.TimKiemCTSP(ma);
                    }
                    else
                        MessageBox.Show("Không tìm thấy");
                    break;
                case 6:
                    if (TimKiemBUS.KTMaNSX(ma))
                    {
                        dgvLoad.DataSource = TimKiemBUS.TimKiemNSX(ma);
                    }
                    else
                        MessageBox.Show("Không tìm thấy");
                    break;
            }
            txtMa.Clear();
            
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(cboBang.SelectedIndex.ToString());
            switch (num)
            {
                case 0:
                    dgvLoad.DataSource = TimKiemBUS.KHACHHANG();
                    break;
                case 1:
                    dgvLoad.DataSource = TimKiemBUS.HOADON();
                    break;
                case 2:
                    dgvLoad.DataSource = TimKiemBUS.NHANVIEN();

                    break;
                case 3:
                    dgvLoad.DataSource = TimKiemBUS.SANPHAM();
                    break;
                case 4:
                    dgvLoad.DataSource = TimKiemBUS.CHITIETHOADON();
                    break;
                case 5:
                    dgvLoad.DataSource = TimKiemBUS.CHITIETSANPHAM();
                    break;
                case 6:
                    dgvLoad.DataSource = TimKiemBUS.NHASANXUAT();
                    break;
                   
            }
            txtMa.Clear();
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
