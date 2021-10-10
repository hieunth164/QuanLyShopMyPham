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
    public partial class frmNhaCungCap : Form
    {
        NhaCungCap_BLL ncc = new NhaCungCap_BLL();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void txtSoDienThoai_Leave(object sender, EventArgs e)
        {
            if (txtSoDienThoai.Text.Trim().Length < 10 || txtSoDienThoai.Text.Trim().Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
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

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            load_DGVNhaCungCap();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void load_DGVNhaCungCap()
        {
            dgvNhaCungCap.DataSource = ncc.getData();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaNhaCungCap.Text = dgvNhaCungCap.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenNhaCungCap.Text = dgvNhaCungCap.Rows[index].Cells[1].Value.ToString().Trim();
            txtSoDienThoai.Text = dgvNhaCungCap.Rows[index].Cells[2].Value.ToString().Trim();
            txtDiaChi.Text = dgvNhaCungCap.Rows[index].Cells[3].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                dgvNhaCungCap.DataSource = ncc.timKiemNCCTheoTen(txtTimKiem.Text);

            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm!", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                load_DGVNhaCungCap();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            load_DGVNhaCungCap();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNhaCungCap.Clear();
            txtTenNhaCungCap.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();
            txtMaNhaCungCap.Focus();
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            load_DGVNhaCungCap();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa nhà cung cấp", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                ncc.deleteNCC(dgvNhaCungCap.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVNhaCungCap();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (ncc.KTKC(txtMaNhaCungCap.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin nhà cung cấp", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (ncc.updateNCC(txtTenNhaCungCap.Text, txtSoDienThoai.Text, txtDiaChi.Text, txtMaNhaCungCap.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVNhaCungCap();
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
                    MessageBox.Show("Mã nhà cung cấp không tồn tại!");
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
                if (txtMaNhaCungCap.Text == "" || txtTenNhaCungCap.Text == "" || txtSoDienThoai.Text == "" || txtDiaChi.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (ncc.KTKC(txtMaNhaCungCap.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin nhà cung cấp", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (ncc.insertNCC(txtMaNhaCungCap.Text, txtTenNhaCungCap.Text, txtSoDienThoai.Text, txtDiaChi.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVNhaCungCap();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà cung cấp bị trùng!");
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
