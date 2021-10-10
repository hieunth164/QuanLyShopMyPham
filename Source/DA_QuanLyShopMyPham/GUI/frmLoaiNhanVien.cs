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
    public partial class frmLoaiNhanVien : Form
    {
        LoaiNhanVien_BLL lnv = new LoaiNhanVien_BLL();
        public frmLoaiNhanVien()
        {
            InitializeComponent();
        }

        private void frmLoaiNhanVien_Load(object sender, EventArgs e)
        {
            load_DGVLoaiNhanVien();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void load_DGVLoaiNhanVien()
        {
            dgvLoaiNhanVien.DataSource = lnv.getDataLoaiNV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa loại nhân viên", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                lnv.deleteLNV(dgvLoaiNhanVien.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVLoaiNhanVien();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaLNV.Clear();
            txtTenLNV.Clear();
            txtMaLNV.Focus();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVLoaiNhanVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (lnv.KTKC(txtMaLNV.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin loại nhân viên", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (lnv.updateLNV(txtTenLNV.Text, txtMaLNV.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVLoaiNhanVien();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLNV.Text == "" || txtTenLNV.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (lnv.KTKC(txtMaLNV.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin loại nhân viên", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (lnv.insertLNV(txtMaLNV.Text, txtTenLNV.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVLoaiNhanVien();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã loại nhân viên bị trùng!");
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void dgvLoaiNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaLNV.Text = dgvLoaiNhanVien.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenLNV.Text = dgvLoaiNhanVien.Rows[index].Cells[1].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }
    }
}
