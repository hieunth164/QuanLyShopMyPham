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
    public partial class frmPhanQuyen : Form
    {
        PhanQuyen_BLL pq = new PhanQuyen_BLL();
        LoaiNhanVien_BLL lnv = new LoaiNhanVien_BLL();
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            load_DGVLoaiNhanVien();
        }

        private void load_DGVLoaiNhanVien()
        {
            dgvNhomNguoiDung.DataSource = lnv.getDataLoaiNV();
        }

        private void load_DGVPhanQuyen()
        {
            dgvPhanQuyen.DataSource = pq.getData(dgvNhomNguoiDung.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvNhomNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_DGVPhanQuyen();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maLNV = dgvNhomNguoiDung.CurrentRow.Cells[0].Value.ToString();
            int flag = 0;
            foreach (DataGridViewRow item in dgvPhanQuyen.Rows)
            {
                if (pq.KTKC(maLNV,item.Cells[0].Value.ToString()))
                {
                    try
                    {
                        if (pq.insertPQ(maLNV,item.Cells[0].Value.ToString(),(bool)(item.Cells[2].Value)))
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                        }
                    }
                    catch
                    {
                        if (pq.insertPQ(maLNV, item.Cells[0].Value.ToString(), false))
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                        }
                    }
                }
                else
                {
                    if (pq.updatePQ((item.Cells[2] == null) ? false : (bool)(item.Cells[2].Value),maLNV, item.Cells[0].Value.ToString()))
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
            }
            if (flag==1)
            {
                MessageBox.Show("Phân quyền thành công!");
            }
            else
            {
                MessageBox.Show("Phân quyền thất bại!");
            }
        }
    }
}
