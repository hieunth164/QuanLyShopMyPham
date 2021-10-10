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
    public partial class frmDoiMatKhau : Form
    {
        NhanVien_BLL nv = new NhanVien_BLL();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        string matkhau = "";
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDN.Text = frmDangNhap.tendn.ToString();
            foreach (DataRow dr in nv.getDataNhanVienBySDT(frmDangNhap.tendn).Rows)
            {
                matkhau=(dr["MatKhau"].ToString());
            }
        }
        

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMKCu.Text == matkhau)
            {
                if (txtMKMoi.Text.Equals(txtNhapLaiMK.Text) == true)
                {
                    try
                    {
                        nv.updateMK(txtMKMoi.Text, txtTenDN.Text);

                        MessageBox.Show("Đổi mật khẩu thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không chính xác vui lòng nhập lại");
                }

            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác vui lòng nhập lại");
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtMKCu.UseSystemPasswordChar = false;
                txtMKMoi.UseSystemPasswordChar = false;
                txtNhapLaiMK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMKCu.UseSystemPasswordChar = true;
                txtMKMoi.UseSystemPasswordChar = true;
                txtNhapLaiMK.UseSystemPasswordChar = true;
            }
        }
    }
}
