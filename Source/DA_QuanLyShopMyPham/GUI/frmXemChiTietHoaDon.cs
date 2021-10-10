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
    public partial class frmXemChiTietHoaDon : Form
    {
        CTHD_BLL cthd = new CTHD_BLL();
        public string maHD = "";
        public frmXemChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void frmXemChiTietHoaDon_Load(object sender, EventArgs e)
        {
            if (maHD != "")
            {
                txtMaHD.Text = maHD;
                btnHienTatCa.Enabled = false;
                btnLoc_Click(sender, e);
                txtMaHD.Enabled = false;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHD.Focus();
                return;
            }
            else
            {
                dgvCTHD.DataSource = cthd.getDataCTHD(txtMaHD.Text);
                int tongThanhTien = 0;
                foreach (DataRow dr in cthd.getDataCTHD(txtMaHD.Text).Rows)
                {
                    tongThanhTien += int.Parse(dr["ThanhTienBan"].ToString());
                }
                lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

            }
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            dgvCTHD.DataSource = cthd.getData();
            int tongThanhTien = 0;
            foreach (DataRow dr in cthd.getData().Rows)
            {
                tongThanhTien += int.Parse(dr["ThanhTienBan"].ToString());
            }
            lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";
        }
    }
}
