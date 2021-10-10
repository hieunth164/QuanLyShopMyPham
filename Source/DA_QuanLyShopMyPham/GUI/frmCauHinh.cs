using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCauHinh : Form
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }

        Connection CauHinh = new Connection();

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cbServerName.Text, txtUsername.Text, txtPassword.Text, cbDatabase.Text);
            this.Close();
        }

        private void cbServerName_DropDown(object sender, EventArgs e)
        {
            cbServerName.DataSource = CauHinh.GetServerName();
            cbServerName.DisplayMember = "ServerName";
        }

        private void cbDatabase_DropDown(object sender, EventArgs e)
        {
            checkTextBox();
            cbDatabase.DataSource = CauHinh.GetDBName(cbServerName.Text, txtUsername.Text, txtPassword.Text);
            cbDatabase.DisplayMember = "name";
        }

        public void checkTextBox()
        {
            if (string.IsNullOrEmpty(cbServerName.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập " + gunaLabel1.Text.ToLower());
                this.cbServerName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập " + gunaLabel3.Text.ToLower());
                this.txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập " + gunaLabel5.Text.ToLower());
                this.txtPassword.Focus();
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCauHinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmLogin.Show();
        }

    }
}
