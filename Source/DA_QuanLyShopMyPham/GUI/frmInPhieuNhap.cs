using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmInPhieuNhap : Form
    {
        public frmInPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmInPhieuNhap_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = true;
            CrystalPhieuNhap rpt = new CrystalPhieuNhap();
            rpt.SetDatabaseLogon("sa", "1905", "DESKTOP-JDHFGJO\\SQLEXPRESS", "QL_ShopMyPham");
            rpt.SetParameterValue("PN", frmNhapHang.maPN);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.Refresh();
        }
    }
}
