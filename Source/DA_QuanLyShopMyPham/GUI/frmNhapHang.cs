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
    public partial class frmNhapHang : Form
    {
        PhieuNhap_BLL pn = new PhieuNhap_BLL();
        CTPN_BLL ctpn = new CTPN_BLL();
        SanPham_BLL sp = new SanPham_BLL();
        NhanVien_BLL nv = new NhanVien_BLL();
        NhaCungCap_BLL ncc = new NhaCungCap_BLL();

        public static string maPN;
        public frmNhapHang()
        {
            InitializeComponent();
        }
        string tenNV, maNV;

        private void chkMaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaTuDong.Checked == true)
            {
                int coso = int.Parse(pn.getMaTuDong().ToString());
                coso++;
                if (coso == 0)
                {
                    coso = 1;
                }
                if (coso < 10)
                    txtMaPN.Text = "PN00" + coso.ToString();
                else if (coso < 100)
                    txtMaPN.Text = "PN0" + coso.ToString();
                else
                    txtMaPN.Text = "PN" + coso.ToString();
                txtMaPN.Enabled = false;
            }
            else
            {
                txtMaPN.Clear();
                txtMaPN.Enabled = true;

            }
        }

        private void load_CBSanPham()
        {
            cbMaSP.DataSource = sp.getData();
            cbMaSP.ValueMember = sp.getData().Columns[0].ToString();
            cbMaSP.SelectedIndex = -1;
        }

        private void load_CBNhaCungCap()
        {
            cbNhaCungCap.DataSource = ncc.getData();
            cbNhaCungCap.ValueMember = ncc.getData().Columns[0].ToString();
            cbNhaCungCap.DisplayMember = ncc.getData().Columns[1].ToString();
            //cbNhaCungCap.SelectedIndex = -1;
        }

        private void load_CBMaPN()
        {
            cbMaPN.DataSource = pn.getData();
            cbMaPN.ValueMember = pn.getData().Columns[0].ToString();
            cbMaPN.SelectedIndex = -1;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            foreach (DataRow dr in nv.getDataNhanVienBySDT(frmDangNhap.tendn).Rows)
            {
                maNV = (dr["MaNhanVien"].ToString());
                tenNV = (dr["TenNhanVien"].ToString());
            }
            txtNhanVien.Text = tenNV;
            dtpNgayNhap.Value = DateTime.Now;
            load_CBSanPham();
            load_CBNhaCungCap();
            load_CBMaPN();
            //cbMaPN.SelectedIndex = -1;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnNhapHang.Enabled = false;
            btnThemSoLuong.Enabled = false;
        }

        private void cbMaSP_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbMaSP.SelectedIndex == -1)
            {
                txtTenSP.Clear();
                txtDonGia.Clear();
                txtSLT.Clear();
                picHinh.ImageLocation = string.Format(@"img\noimage.jpg");
            }
            else
            {
                foreach (DataRow dr in sp.getDataByMaSP(cbMaSP.SelectedValue.ToString()).Rows)
                {
                    txtTenSP.Text = (dr["TenSanPham"].ToString());
                    txtDonGia.Text = (dr["GiaNhap"].ToString());
                    txtSLT.Text = (dr["SoLuongTon"].ToString());
                    picHinh.ImageLocation = string.Format(@"img\{0}", (dr["HinhAnh"].ToString()));
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cbMaPN.SelectedIndex = -1;
            lbSoLuong.Text = 0 + " sản phẩm";
            lbTongTien.Text = 0 + " VNĐ";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbMaPN.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã phiếu nhập để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaPN.Focus();
                return;
            }
            else
            {
                dgvCTPN.DataSource = ctpn.getDataCTPN(cbMaPN.SelectedValue.ToString());
                int tong = 0;
                int tongThanhTien = 0;
                foreach (DataRow dr in ctpn.getDataCTPN(cbMaPN.SelectedValue.ToString()).Rows)
                {
                    tong += int.Parse(dr["SoLuongNhap"].ToString());
                    tongThanhTien += int.Parse(dr["ThanhTienNhap"].ToString());
                }
                lbSoLuong.Text = tong.ToString() + " sản phẩm";
                lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnNhapHang.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnNhapHang.Enabled = false;
            txtMaPN.Clear();
            txtSoLuong.Clear();
            txtMaPN.Focus();
            txtMaPN.Enabled = true;
            chkMaTuDong.Checked = false;
            cbMaSP.SelectedIndex = -1;
            cbNhaCungCap.SelectedIndex = -1;
            cbMaPN.SelectedIndex = -1;
            load_CBSanPham();
            load_CBNhaCungCap();
            load_CBMaPN();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int tongThanhTien = 0;
            int tong = 0;
            maPN = txtMaPN.Text.Trim();
            string masanpham = dgvCTPN.CurrentRow.Cells[1].Value.ToString();
            int slsp = 0;
            int sltronggio = 0;
            foreach (DataRow dr in ctpn.getCTPN(maPN, masanpham).Rows)
            {
                sltronggio = int.Parse(dr["SoLuongNhap"].ToString());
            }
            foreach (DataRow dr in sp.getDataByMaSP(masanpham).Rows)
            {
                slsp = int.Parse(dr["SoLuongTon"].ToString());
            }
            int soluonghoantra = slsp - sltronggio;

            txtSLT.Text = soluonghoantra.ToString();

            sp.updateSLT(soluonghoantra, masanpham);

            ctpn.xoaCTPN(maPN, masanpham);

            foreach (DataRow dr in ctpn.getDataCTPN(maPN).Rows)
            {
                tong += int.Parse(dr["SoLuongNhap"].ToString());
                tongThanhTien += int.Parse(dr["ThanhTienNhap"].ToString());
            }
            lbSoLuong.Text = tong.ToString() + " sản phẩm";
            lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

            dgvCTPN.DataSource = ctpn.getDataCTPN(maPN);

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnNhapHang.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPN.Text == "" || cbMaSP.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                    btnNhapHang.Enabled = true;
                    int soluong = int.Parse(txtSoLuong.Text);
                    int tong = 0;
                    int tongThanhTien = 0;
                    maPN = txtMaPN.Text;
                    string maSP = cbMaSP.SelectedValue.ToString().Trim();
                    string maNCC =cbNhaCungCap.SelectedValue.ToString().Trim();
                    string tensanpham = txtTenSP.Text.Trim();

                    float dongia = float.Parse(txtDonGia.Text.Trim());

                    DateTime ngayLap = DateTime.Now;

                    float thanhtien = dongia * soluong;


                    if (ctpn.KTKC(maPN, maSP) == false)
                    {
                        MessageBox.Show("Sản phẩm đã có trong giỏ hàng của bạn");
                        return;
                    }

                    if (ctpn.KTmaPN(maPN) > 0)
                    {
                        int slt1 = 0;
                        foreach (DataRow dr in sp.getDataByMaSP(maSP).Rows)
                        {
                            slt1 = int.Parse(dr["SoLuongTon"].ToString());
                        }

                        ctpn.themCTPN(maPN, maSP, soluong, dongia, thanhtien);

                        foreach (DataRow dr in ctpn.getDataCTPN(maPN).Rows)
                        {
                            tong += int.Parse(dr["SoLuongNhap"].ToString());
                            tongThanhTien += int.Parse(dr["ThanhTienNhap"].ToString());
                        }

                        lbSoLuong.Text = tong.ToString() + " sản phẩm";
                        
                        int soluongTang2 = slt1 + soluong;

                        txtSLT.Text = soluongTang2.ToString();

                        sp.updateSLT(soluongTang2, maSP);


                        lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

                        dgvCTPN.DataSource = ctpn.getDataCTPN(maPN);
                        return;
                    }
                    int slt = 0;
                    foreach (DataRow dr in sp.getDataByMaSP(cbMaSP.SelectedValue.ToString()).Rows)
                    {
                        slt = int.Parse(dr["SoLuongTon"].ToString());
                    }


                    pn.themPN(maPN, maNV, maNCC, ngayLap, 0, "");

                    ctpn.themCTPN(maPN, maSP, soluong, dongia, thanhtien);

                    foreach (DataRow dr in ctpn.getDataCTPN(maPN).Rows)
                    {
                        tong += int.Parse(dr["SoLuongNhap"].ToString());
                        tongThanhTien += int.Parse(dr["ThanhTienNhap"].ToString());
                    }
                    lbSoLuong.Text = tong.ToString() + " sản phẩm";
                    lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";
                    int soluongTang1 = slt + soluong;

                    txtSLT.Text = soluongTang1.ToString();

                    sp.updateSLT(soluongTang1, maSP);

                    dgvCTPN.DataSource = ctpn.getDataCTPN(maPN);

                    
                }
                btnThemSoLuong.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void dgvCTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaPN.Text = dgvCTPN.Rows[index].Cells[0].Value.ToString().Trim();
            cbMaSP.SelectedValue = dgvCTPN.Rows[index].Cells[1].Value.ToString().Trim();
            txtSoLuong.Text = dgvCTPN.Rows[index].Cells[2].Value.ToString().Trim();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            int tongThanhTien = 0;
            maPN = txtMaPN.Text.Trim();
            foreach (DataRow dr in ctpn.getDataCTPN(maPN).Rows)
            {
                tongThanhTien += int.Parse(dr["ThanhTienNhap"].ToString());
            }

            pn.updateThanhTien(tongThanhTien, maPN);

            frmInPhieuNhap frm = new frmInPhieuNhap();
            frm.ShowDialog();

            string mahoadon1 = "";
            dgvCTPN.DataSource = ctpn.getDataCTPN(mahoadon1);
            txtMaPN.Text = "";
            cbMaSP.SelectedIndex = -1;
            cbMaPN.SelectedIndex = -1;
            txtTenSP.Text = "";
            txtSLT.Text = "";
            txtDonGia.Text = "";
            lbTongTien.Text = "0 VNĐ";
            lbSoLuong.Text = "0 sản phẩm";
            txtSoLuong.Text = "";

            txtMaPN.Enabled = true;
            chkMaTuDong.Checked = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnNhapHang.Enabled = false;
            btnThemSoLuong.Enabled = false;
        }

        private void btnThemSoLuong_Click(object sender, EventArgs e)
        {
            try
            {
                int tong = 0;
                string maSP = cbMaSP.SelectedValue.ToString().Trim();
                maPN = txtMaPN.Text.Trim();
                int sl = int.Parse(txtSoLuong.Text.Trim());
                int dongia = 0;
                int tongThanhTien = 0;
                int soluong = 0;
                foreach (DataRow dr in sp.getDataByMaSP(maSP).Rows)
                {
                    dongia = int.Parse(dr["GiaNhap"].ToString());
                    soluong = int.Parse(dr["SoLuongTon"].ToString());
                }



                int slthem = int.Parse(txtSoLuongThem.Text);
                if (slthem > 0)
                    slthem = sl + int.Parse(txtSoLuongThem.Text);
                else
                    MessageBox.Show("Vui lòng nhập số lượng thêm");

                int soluongsauupdate = slthem + (soluong - sl);
                int thanhtien = dongia * slthem;
                ctpn.suaCTPN(slthem, dongia, thanhtien, maPN, maSP);
                txtSLT.Text = soluongsauupdate.ToString();
                sp.updateSLT(soluongsauupdate, maSP);
                foreach (DataRow dr in ctpn.getDataCTPN(maPN).Rows)
                {
                    tong += int.Parse(dr["SoLuongNhap"].ToString());
                    tongThanhTien += int.Parse(dr["ThanhTienNhap"].ToString());
                }

                lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";
                lbSoLuong.Text = tong.ToString() + " sản phẩm";
                dgvCTPN.DataSource = ctpn.getDataCTPN(maPN);
            }
            catch 
            {
            }

           
        }



    }
}
