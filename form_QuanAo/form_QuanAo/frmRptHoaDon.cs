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
    public partial class frmRptHoaDon : Form
    {
        private static int MAHD;
        public frmRptHoaDon()
        {
            InitializeComponent();
        }
        public frmRptHoaDon(int mahd)
        {
            InitializeComponent();
            MAHD= mahd;
        }
        private void frmRptHoaDon_Load(object sender, EventArgs e)
        {
            DataTable dt = HoaDonBUS.rptHoaDon(MAHD);
            rpt_HoaDon rpt = new rpt_HoaDon();
            rpt.SetDataSource(dt);
            crpHoaDon.ReportSource = rpt;
        }
    }
}
