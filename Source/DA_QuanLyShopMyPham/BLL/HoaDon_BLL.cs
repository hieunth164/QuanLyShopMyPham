using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class HoaDon_BLL
    {
        HoaDon_DAL hd = new HoaDon_DAL();

        public HoaDon_BLL() { }

        public DataTable getData()
        {
            return hd.getData();
        }

        public int? getMaTuDong()
        {
            return hd.getMaTuDong();
        }

        public bool themHD(string maHD, string maNV, string maKH, DateTime ngayLap, int tongTien, string ghiChu)
        {
            return hd.themHD(maHD, maNV, maKH, ngayLap, tongTien,ghiChu);
        }
        public bool updateThanhTien(int tongTien, string maHD)
        {
            return hd.updateThanhTien(tongTien, maHD);
        }
        public DataTable getDataThangNam(int nam, int thang)
        {
            return hd.getDataThangNam(nam, thang);
        }

        public DataTable getDataNam(int nam)
        {
            return hd.getDataNam(nam);
        }

        public DataTable getDataNgay(DateTime pFrom, DateTime pTo)
        {
            return hd.getDataNgay(pFrom, pTo);
        }

        public DataTable getDataHoaDon()
        {
            return hd.getDataHoaDon();
        }
    }
}
