using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class HoaDon_DAL
    {
        HoaDonTableAdapter daHD = new HoaDonTableAdapter();

        public HoaDon_DAL() { }

        public DataTable getData()
        {
            return daHD.GetData();
        }
        public int? getMaTuDong()
        {
            return daHD.MaHDTuDongTang();
        }

        public bool themHD(string maHD, string maNV, string maKH, DateTime ngayLap, int tongTien, string ghiChu)
        {
            try
            {
                daHD.Insert(maHD, maNV, maKH, ngayLap, tongTien, ghiChu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateThanhTien(int tongTien, string maHD)
        {
            try
            {
                daHD.UpdateTongTien(tongTien, maHD);
                return true;
            }
            catch
            {
                return false;
            }
        }

       public DataTable getDataThangNam(int nam, int thang)
        {
            return daHD.GetDataByThangNam(nam, thang);
        }

        public DataTable getDataNam(int nam)
        {
            return daHD.GetDataByNam(nam);
        }


        public DataTable getDataNgay(DateTime pFrom, DateTime pTo)
        {
            return daHD.GetDataByNgay(pFrom, pTo);
        }

        public DataTable getDataHoaDon()
        {
            return daHD.GetDataByHoaDon();
        }
    }
}
