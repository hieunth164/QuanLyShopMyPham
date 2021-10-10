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
    public partial class frmBanHang : Form
    {
        HoaDon_BLL hd = new HoaDon_BLL();
        CTHD_BLL cthd = new CTHD_BLL();
        SanPham_BLL sp = new SanPham_BLL();
        NhanVien_BLL nv = new NhanVien_BLL();
        KhachHang_BLL kh = new KhachHang_BLL();
        string maKH = "";
        string tenKH = "";
        public static string maHD;
        public frmBanHang()
        {
            InitializeComponent();
        }
        string tenNV, maNV;

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            foreach (DataRow dr in nv.getDataNhanVienBySDT(frmDangNhap.tendn).Rows)
            {
                maNV = (dr["MaNhanVien"].ToString());
                tenNV = (dr["TenNhanVien"].ToString());
            }
            txtNhanVien.Text = tenNV;
            dtpNgayLap.Value = DateTime.Now;
            load_CBSanPham();
            load_CBKhachHang();
            load_CBMaHD();
            //cbMaHD.SelectedIndex = -1;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        private void chkMaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaTuDong.Checked == true)
            {
                int coso = int.Parse(hd.getMaTuDong().ToString());
                coso++;
                if (coso == 0)
                {
                    coso = 1;
                }
                if (coso < 10)
                    txtMaHD.Text = "HD00" + coso.ToString();
                else if (coso < 100)
                    txtMaHD.Text = "HD0" + coso.ToString();
                else
                    txtMaHD.Text = "HD" + coso.ToString();
                txtMaHD.Enabled = false;
            }
            else
            {
                txtMaHD.Clear();
                txtMaHD.Enabled = true;

            }
        }

        private void load_CBSanPham()
        {
            cbMaSP.DataSource = sp.getData();
            cbMaSP.ValueMember = sp.getData().Columns[0].ToString();
            cbMaSP.SelectedIndex = -1;
        }
        private void load_CBMaHD()
        {
            cbMaHD.DataSource = hd.getData();
            cbMaHD.ValueMember = hd.getData().Columns[0].ToString();
            cbMaHD.SelectedIndex = -1;
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
                    txtDonGia.Text = (dr["GiamGia"].ToString());
                    txtSLT.Text = (dr["SoLuongTon"].ToString());
                    picHinh.ImageLocation = string.Format(@"img\{0}", (dr["HinhAnh"].ToString()));
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cbMaHD.SelectedIndex = -1;
            lbSoLuong.Text = 0 + " sản phẩm";
            lbTongTien.Text = 0 + " VNĐ";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbMaHD.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaHD.Focus();
                return;
            }
            else
            {
                dgvCTHD.DataSource = cthd.getDataCTHD(cbMaHD.SelectedValue.ToString());
                int tong = 0;
                int tongThanhTien = 0;
                foreach (DataRow dr in cthd.getDataCTHD(cbMaHD.SelectedValue.ToString()).Rows)
                {
                    tong += int.Parse(dr["SoLuongBan"].ToString());
                    tongThanhTien += int.Parse(dr["ThanhTienBan"].ToString());
                }
                lbSoLuong.Text = tong.ToString() + " sản phẩm";
                lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnThanhToan.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnThanhToan.Enabled = false;
            txtMaHD.Clear();
            txtMaHD.Focus();
            txtMaHD.Enabled = true;
            chkMaTuDong.Checked = false;
            cbMaSP.SelectedIndex = -1;
            cbKhachHang.SelectedIndex = -1;
            cbMaHD.SelectedIndex = -1;
            load_CBSanPham();
            load_CBKhachHang();
            load_CBMaHD();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int tongThanhTien = 0;
            int tong = 0;
            maHD = txtMaHD.Text.Trim();
            string masanpham = dgvCTHD.CurrentRow.Cells[1].Value.ToString();
            int slsp = 0;
            int sltronggio = 0;
            foreach (DataRow dr in cthd.getCTHD(maHD, masanpham).Rows)
            {
                sltronggio = int.Parse(dr["SoLuongBan"].ToString());
            }
            foreach (DataRow dr in sp.getDataByMaSP(masanpham).Rows)
            {
                slsp = int.Parse(dr["SoLuongTon"].ToString());
            }
            int soluonghoantra = slsp + sltronggio;

            txtSLT.Text = soluonghoantra.ToString();

            sp.updateSLT(soluonghoantra, masanpham);

            cthd.xoaCTHD(maHD, masanpham);

            foreach (DataRow dr in cthd.getDataCTHD(maHD).Rows)
            {
                tong += int.Parse(dr["SoLuongBan"].ToString());
                tongThanhTien += int.Parse(dr["ThanhTienBan"].ToString());
            }
            lbSoLuong.Text = tong.ToString() + " sản phẩm";
            lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

            dgvCTHD.DataSource = cthd.getDataCTHD(maHD);

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHD.Text == "" || cbMaSP.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThanhToan.Enabled = true;
                    int soluongtrukhimua = 1;
                    int soluong = 1;
                    int tong = 0;
                    int tongThanhTien = 0;
                    maHD = txtMaHD.Text;
                    string maSP = cbMaSP.SelectedValue.ToString().Trim();
                    string tensanpham = txtTenSP.Text.Trim();

                    float dongia = float.Parse(txtDonGia.Text.Trim());

                    if (chkKhachHang.Checked == true)
                    {
                        maKH = cbKhachHang.SelectedValue.ToString().Trim();
                        foreach (DataRow dr in kh.getKhachHangMaKH(maKH).Rows)
                        {
                            tenKH = dr["TenKhachHang"].ToString();
                        }
                    }
                    else
                    {
                        if (txtKhachHang.Text == "")
                        {
                            MessageBox.Show("Không được để trống");
                            return;
                        }
                        else
                        {
                            tenKH = txtKhachHang.Text.Trim();
                            kh.themKH(tenKH);
                        }

                    }

                    DateTime ngayLap = DateTime.Now;

                    float thanhtien = dongia * soluong;
                    if (cthd.KTKC(maHD, maSP) == false)
                    {
                        MessageBox.Show("Sản phẩm đã có trong giỏ hàng của bạn");
                        return;
                    }

                    if (cthd.KTMaHD(maHD) > 0)
                    {
                        int slt1 = 0;
                        foreach (DataRow dr in sp.getDataByMaSP(maSP).Rows)
                        {
                            slt1 = int.Parse(dr["SoLuongTon"].ToString());
                        }
                        if (slt1 == 0)
                        {
                            MessageBox.Show("Sản phẩm đã hết");
                            return;
                        }

                        cthd.themCTHD(maHD, maSP, soluong, dongia, thanhtien);

                        foreach (DataRow dr in cthd.getDataCTHD(maHD).Rows)
                        {
                            tong += int.Parse(dr["SoLuongBan"].ToString());
                            tongThanhTien += int.Parse(dr["ThanhTienBan"].ToString());
                        }

                        lbSoLuong.Text = tong.ToString() + " sản phẩm";



                        int tru1khiclickthem1 = slt1 - soluongtrukhimua;

                        txtSLT.Text = tru1khiclickthem1.ToString();

                        sp.updateSLT(tru1khiclickthem1, maSP);


                        lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

                        dgvCTHD.DataSource = cthd.getDataCTHD(maHD);
                        return;
                    }
                    int slt = 0;
                    foreach (DataRow dr in sp.getDataByMaSP(cbMaSP.SelectedValue.ToString()).Rows)
                    {
                        slt = int.Parse(dr["SoLuongTon"].ToString());
                    }
                    if (slt == 0)
                    {
                        MessageBox.Show("Sản phẩm đã hết");
                        return;
                    }


                    foreach (DataRow dr in kh.getKhachHangTenKH(tenKH).Rows)
                    {
                        maKH = dr["MaKhachHang"].ToString();
                    }

                    hd.themHD(maHD, maNV, maKH, ngayLap, 0, "");

                    cthd.themCTHD(maHD, maSP, soluong, dongia, thanhtien);

                    foreach (DataRow dr in cthd.getDataCTHD(maHD).Rows)
                    {
                        tong += int.Parse(dr["SoLuongBan"].ToString());
                        tongThanhTien += int.Parse(dr["ThanhTienBan"].ToString());
                    }
                    lbSoLuong.Text = tong.ToString() + " sản phẩm";
                    lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";
                    int tru1khiclickthem = slt - soluongtrukhimua;

                    txtSLT.Text = tru1khiclickthem.ToString();

                    sp.updateSLT(tru1khiclickthem, maSP);
                    dgvCTHD.DataSource = cthd.getDataCTHD(maHD);

                    load_CBKhachHang();

                }

            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void chkKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhachHang.Checked == true)
            {
                cbKhachHang.Visible = true;
                txtKhachHang.Visible = false;
                //LoadcbKH();
            }
            else
            {
                cbKhachHang.Visible = false;
                txtKhachHang.Visible = true;
            }
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            cbMaSP.SelectedValue = dgvCTHD.Rows[index].Cells[1].Value.ToString().Trim();
            txtMaHD.Text = dgvCTHD.Rows[index].Cells[0].Value.ToString().Trim();
        }

        private void btnThemSoLuong_Click(object sender, EventArgs e)
        {
            try
            {
                int tong = 0;
                int slsp = 0;
                string maSP = cbMaSP.SelectedValue.ToString().Trim();
                maHD = txtMaHD.Text.Trim();
                int slthem = int.Parse(txtSoLuong.Text);
                int dongia = 0;
                int tongThanhTien = 0;
                foreach (DataRow dr in sp.getDataByMaSP(maSP).Rows)
                {
                    dongia = int.Parse(dr["GiamGia"].ToString());
                    slsp = int.Parse(dr["SoLuongTon"].ToString());
                }
                int sltronggio = 0;
                foreach (DataRow dr in cthd.getCTHD(maHD, maSP).Rows)
                {
                    sltronggio = int.Parse(dr["SoLuongBan"].ToString());
                }
                int soluonghoantra = slsp + sltronggio;
                sp.updateSLT(soluonghoantra, maSP);
                int slsp2 = 0;
                foreach (DataRow dr in sp.getDataByMaSP(maSP).Rows)
                {
                    slsp2 = int.Parse(dr["SoLuongTon"].ToString());
                }
                int slupdate = slsp2 - slthem;

                if (slupdate < 0)
                {

                    MessageBox.Show("Số lượng trong kho không đủ");
                    sp.updateSLT(slsp, maSP);

                    return;
                }
                txtSLT.Text = slupdate.ToString();
                sp.updateSLT(slupdate, maSP);

                int sl = slthem + sltronggio;

                int thanhtien = dongia * sl;

                cthd.suaCTHD(sl, dongia, thanhtien, maHD, maSP);

                foreach (DataRow dr in cthd.getDataCTHD(maHD).Rows)
                {
                    tong += int.Parse(dr["SoLuongBan"].ToString());
                    tongThanhTien += int.Parse(dr["ThanhTienBan"].ToString());
                }
                lbSoLuong.Text = tong.ToString() + " sản phẩm";
                lbTongTien.Text = tongThanhTien.ToString("0,00.##") + " VNĐ";

                dgvCTHD.DataSource = cthd.getDataCTHD(maHD);
            }
            catch
            {
            }
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int tongThanhTien = 0;
            maHD = txtMaHD.Text.Trim();
            foreach (DataRow dr in cthd.getDataCTHD(maHD).Rows)
            {
                tongThanhTien += int.Parse(dr["ThanhTienBan"].ToString());
            }

            hd.updateThanhTien(tongThanhTien, maHD);

            frmInHoaDon frm = new frmInHoaDon();
            frm.ShowDialog();

            string mahoadon1 = "";
            dgvCTHD.DataSource = cthd.getDataCTHD(mahoadon1);
            txtMaHD.Text = "";
            txtKhachHang.Text = "";
            cbMaSP.SelectedIndex = -1;
            cbMaHD.SelectedIndex = -1;
            txtTenSP.Text = "";
            txtSLT.Text = "";
            txtDonGia.Text = "";
            lbTongTien.Text = "0 VNĐ";
            lbSoLuong.Text = "0 sản phẩm";
            txtSoLuong.Text = "";
        }
        

        private void load_CBKhachHang()
        {
            cbKhachHang.DataSource = kh.getData();
            cbKhachHang.ValueMember = kh.getData().Columns[0].ToString();
            cbKhachHang.DisplayMember = kh.getData().Columns[1].ToString();
            //cbKhachHang.SelectedIndex = -1;
        }
    }
}
