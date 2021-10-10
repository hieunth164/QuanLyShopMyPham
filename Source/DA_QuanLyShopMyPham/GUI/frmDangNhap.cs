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
    public partial class frmDangNhap : Form
    {
        NhanVien_BLL nv = new NhanVien_BLL();

        public static string tendn;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Type Your Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Type Your Username")
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Type Your Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Type Your Password")
            {
                txtPassword.Clear();
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                int count = nv.getDataDangNhap(txtUsername.Text, txtPassword.Text).Rows.Count;
                
                if (txtUsername.Text == "Type Your Username" && txtPassword.Text == "Type Your Password")
                    MessageBox.Show("Yêu cầu nhập tài khoản và mật khẩu");
                else if (txtUsername.Text == "Type Your Username")
                    MessageBox.Show("Chưa nhập tài khoản");
                else if (txtPassword.Text == "Type Your Password")
                    MessageBox.Show("Chưa nhập mật khẩu");
                else if (count != 0)
                {
                    tendn = txtUsername.Text;
                    MessageBox.Show("Đăng nhập thành công");
                    
                    if (Program.frmMain == null || Program.frmMain.IsDisposed)
                        Program.frmMain = new frmMain();
                    this.Visible = false;
                    Program.frmMain.Show();
                }
                else
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối!!!");
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
