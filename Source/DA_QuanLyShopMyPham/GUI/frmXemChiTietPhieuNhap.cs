using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frmXemChiTietPhieuNhap : Form
    {
        CTPN_BLL ctpn = new CTPN_BLL();
        public string maPN = "";
        public frmXemChiTietPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmXemChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            if (maPN != "")
            {
                txtMaPN.Text = maPN;
                btnLoc_Click(sender, e);
                btnHienTatCa.Enabled = false;
                txtMaPN.Enabled = false;

            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPN.Focus();
                return;
            }
            else
            {
                dgvCTPN.DataSource = ctpn.getDataCTPN(txtMaPN.Text);
                int tongThanhTien = 0;
                foreach (DataRow dr in ctpn.getDataCTPN(txtMaPN.Text).Rows)
                {
                    tongThanhTien += int.Parse(dr["ThanhTienNhap"].ToString());
                }
                lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

            }
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            dgvCTPN.DataSource = ctpn.getData();
            int tongThanhTien = 0;
            foreach (DataRow dr in ctpn.getData().Rows)
            {
                tongThanhTien += int.Parse(dr["ThanhTienNhap"].ToString());
            }
            lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";
        }
    }
}
