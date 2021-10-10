using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QL_ShopMyPhamTableAdapters;

namespace DAL
{
    public class SanPham_DAL
    {
        SanPhamTableAdapter daSP = new SanPhamTableAdapter();

        public SanPham_DAL() { }

        public DataTable getData()
        {
            return daSP.GetData();
        }

        public DataTable getDataByMaSP(string maSP)
        {
            return daSP.GetDataByMaSP(maSP);
        }

        public int? getMaTuDong()
        {
            return daSP.MaSPTuDongTang();
        }

        public bool insertSP(string maSP, string tenSP, float giaban, float gianhap, float giamgia, string mota, string maloai, string mathuonghieu, string dvt, int slt, string hinhanh, string hinhanhct)
        {
            try
            {
                daSP.Insert(maSP, tenSP, giaban, gianhap,giamgia, mota, maloai, mathuonghieu, dvt, slt, hinhanh, hinhanhct);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateSP(string tenSP, float giaban, float gianhap, float giamgia, string mota, string maloai, string mathuonghieu, string dvt, int slt, string hinhanh, string hinhanhct, string maSP)
        {
            try
            {
                daSP.UpdateSP(tenSP, giaban, gianhap,giamgia, mota, maloai, mathuonghieu, dvt, slt, hinhanh, hinhanhct,maSP);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteSP(string maSP)
        {
            try
            {
                daSP.DeleteSP(maSP);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public DataTable timKiemSPTheoTen(string tenSP)
        {
            return daSP.GetDataByTimKiemTheoTenSP(tenSP);
        }

        public bool KTKC(string maSP)
        {
            try
            {
                if (daSP.KTKC(maSP) > 0)
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

        public bool updateSLT(int slt, string maSP)
        {
            try
            {
                daSP.UpdateSLT(slt, maSP);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
