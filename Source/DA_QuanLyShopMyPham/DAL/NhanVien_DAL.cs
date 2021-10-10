using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class NhanVien_DAL
    {
        NhanVienTableAdapter daNV = new NhanVienTableAdapter();
        public NhanVien_DAL() { }

        public DataTable getDataNhanVien()
        {
            return daNV.GetData();
        }

        public DataTable getDataNhanVienBySDT(string sdt)
        {
            return daNV.GetDataBySDT(sdt);
        }
        public DataTable getDataDangNhap(string pSDT, string pMatKhau)
        {
            return daNV.GetDataByDangNhap(pSDT, pMatKhau);
        }

        public int? getMaTuDong()
        {
            return daNV.MaNVTuDongTang();
        }

        public bool insertNV(string maNV, string tenNV,string maLNV, DateTime ngaySinh, string gioitinh, string sdt, string diaChi, string cmt, string hinhanh, string matkhau)
        {
            try
            {
                daNV.Insert(maNV, tenNV,maLNV,ngaySinh, gioitinh, sdt, diaChi, cmt, hinhanh, matkhau);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateNV(string tenNV, string maLNV, string ngaySinh, string gioitinh, string sdt, string diaChi, string cmt, string hinhanh, string matkhau, string maNV)
        {
            try
            {
                daNV.UpdateNV(tenNV,maLNV,ngaySinh,gioitinh,sdt,diaChi,cmt,hinhanh,matkhau,maNV);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteNV(string maNV)
        {
            try
            {
                daNV.DeleteNV(maNV);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public DataTable timKiemNVTheoTen(string tenNV)
        {
            return daNV.GetDataByTimKiemTheoTenNV(tenNV);
        }

        public bool KTKC(string maNV)
        {
            try
            {
                if (daNV.KTKC(maNV)>0)
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

        public bool updateMK(string matkhau, string sdt)
        {
            try
            {
                daNV.UpdateMK(matkhau, sdt);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
