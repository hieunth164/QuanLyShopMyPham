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
    public partial class frmDoanhThu : Form
    {
        HoaDon_BLL hd = new HoaDon_BLL();
        PhieuNhap_BLL pn = new PhieuNhap_BLL();
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdTatCa.Checked == true)
                {
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = txtNam.Enabled = false;
                    cbThang.Enabled = false;
                    if (hd.getDataHoaDon().Rows.Count == 0)
                    {
                        MessageBox.Show("Chưa có phiếu bán hàng nào");
                        return;
                    }
                    //dgvHoaDon.DataSource = hd.getData();
                    dgvHoaDon.DataSource = hd.getDataHoaDon();
                    int tongTien = 0;
                    foreach (DataRow dr in hd.getDataHoaDon().Rows)
                    {
                        tongTien += int.Parse(dr["TongTien"].ToString());
                    }
                    txtTongBan.Text = tongTien.ToString();
                }

            }
            catch { }
        }

        private void rdTrongThang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdTrongThang.Checked == true)
                {
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
                    txtNam.Enabled = true;
                    cbThang.Enabled = true;
                    txtTongBan.Text = "0";
                    Delete_DGVHoaDon();
                }
            }
            catch { }
        }

        private void rdTrongNam_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdTrongNam.Checked == true)
                {
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
                    txtNam.Enabled = true;
                    cbThang.Enabled = false;
                    txtTongBan.Text = "0";
                    Delete_DGVHoaDon();
                }
            }
            catch { }
        }

        private void rdTrongKhoangTG_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdTrongKhoangTG.Checked == true)
                {
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = true;
                    txtNam.Enabled = false;
                    cbThang.Enabled = false;
                    txtTongBan.Text = "0";
                    Delete_DGVHoaDon();
                }
            }
            catch { }
        }

        private void rdTatCa2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdTatCa2.Checked == true)
                {
                    dateTimePicker3.Enabled = dateTimePicker3.Enabled = txtNam2.Enabled = false;
                    cbThang2.Enabled = false;
                    if (pn.getDataPhieuNhap().Rows.Count == 0)
                    {
                        MessageBox.Show("Chưa có phiếu nhập hàng nào");
                        return;
                    }
                    dgvPhieuNhap.DataSource = pn.getDataPhieuNhap();
                    int tongTien = 0;
                    foreach (DataRow dr in pn.getDataPhieuNhap().Rows)
                    {
                        tongTien += int.Parse(dr["TongTien"].ToString());
                    }
                    txtTongNhap.Text = tongTien.ToString();
                }

            }
            catch { }
        }

        private void rdTrongThang2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdTrongThang2.Checked == true)
                {
                    dateTimePicker3.Enabled = dateTimePicker4.Enabled = false;
                    txtNam2.Enabled = true;
                    cbThang2.Enabled = true;
                    txtTongNhap.Text = "0";
                    Delete_DGVPhieuNhap();
                }
            }
            catch { }
        }

        private void rdTrongNam2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdTrongNam2.Checked == true)
                {
                    dateTimePicker3.Enabled = dateTimePicker4.Enabled = false;
                    txtNam2.Enabled = true;
                    cbThang2.Enabled = false;
                    txtTongNhap.Text = "0";
                    Delete_DGVPhieuNhap();
                }
            }
            catch { }
        }

        private void rdTrongKhoangTG2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdTrongKhoangTG2.Checked == true)
                {
                    dateTimePicker3.Enabled = dateTimePicker4.Enabled = true;
                    txtNam2.Enabled = false;
                    cbThang2.Enabled = false;
                    txtTongNhap.Text = "0";
                    Delete_DGVPhieuNhap();
                }
            }
            catch { }
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            try
            {
                rdTatCa.Checked = true;
                cbThang.SelectedItem = cbThang.Items[0];
                txtTongBan.Text = "0";

                rdTatCa2.Checked = true;
                cbThang2.SelectedItem = cbThang2.Items[0];
                txtTongNhap.Text = "0";
            }
            catch { }
        }

        public void Delete_DGVHoaDon()
        {
            try
            {
                for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                {
                    dgvHoaDon.Rows.RemoveAt(i);
                    i--;
                }
            }
            catch { }

        }

        public void Delete_DGVPhieuNhap()
        {
            try
            {
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    dgvPhieuNhap.Rows.RemoveAt(i);
                    i--;
                }
            }
            catch { }

        }

        private void btnThongKeBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdTatCa.Checked == true)
                    return;
                if (rdTrongThang.Checked == true)
                {
                    int thang = int.Parse(cbThang.SelectedItem.ToString());
                    int nam = int.Parse(txtNam.Text);

                    if (hd.getDataThangNam(nam, thang).Rows.Count == 0)
                    {
                        MessageBox.Show("Chưa có hóa đơn nào");
                        return;
                    }
                    dgvHoaDon.DataSource = hd.getDataThangNam(nam, thang);
                    int tongTien = 0;
                    foreach (DataRow dr in hd.getDataThangNam(nam, thang).Rows)
                    {
                        tongTien += int.Parse(dr["TongTien"].ToString());
                    }
                    txtTongBan.Text = tongTien.ToString();
                }
                else
                {
                    if (rdTrongNam.Checked == true)
                    {
                        int nam = int.Parse(txtNam.Text);
                        if (hd.getDataNam(nam).Rows.Count == 0)
                        {
                            MessageBox.Show("Chưa có hóa đơn nào");
                            return;
                        }
                        dgvHoaDon.DataSource = hd.getDataNam(nam);
                        int tongTien = 0;
                        foreach (DataRow dr in hd.getDataNam(nam).Rows)
                        {
                            tongTien += int.Parse(dr["TongTien"].ToString());
                        }
                        txtTongBan.Text = tongTien.ToString();
                    }
                    else
                    {
                        DateTime t1 = dateTimePicker1.Value;
                        DateTime t2 = dateTimePicker2.Value;
                        if (hd.getDataNgay(t1, t2).Rows.Count == 0)
                        {
                            MessageBox.Show("Chưa có hóa đơn nào");
                            return;
                        }
                        dgvHoaDon.DataSource = hd.getDataNgay(t1, t2);
                        int tongTien = 0;
                        foreach (DataRow dr in hd.getDataNgay(t1, t2).Rows)
                        {
                            tongTien += int.Parse(dr["TongTien"].ToString());
                        }
                        txtTongBan.Text = tongTien.ToString();
                    }
                }
            }
            catch { }
        }

        private void btnThongKeNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdTatCa2.Checked == true)
                    return;
                if (rdTrongThang2.Checked == true)
                {
                    int thang = int.Parse(cbThang2.SelectedItem.ToString());
                    int nam = int.Parse(txtNam2.Text);

                    if (pn.getDataThangNam(nam, thang).Rows.Count == 0)
                    {
                        MessageBox.Show("Chưa có phiếu nhập nào");
                        return;
                    }
                    dgvPhieuNhap.DataSource = pn.getDataThangNam(nam, thang);
                    int tongTien = 0;
                    foreach (DataRow dr in pn.getDataThangNam(nam, thang).Rows)
                    {
                        tongTien += int.Parse(dr["TongTien"].ToString());
                    }
                    txtTongNhap.Text = tongTien.ToString();
                }
                else
                {
                    if (rdTrongNam2.Checked == true)
                    {
                        int nam = int.Parse(txtNam2.Text);
                        if (pn.getDataNam(nam).Rows.Count == 0)
                        {
                            MessageBox.Show("Chưa có phiếu nhập nào");
                            return;
                        }
                        dgvPhieuNhap.DataSource = pn.getDataNam(nam);
                        int tongTien = 0;
                        foreach (DataRow dr in pn.getDataNam(nam).Rows)
                        {
                            tongTien += int.Parse(dr["TongTien"].ToString());
                        }
                        txtTongNhap.Text = tongTien.ToString();
                    }
                    else
                    { 
                        DateTime t1 = dateTimePicker3.Value;
                        DateTime t2 = dateTimePicker4.Value;
                        if (pn.getDataNgay(t1, t2).Rows.Count == 0)
                        {
                            MessageBox.Show("Chưa có phiếu nhập nào");
                            return;
                        }
                        dgvPhieuNhap.DataSource = pn.getDataNgay(t1, t2);
                        int tongTien = 0;
                        foreach (DataRow dr in pn.getDataNgay(t1, t2).Rows)
                        {
                            tongTien += int.Parse(dr["TongTien"].ToString());
                        }
                        txtTongNhap.Text = tongTien.ToString();
                    }
                }
            }
            catch { }
        }

        private void btnBaoCaoBan_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }
            List<HoaDon> pListHoaDon = new List<HoaDon>();
            // Đổ dữ liệu vào danh sách

            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                HoaDon i = new HoaDon();
                i.MaHoaDon = item.Cells[0].Value.ToString();
                i.NhanVien = item.Cells[1].Value.ToString();
                i.KhachHang = item.Cells[2].Value.ToString();
                i.NgayLap = DateTime.Parse(item.Cells[3].Value.ToString());
                i.TongTien = long.Parse(item.Cells[4].Value.ToString());
                pListHoaDon.Add(i);
            }

            string path = string.Empty;
            excel.ExportHoaDon(pListHoaDon, ref path, false);
            // Confirm for open file was exported
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thôngtin",
               MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void btnBaoCaoNhap_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dgvPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }
            List<PhieuNhap> pListPhieuNhap = new List<PhieuNhap>();
            // Đổ dữ liệu vào danh sách

            foreach (DataGridViewRow item in dgvPhieuNhap.Rows)
            {
                PhieuNhap i = new PhieuNhap();
                i.MaPhieuNhap = item.Cells[0].Value.ToString();
                i.NhanVien = item.Cells[1].Value.ToString();
                i.NhaCungCap = item.Cells[2].Value.ToString();
                i.NgayNhap = DateTime.Parse(item.Cells[3].Value.ToString());
                i.TongTien = long.Parse(item.Cells[4].Value.ToString());
                pListPhieuNhap.Add(i);
            }

            string path = string.Empty;
            excel.ExportPhieuNhap(pListPhieuNhap, ref path, false);
            // Confirm for open file was exported
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thôngtin",
               MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            frmXemChiTietHoaDon frm = new frmXemChiTietHoaDon();
            frm.maHD = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            frmXemChiTietPhieuNhap frm = new frmXemChiTietPhieuNhap();
            frm.maPN = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
        }
    }
}
