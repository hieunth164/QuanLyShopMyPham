using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class CTHD_BLL
    {
        CTHD_DAL cthd = new CTHD_DAL();

        public CTHD_BLL() { }

        public DataTable getData()
        {
            return cthd.getData();
        }

        public DataTable getCTHD(string maHD, string maSP)
        {
            return cthd.getCTHD(maHD, maSP);
        }

        public bool KTKC(string MaHD, string MaSP)
        {
            return cthd.KTKC(MaHD,MaSP);
        }

        public int? KTMaHD(string maHD)
        {
            return cthd.KTMaHD(maHD);
        }

        public bool themCTHD(string maHD, string maSP, int soLuong, float donGiaBan,float thanhTienBan)
        {
            return cthd.themCTHD(maHD, maSP, soLuong, donGiaBan, thanhTienBan);
        }

        public bool xoaCTHD(string maHD, string maSP)
        {
            return cthd.xoaCTHD(maHD, maSP);
        }

        public DataTable getDataCTHD(string maHD)
        {
            return cthd.getDataCTHD(maHD);
        }

        public bool suaCTHD(int soLuong, float donGiaBan, float thanhTienBan,string maHD, string maSP)
        {
            return cthd.suaCTHD(soLuong, donGiaBan, thanhTienBan, maHD, maSP);
        }
    }
}
