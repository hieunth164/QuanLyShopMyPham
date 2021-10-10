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
    public partial class frmKhachHang : Form
    {
        KhachHang_BLL kh = new KhachHang_BLL();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load_DGVKhachHang();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtSoDienThoai.Text.Trim().Length < 6 || txtSoDienThoai.Text.Trim().Length > 20)
            {
                MessageBox.Show("Mật khẩu không hợp lệ!");
            }
        }
        private void load_DGVKhachHang()
        {
            dgvKhachHang.DataSource = kh.getData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                dgvKhachHang.DataSource = kh.timKiemKHTheoTen(txtTimKiem.Text);

            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                load_DGVKhachHang();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            load_DGVKhachHang();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaKhachHang.Text = dgvKhachHang.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenKhachHang.Text = dgvKhachHang.Rows[index].Cells[1].Value.ToString().Trim();
            dtpNgaySinh.Text = dgvKhachHang.Rows[index].Cells[2].Value.ToString();
            txtSoDienThoai.Text = dgvKhachHang.Rows[index].Cells[3].Value.ToString().Trim();
            txtDiaChi.Text = dgvKhachHang.Rows[index].Cells[4].Value.ToString().Trim();
            txtEmail.Text = dgvKhachHang.Rows[index].Cells[5].Value.ToString().Trim();
            txtMatKhau.Text = dgvKhachHang.Rows[index].Cells[6].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMatKhau.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();
            txtMaKhachHang.Clear();
            txtEmail.Clear();
            txtMaKhachHang.Focus();
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            load_DGVKhachHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa khách hàng", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                kh.deleteKH(dgvKhachHang.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVKhachHang();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (kh.KTKC(txtMaKhachHang.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin khách hàng", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (kh.updateKH(txtTenKhachHang.Text, dtpNgaySinh.Value.ToString(), txtSoDienThoai.Text, txtDiaChi.Text, txtEmail.Text, txtMatKhau.Text, txtMaKhachHang.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVKhachHang();
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
                    MessageBox.Show("Mã khách hàng không tồn tại!");
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
                if (txtMaKhachHang.Text == "" || txtTenKhachHang.Text == "" || txtSoDienThoai.Text == "" || txtDiaChi.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (kh.KTKC(txtMaKhachHang.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin khách hàng", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (kh.insertKH(txtMaKhachHang.Text, txtTenKhachHang.Text, dtpNgaySinh.Value, txtSoDienThoai.Text, txtDiaChi.Text, txtEmail.Text, txtMatKhau.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVKhachHang();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã khách hàng bị trùng!");
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
