using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class CTPN_DAL
    {
        CT_PhieuNhapTableAdapter daCTPN = new CT_PhieuNhapTableAdapter();

        public CTPN_DAL() { }

        public DataTable getData()
        {
            return daCTPN.GetData();
        }

        public DataTable getCTPN(string maPN,string maSP)
        {
            return daCTPN.GetDataByCTPN(maPN, maSP);
        }

        public bool KTKC(string maPN, string MaSP)
        {
            try
            {
                if (daCTPN.KTKC(maPN,MaSP)> 0)
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

        public int? KTmaPN(string maPN)
        {
            return daCTPN.KTMaPN(maPN);
        }

        public bool themCTPN(string maPN, string maSP, int soLuong, float donGiaNhap,float thanhTienNhap)
        {
            try
            {
                daCTPN.Insert(maPN, maSP, soLuong, donGiaNhap, thanhTienNhap);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaCTPN(string maPN, string maSP)
        {
            try
            {
                daCTPN.DeleteCTPN(maPN,maSP);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable getDataCTPN(string maPN)
        {
            return daCTPN.GetDataByMaPN(maPN);
        }



        public bool suaCTPN(int soLuong, float donGiaNhap, float thanhTienNhap,string maPN, string maSP)
        {
            try
            {
                daCTPN.UpdateCTPN(soLuong, donGiaNhap, thanhTienNhap, maPN, maSP);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
