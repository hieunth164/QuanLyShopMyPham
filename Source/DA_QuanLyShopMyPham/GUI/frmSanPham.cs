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
using System.IO;

namespace GUI
{
    public partial class frmSanPham : Form
    {
        SanPham_BLL sp = new SanPham_BLL();
        ThuongHieu_BLL th = new ThuongHieu_BLL();
        LoaiSanPham_BLL lsp = new LoaiSanPham_BLL();
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            load_CBLoaiNV();
            load_CBThuongHieu();
            load_DGVSanPham();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void load_DGVSanPham()
        {
            dgvSP.DataSource = sp.getData();
        }
        private void load_CBLoaiNV()
        {
            cbLoaiSP.DataSource = lsp.getData();
            cbLoaiSP.DisplayMember = lsp.getData().Columns[1].ToString();
            cbLoaiSP.ValueMember = lsp.getData().Columns[0].ToString();
        }

        private void load_CBThuongHieu()
        {
            cbThuongHieu.DataSource = th.getData();
            cbThuongHieu.DisplayMember = th.getData().Columns[1].ToString();
            cbThuongHieu.ValueMember = th.getData().Columns[0].ToString();
        }

        private void txtDonGiaBan_Leave(object sender, EventArgs e)
        {
            if (txtDonGiaBan.Text.Trim().Length < 0)
            {
                MessageBox.Show("Đơn giá bán phải lớn hơn 0");
            }
        }

        private void txtDonGiaNhap_Leave(object sender, EventArgs e)
        {
            if (txtDonGiaNhap.Text.Trim().Length < 0)
            {
                MessageBox.Show("Đơn giá nhập phải lớn hơn 0");
            }
        }

        private void txtSoLuongTon_Leave(object sender, EventArgs e)
        {
            if (txtSoLuongTon.Text.Trim().Length < 0)
            {
                MessageBox.Show("Số lượng tồn phải lớn hơn 0");
            }
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaSP.Text = dgvSP.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenSP.Text = dgvSP.Rows[index].Cells[1].Value.ToString().Trim();
            txtDonGiaBan.Text = dgvSP.Rows[index].Cells[2].Value.ToString().Trim();
            txtDonGiaNhap.Text = dgvSP.Rows[index].Cells[3].Value.ToString().Trim();
            txtGiamGia.Text = dgvSP.Rows[index].Cells[4].Value.ToString().Trim();
            txtMoTa.Text = dgvSP.Rows[index].Cells[5].Value.ToString().Trim();
            cbLoaiSP.SelectedValue = dgvSP.Rows[index].Cells[6].Value;
            cbThuongHieu.SelectedValue = dgvSP.Rows[index].Cells[7].Value.ToString();
            txtDVT.Text = dgvSP.Rows[index].Cells[8].Value.ToString().Trim();
            txtSoLuongTon.Text = dgvSP.Rows[index].Cells[9].Value.ToString().Trim();
            txtHinhAnh.Text = dgvSP.Rows[index].Cells[10].Value.ToString().Trim();
            try
            {
                if (txtHinhAnh.Text != " " && txtHinhAnh.Text != "" && txtHinhAnh.Text != null)
                {
                    picHinh.ImageLocation = string.Format(@"img\{0}", dgvSP.Rows[index].Cells[10].Value.ToString().Trim());
                }
                else
                {
                    picHinh.ImageLocation = string.Format(@"img\noimage.jpg");
                }

            }
            catch
            {
                picHinh.ImageLocation = string.Format(@"img\noimage.jpg");
            }
            txtHinhAnhCT.Text = dgvSP.Rows[index].Cells[11].Value.ToString().Trim();
            try
            {
                if (txtHinhAnhCT.Text != " " && txtHinhAnhCT.Text != "" && txtHinhAnhCT.Text != null)
                {
                    picHinhCT.ImageLocation = string.Format(@"img\{0}", dgvSP.Rows[index].Cells[11].Value.ToString().Trim());
                }
                else
                {
                    picHinhCT.ImageLocation = string.Format(@"img\noimage.jpg");
                }

            }
            catch
            {
                picHinhCT.ImageLocation = string.Format(@"img\noimage.jpg");
            }

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "" || cbTimKiem.Text != "")
            {
                try
                {
                    if (cbTimKiem.SelectedItem.ToString() == "Tên Sản Phẩm")
                    {
                        dgvSP.DataSource = sp.timKiemSPTheoTen(txtTimKiem.Text);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi chưa tìm kiếm được! Vui lòng thử lại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                load_DGVSanPham();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGiaBan.Clear();
            txtDonGiaNhap.Clear();
            txtMoTa.Clear();
            txtDVT.Clear();
            txtSoLuongTon.Clear();
            txtHinhAnh.Clear();
            txtHinhAnhCT.Clear();
            txtMaSP.Focus();
            txtTimKiem.Clear();
            picHinh.ImageLocation = string.Format(@"img\noimage.jpg");
            picHinhCT.ImageLocation = string.Format(@"img\noimage.jpg");

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVSanPham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa sản phẩm", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                sp.deleteSP(dgvSP.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVSanPham();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (sp.KTKC(txtMaSP.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin sản phẩm", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (sp.updateSP(txtTenSP.Text, float.Parse(txtDonGiaBan.Text), float.Parse(txtDonGiaNhap.Text), float.Parse(txtGiamGia.Text), txtMoTa.Text, cbLoaiSP.SelectedValue.ToString(), cbThuongHieu.SelectedValue.ToString(), txtDVT.Text, int.Parse(txtSoLuongTon.Text),
                            txtHinhAnh.Text, txtHinhAnhCT.Text, txtMaSP.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVSanPham();
                            btnLuu.Enabled = false;
                            btnXoa.Enabled = false;
                            btnSua.Enabled = false;
                        }
                        else
                            MessageBox.Show("Thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSP.Text == "" || txtTenSP.Text == "" || txtDonGiaNhap.Text == "" || txtDonGiaBan.Text == "" || txtGiamGia.Text == ""
                    || txtSoLuongTon.Text == "" || txtDVT.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (sp.KTKC(txtMaSP.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin sản phẩm", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (sp.insertSP(txtMaSP.Text, txtTenSP.Text, float.Parse(txtDonGiaBan.Text), float.Parse(txtDonGiaNhap.Text), float.Parse(txtGiamGia.Text), txtMoTa.Text, cbLoaiSP.SelectedValue.ToString(), cbThuongHieu.SelectedValue.ToString(), txtDVT.Text, int.Parse(txtSoLuongTon.Text),
                            txtHinhAnh.Text, txtHinhAnhCT.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVSanPham();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã sản phẩm bị trùng!");
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void chkMaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaTuDong.Checked == true)
            {
                int coso = int.Parse(sp.getMaTuDong().ToString());
                coso++;
                if (coso < 10)
                    txtMaSP.Text = "MH00" + coso.ToString();
                else if (coso < 100)
                    txtMaSP.Text = "MH0" + coso.ToString();
                else
                    txtMaSP.Text = "MH" + coso.ToString();
                txtMaSP.Enabled = false;
            }
            else
            {
                txtMaSP.Clear();
                txtMaSP.Enabled = true;

            }
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image File (*.jpg)|*.jpg|All File (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string name = System.IO.Path.GetFileName(open.FileName);
                string luu = string.Format(@"img\" + name);
                try
                {
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    System.IO.File.Copy(open.FileName, luu);

                    MessageBox.Show("Upload file ảnh thành công", "Thông báo");
                    txtHinhAnh.Text = name;
                    //picHinh.Image = Image.FromFile(luu);
                    picHinh.Image = System.Drawing.Image.FromStream(fs);
                    //  picHinh.ImageLocation = open.FileName;
                    fs.Close();

                }
                catch
                {
                    MessageBox.Show("Hình ảnh đã tồn tại hoặc trùng tên, vui lòng kiểm tra lại");
                }
            }
        }


        private void btnHinhAnhCT_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image File (*.jpg)|*.jpg|All File (*.*)|*.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string name = System.IO.Path.GetFileName(open.FileName);
                string luu = string.Format(@"img\" + name);
                try
                {
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    System.IO.File.Copy(open.FileName, luu);

                    MessageBox.Show("Upload file ảnh thành công", "Thông báo");
                    txtHinhAnhCT.Text = name;
                    //picHinh.Image = Image.FromFile(luu);
                    picHinhCT.Image = System.Drawing.Image.FromStream(fs);
                    //  picHinh.ImageLocation = open.FileName;
                    fs.Close();

                }
                catch
                {
                    MessageBox.Show("Hình ảnh đã tồn tại hoặc trùng tên, vui lòng kiểm tra lại");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            load_DGVSanPham();
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }

        private void txtGiamGia_Leave(object sender, EventArgs e)
        {
            if (txtGiamGia.Text.Trim().Length < 0)
            {
                MessageBox.Show("Đơn giá nhập phải lớn hơn 0");
            }
        }
    }
}
