using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class SanPham_BLL
    {
        SanPham_DAL sp = new SanPham_DAL();

        public SanPham_BLL() { }

        public DataTable getData()
        {
            return sp.getData();
        }

        public DataTable getDataByMaSP(string maSP)
        {
            return sp.getDataByMaSP(maSP);
        }
        public int? getMaTuDong()
        {
            return sp.getMaTuDong();
        }

        public bool insertSP(string maSP, string tenSP, float giaban, float gianhap, float giamgia, string mota, string maloai, string mathuonghieu, string dvt, int slt, string hinhanh, string hinhanhct)
        {
            return sp.insertSP(maSP, tenSP, giaban, gianhap,giamgia, mota, maloai, mathuonghieu, dvt, slt, hinhanh, hinhanhct);
               
        }

        public bool updateSP(string tenSP, float giaban, float gianhap, float giamgia, string mota, string maloai, string mathuonghieu, string dvt, int slt, string hinhanh, string hinhanhct, string maSP)
        {
            return sp.updateSP(tenSP, giaban, gianhap,giamgia, mota, maloai, mathuonghieu, dvt, slt, hinhanh, hinhanhct, maSP);
             
        }
        public bool deleteSP(string maSP)
        {
            return sp.deleteSP(maSP);
               
        }


        public DataTable timKiemSPTheoTen(string tenSP)
        {
            return sp.timKiemSPTheoTen(tenSP);
        }

        public bool KTKC(string maSP)
        {
            return sp.KTKC(maSP);
        }

        public bool updateSLT(int slt, string maSP)
        {
            return sp.updateSLT(slt, maSP);
        }
    }
}
