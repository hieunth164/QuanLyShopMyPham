using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{

    public class NhanVien_BLL
    {
        NhanVien_DAL nv = new NhanVien_DAL();

        public NhanVien_BLL() { }

        public DataTable getDataNhanVien()
        {
            return nv.getDataNhanVien();
        }

        public DataTable getDataNhanVienBySDT(string sdt)
        {
            return nv.getDataNhanVienBySDT(sdt);
        }

        public DataTable getDataDangNhap(string pSDT, string pMatKhau)
        {
            return nv.getDataDangNhap(pSDT, pMatKhau);
        }

        public int? getMaTuDong()
        {
            return nv.getMaTuDong();
        }

        public bool insertNV(string maNV, string tenNV, string maLNV, DateTime ngaySinh, string gioitinh, string sdt, string diaChi, string cmt, string hinhanh, string matkhau)
        {
            return nv.insertNV(maNV, tenNV, maLNV, ngaySinh, gioitinh, sdt, diaChi, cmt, hinhanh, matkhau);
              
        }

        public bool updateNV(string tenNV, string maLNV, string ngaySinh, string gioitinh, string sdt, string diaChi, string cmt, string hinhanh, string matkhau, string maNV)
        {
            return nv.updateNV(tenNV, maLNV, ngaySinh, gioitinh, sdt, diaChi, cmt, hinhanh, matkhau, maNV);
                
        }
        public bool deleteNV(string maNV)
        {
            return nv.deleteNV(maNV);
               
        }


        public DataTable timKiemNVTheoTen(string tenNV)
        {
            return nv.timKiemNVTheoTen(tenNV);
        }

        public bool KTKC(string maNV)
        {
            return nv.KTKC(maNV);
        }

        public bool updateMK(string matkhau, string sdt)
        {
            return nv.updateMK(matkhau, sdt);
        }
    }
}
