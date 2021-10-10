using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class KhachHang_DAL
    {

        KhachHangTableAdapter daKH = new KhachHangTableAdapter();

        public KhachHang_DAL() { }

        public DataTable getData()
        {
            return daKH.GetData();
        }

        public bool insertKH(string maKH, string tenKH, DateTime ngaysinh, string sdt, string diachi, string email, string matkhau)
        {
            try
            {
                daKH.Insert(maKH, tenKH, ngaysinh, sdt, diachi,email,matkhau);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateKH( string tenKH,string ngaysinh, string sdt, string diachi,string email,string matkhau,string maKH)
        {
            try
            {
                daKH.UpdateKH(tenKH,ngaysinh, sdt, diachi,email,matkhau, maKH);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteKH(string maKH)
        {
            try
            {
                daKH.DeleteKH(maKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maKH)
        {
            try
            {
                if (daKH.KTKC(maKH) > 0)
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

        public DataTable timKiemKHTheoTen(string tenKH)
        {
            return daKH.GetDataByTimKiemTheoTenKH(tenKH);
        }

        public DataTable getKhachHangMaKH(string maKH)
        {
            return daKH.GetDataByMaKH(maKH);
        }

        public DataTable getKhachHangTenKH(string tenKH)
        {
            return daKH.GetDataByTenKH(tenKH);
        }

        public bool themKH(string hoTenKH)
        {
            try
            {
                daKH.ThemKH(hoTenKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
