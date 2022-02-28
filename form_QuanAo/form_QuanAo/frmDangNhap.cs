using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using BUS;
namespace form_QuanAo
{
    public partial class frmDangNhap : Form
    {
        frmMain x;
        public frmDangNhap(frmMain f)
        {
            InitializeComponent();
            x = f;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
       
            if (NhanvienBUS.KTDangNhap(username, password))
            {
                MessageBox.Show("Đăng nhập thành công");
                x.hienthi(NhanvienBUS.TennNV(username));
                this.Close();
                //frmMain f = new frmMain();
                //f.Show();
                //this.Hide();

            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
           
        }
        //private void ShowMdiChildForm(Form f)
        //{
        //    foreach (Form frm in this.MdiChildren)
        //    {
        //        frm.Hide();
        //    }
        
        //    //f.ShowIcon = false;
        //    //f.ControlBox = false;
        //    //f.FormBorderStyle = FormBorderStyle.None;
        //    f.Show();
          
        //}
    }
}
