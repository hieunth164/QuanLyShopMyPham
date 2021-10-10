using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class CTPN_BLL
    {
        CTPN_DAL ctpn = new CTPN_DAL();

        public CTPN_BLL() { }

        public DataTable getData()
        {
            return ctpn.getData();
        }

        public DataTable getCTPN(string maPN,string maSP)
        {
            return ctpn.getCTPN(maPN, maSP);
        }

        public bool KTKC(string maPN, string MaSP)
        {
            return ctpn.KTKC(maPN, MaSP);
        }

        public int? KTmaPN(string maPN)
        {
            return ctpn.KTmaPN(maPN);
        }

        public bool themCTPN(string maPN, string maSP, int soLuong, float donGiaNhap,float thanhTienNhap)
        {
            return ctpn.themCTPN(maPN, maSP, soLuong, donGiaNhap, thanhTienNhap);
        }

        public bool xoaCTPN(string maPN, string maSP)
        {
            return ctpn.xoaCTPN(maPN, maSP);
        }

        public DataTable getDataCTPN(string maPN)
        {
            return ctpn.getDataCTPN(maPN);
        }



        public bool suaCTPN(int soLuong, float donGiaNhap, float thanhTienNhap,string maPN, string maSP)
        {
            return ctpn.suaCTPN(soLuong, donGiaNhap, thanhTienNhap, maPN, maSP);
        }
    }
}
