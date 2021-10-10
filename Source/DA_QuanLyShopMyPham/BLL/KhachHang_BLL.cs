using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class KhachHang_BLL
    {
        KhachHang_DAL kh = new KhachHang_DAL();

        public KhachHang_BLL() { }

        public DataTable getData()
        {
            return kh.getData();
        }

        public bool insertKH(string maKH, string tenKH, DateTime ngaysinh, string sdt, string diachi, string email, string matkhau)
        {
            return kh.insertKH(maKH, tenKH, ngaysinh, sdt, diachi,email,matkhau);
        }

        public bool updateKH( string tenKH,string ngaysinh, string sdt, string diachi,string email,string matkhau,string maKH)
        {
            return kh.updateKH(tenKH,ngaysinh, sdt, diachi,email,matkhau, maKH);
        }
        public bool deleteKH(string maKH)
        {
            return kh.deleteKH(maKH);
        }

        public bool KTKC(string maKH)
        {
            return kh.KTKC(maKH);
        }

        public DataTable timKiemKHTheoTen(string tenKH)
        {
            return kh.timKiemKHTheoTen(tenKH);
        }

        public DataTable getKhachHangMaKH(string maKH)
        {
            return kh.getKhachHangMaKH(maKH);
        }

        public DataTable getKhachHangTenKH(string tenKH)
        {
            return kh.getKhachHangTenKH(tenKH);
        }

        public bool themKH(string hoTenKH)
        {
            return kh.themKH(hoTenKH);
        }
    }
}
