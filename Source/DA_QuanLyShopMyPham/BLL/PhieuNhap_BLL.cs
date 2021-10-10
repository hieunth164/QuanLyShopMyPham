using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class PhieuNhap_BLL
    {
        PhieuNhap_DAL pn = new PhieuNhap_DAL();

        public PhieuNhap_BLL() { }

        public DataTable getData()
        {
            return pn.getData();
        }
        public int? getMaTuDong()
        {
            return pn.getMaTuDong();
        }

        public bool themPN(string maPN, string maNV, string maNCC, DateTime ngayLap, int tongTien, string ghiChu)
        {
            return pn.themPN(maPN, maNV, maNCC, ngayLap, tongTien, ghiChu);
        }

        public bool updateThanhTien(int tongTien, string maPN)
        {
            return pn.updateThanhTien(tongTien, maPN);
        }

        public DataTable getDataThangNam(int nam, int thang)
        {
            return pn.getDataThangNam(nam, thang);
        }

        public DataTable getDataNam(int nam)
        {
            return pn.getDataNam(nam);
        }


        public DataTable getDataNgay(DateTime pFrom, DateTime pTo)
        {
            return pn.getDataNgay(pFrom, pTo);
        }

        public DataTable getDataPhieuNhap()
        {
            return pn.getDataPhieuNhap();
        }
    }
}
