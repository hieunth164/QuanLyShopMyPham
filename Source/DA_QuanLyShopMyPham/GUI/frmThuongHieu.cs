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
    public partial class frmThuongHieu : Form
    {
        ThuongHieu_BLL th = new ThuongHieu_BLL();
        public frmThuongHieu()
        {
            InitializeComponent();
        }

        private void frmThuongHieu_Load(object sender, EventArgs e)
        {
            load_DGVThuongHieu();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void load_DGVThuongHieu()
        {
            dgvThuongHieu.DataSource = th.getData();
        }

        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaThuongHieu.Text = dgvThuongHieu.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenThuongHieu.Text = dgvThuongHieu.Rows[index].Cells[1].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaThuongHieu.Clear();
            txtTenThuongHieu.Clear();
            txtMaThuongHieu.Focus();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVThuongHieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa thương hiệu", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                th.deleteTH(dgvThuongHieu.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVThuongHieu();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaThuongHieu.Text == "" || txtTenThuongHieu.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (th.KTKC(txtMaThuongHieu.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin thương hiệu", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (th.insertTH(txtMaThuongHieu.Text, txtTenThuongHieu.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVThuongHieu();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã thương hiệu bị trùng!");
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (th.KTKC(txtMaThuongHieu.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin thương hiệu", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (th.updateTH(txtTenThuongHieu.Text, txtMaThuongHieu.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVThuongHieu();
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
                    MessageBox.Show("Mã loại nhân viên không tồn tại!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
