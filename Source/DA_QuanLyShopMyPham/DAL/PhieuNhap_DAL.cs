using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QL_ShopMyPhamTableAdapters;

namespace DAL
{
    public class PhieuNhap_DAL
    {
        PhieuNhapTableAdapter daPN = new PhieuNhapTableAdapter();

        public PhieuNhap_DAL() { }

        public DataTable getData()
        {
            return daPN.GetData();
        }
        public int? getMaTuDong()
        {
            return daPN.MaPNTuDongTang();
        }

        public bool themPN(string maPN, string maNV, string maNCC, DateTime ngayLap, int tongTien, string ghiChu)
        {
            try
            {
                daPN.Insert(maPN, maNV, maNCC, ngayLap, tongTien, ghiChu);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateThanhTien(int tongTien, string maPN)
        {
            try
            {
                daPN.UpdateTongTien(tongTien, maPN);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable getDataThangNam(int nam, int thang)
        {
            return daPN.GetDataByThangNam(nam, thang);
        }

        public DataTable getDataNam(int nam)
        {
            return daPN.GetDataByNam(nam);
        }


        public DataTable getDataNgay(DateTime pFrom, DateTime pTo)
        {
            return daPN.GetDataByNgay(pFrom, pTo);
        }

        public DataTable getDataPhieuNhap()
        {
            return daPN.GetDataByPhieuNhap();
        }
    }
}
