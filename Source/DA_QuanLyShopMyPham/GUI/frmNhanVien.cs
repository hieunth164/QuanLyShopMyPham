using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frmNhanVien : Form
    {
        NhanVien_BLL nv = new NhanVien_BLL();
        LoaiNhanVien_BLL lnv = new LoaiNhanVien_BLL();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            load_CBLoaiNV();
            load_DGVNhanVien();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        public bool ktNgaySinhHopLe()
        {
            if (dtpNgaySinh.Text != "")
            {
                DateTime dateOfBirth = dtpNgaySinh.Value;
                int tuoi = DateTime.Now.Year - dateOfBirth.Year;
                if (tuoi < 18)
                {
                    MessageBox.Show("Tuổi của bạn là: " + tuoi + " bạn chưa đủ tuổi!");
                    return false;
                }
            }
            return true;
        }

        private void load_DGVNhanVien()
        {
            dgvNhanVien.DataSource = nv.getDataNhanVien();
        }
        private void load_CBLoaiNV()
        {
            cbLoaiNV.DataSource = lnv.getDataLoaiNV();
            cbLoaiNV.DisplayMember = lnv.getDataLoaiNV().Columns[1].ToString();
            cbLoaiNV.ValueMember = lnv.getDataLoaiNV().Columns[0].ToString();
        }

        private void chkMaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaTuDong.Checked == true)
            {
                int coso = int.Parse(nv.getMaTuDong().ToString());
                coso++;
                if (coso < 10)
                    txtMaNV.Text = "NV00" + coso.ToString();
                else if (coso < 100)
                    txtMaNV.Text = "NV0" + coso.ToString();
                else
                    txtMaNV.Text = "NV" + coso.ToString();
                txtMaNV.Enabled = false;
            }
            else
            {
                txtMaNV.Clear();
                txtMaNV.Enabled = true;

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtMaNV.Enabled = true;
            chkMaTuDong.Checked = false;
            txtTenNV.Clear();
            txtCMT.Clear();
            txtDiaChi.Clear();
            txtHinhAnh.Clear();
            txtMatKhau.Clear();
            txtSoDienThoai.Clear();
            txtTimKiem.Clear();
            txtMaNV.Focus();
            picHinh.ImageLocation = string.Format(@"img\noimage.jpg");

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa nhân viên", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                nv.deleteNV(dgvNhanVien.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVNhanVien();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (nv.KTKC(txtMaNV.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin nhân viên", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (nv.updateNV(txtTenNV.Text, cbLoaiNV.SelectedValue.ToString(), dtpNgaySinh.Value.ToString(), cbGioiTinh.Text, txtSoDienThoai.Text,
                            txtDiaChi.Text, txtCMT.Text, txtHinhAnh.Text, txtMatKhau.Text, txtMaNV.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVNhanVien();
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
                    MessageBox.Show("Mã nhân viên không tồn tại!");
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
                if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtSoDienThoai.Text == "" || txtDiaChi.Text == ""
                    || txtCMT.Text == "" || txtMatKhau.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                bool kq_tuoi = ktNgaySinhHopLe();
                if (kq_tuoi == false)
                {
                    return;
                }
                else
                {
                    if (nv.KTKC(txtMaNV.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin nhân viên", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (nv.insertNV(txtMaNV.Text, txtTenNV.Text, cbLoaiNV.SelectedValue.ToString(), dtpNgaySinh.Value, cbGioiTinh.Text,
                                txtSoDienThoai.Text, txtDiaChi.Text, txtCMT.Text, txtHinhAnh.Text, txtMatKhau.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVNhanVien();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên bị trùng!");
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "" || cbTimKiem.Text != "")
            {
                try
                {
                    if (cbTimKiem.SelectedItem.ToString() == "Tên Nhân Viên")
                    {
                        dgvNhanVien.DataSource = nv.timKiemNVTheoTen(txtTimKiem.Text);
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
                load_DGVNhanVien();
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }

        private void txtCMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }

        private void txtSoDienThoai_Leave(object sender, EventArgs e)
        {
            if (txtSoDienThoai.Text.Trim().Length < 10 || txtSoDienThoai.Text.Trim().Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
            }
        }

        private void txtCMT_Leave(object sender, EventArgs e)
        {
            if (txtCMT.Text.Trim().Length < 9 || txtCMT.Text.Trim().Length > 15)
            {
                MessageBox.Show("CMT không hợp lệ!");
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim().Length < 6 || txtMatKhau.Text.Trim().Length > 20)
            {
                MessageBox.Show("Mật khẩu chỉ từ 6-20 ký tự!");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaNV.Text = dgvNhanVien.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenNV.Text = dgvNhanVien.Rows[index].Cells[1].Value.ToString().Trim();
            cbLoaiNV.SelectedValue = dgvNhanVien.Rows[index].Cells[2].Value;
            dtpNgaySinh.Text = dgvNhanVien.Rows[index].Cells[3].Value.ToString();
            cbGioiTinh.Text = dgvNhanVien.Rows[index].Cells[4].Value.ToString();
            txtSoDienThoai.Text = dgvNhanVien.Rows[index].Cells[5].Value.ToString().Trim();
            txtDiaChi.Text = dgvNhanVien.Rows[index].Cells[6].Value.ToString().Trim();
            txtCMT.Text = dgvNhanVien.Rows[index].Cells[7].Value.ToString().Trim();
            txtHinhAnh.Text = dgvNhanVien.Rows[index].Cells[8].Value.ToString().Trim();
            try
            {
                if (txtHinhAnh.Text != " " && txtHinhAnh.Text != "" && txtHinhAnh.Text != null)
                {
                    picHinh.ImageLocation = string.Format(@"img\{0}", dgvNhanVien.Rows[index].Cells[8].Value.ToString().Trim());
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
            txtMatKhau.Text = dgvNhanVien.Rows[index].Cells[9].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            load_DGVNhanVien();
        }
    }
}
