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
    public partial class frmLoaiSanPham : Form
    {
        LoaiSanPham_BLL lsp = new LoaiSanPham_BLL();
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            load_DGVLoaiSP();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void load_DGVLoaiSP()
        {
            dgvLoaiSanPham.DataSource = lsp.getData();
        }

        private void dgvLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaLoaiSP.Text = dgvLoaiSanPham.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenLoaiSP.Text = dgvLoaiSanPham.Rows[index].Cells[1].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaLoaiSP.Clear();
            txtTenLoaiSP.Clear();
            txtMaLoaiSP.Focus();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVLoaiSP();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa loại sản phẩm", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                lsp.deleteLSP(dgvLoaiSanPham.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVLoaiSP();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsp.KTKC(txtMaLoaiSP.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin loại sản phẩm", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (lsp.updateLSP(txtTenLoaiSP.Text, txtMaLoaiSP.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVLoaiSP();
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
                    MessageBox.Show("Mã loại sản phẩm không tồn tại!");
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
                if (txtMaLoaiSP.Text == "" || txtTenLoaiSP.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (lsp.KTKC(txtMaLoaiSP.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin loại sản phẩm", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (lsp.insertLSP(txtMaLoaiSP.Text, txtTenLoaiSP.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVLoaiSP();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã loại sản phẩm bị trùng!");
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
