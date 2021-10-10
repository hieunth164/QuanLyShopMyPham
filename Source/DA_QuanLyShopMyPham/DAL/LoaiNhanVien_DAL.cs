using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class LoaiNhanVien_DAL
    {
        LoaiNhanVienTableAdapter daLNV = new LoaiNhanVienTableAdapter();

        LoaiNhanVienDKTableAdapter daLNVDK = new LoaiNhanVienDKTableAdapter();

        public LoaiNhanVien_DAL() { }

        public DataTable getDataLoaiNV()
        {
            return daLNV.GetData();
        }

        public bool insertLNV(string maLNV, string tenLNV)
        {
            try
            {
                daLNV.Insert(maLNV, tenLNV);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateLNV(string tenLNV, string maLNV)
        {
            try
            {
                daLNV.UpdateLNV(tenLNV, maLNV);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteLNV(string maLNV)
        {
            try
            {
                daLNV.DeleteLNV(maLNV);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maLNV)
        {
            try
            {
                if (daLNV.KTKC(maLNV) > 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<string> GetMaNhomNguoiDung(string maNND)
        {
            List<string> kqMNND = new List<string>();

            DataTable dtkq = daLNV.GetDataByDSNND(maNND);

            for (int i = 0; i < dtkq.Rows.Count; i++)
            {
                kqMNND.Add(dtkq.Rows[i].ItemArray[0].ToString());
            }

            return kqMNND;
        }

    }
}
