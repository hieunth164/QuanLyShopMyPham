using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class LoaiSanPham_DAL
    {
        LoaiHangTableAdapter daLH = new LoaiHangTableAdapter();

        public LoaiSanPham_DAL() { }

        public DataTable getData()
        {
            return daLH.GetData();
        }

        public bool insertLSP(string maLSP, string tenLSP)
        {
            try
            {
                daLH.Insert(maLSP, tenLSP);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateLSP(string tenLSP, string maLSP)
        {
            try
            {
                daLH.UpdateLoaiSp(tenLSP, maLSP);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteLSP(string maLSP)
        {
            try
            {
                daLH.DeleteLoaiSp(maLSP);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maLSP)
        {
            try
            {
                if (daLH.KTKC(maLSP) > 0)
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
    }
}
