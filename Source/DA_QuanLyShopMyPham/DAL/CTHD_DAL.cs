using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class CTHD_DAL
    {
        CT_HoaDonTableAdapter daCTHD = new CT_HoaDonTableAdapter();

        public CTHD_DAL() { }

        public DataTable getData()
        {
            return daCTHD.GetData();
        }

        public DataTable getCTHD(string maHD,string maSP)
        {
            return daCTHD.GetDataByCTHD(maHD, maSP);
        }

        public bool KTKC(string MaHD, string MaSP)
        {
            try
            {
                if (daCTHD.KTKC(MaHD,MaSP)> 0)
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

        public int? KTMaHD(string maHD)
        {
            return daCTHD.KTMaHD(maHD);
        }

        public bool themCTHD(string maHD, string maSP, int soLuong, float donGiaBan,float thanhTienBan)
        {
            try
            {
                daCTHD.Insert(maHD, maSP, soLuong, donGiaBan, thanhTienBan);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaCTHD(string maHD, string maSP)
        {
            try
            {
                daCTHD.DeleteCTHD(maHD,maSP);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable getDataCTHD(string maHD)
        {
            return daCTHD.GetDataByMaHD(maHD);
        }



        public bool suaCTHD(int soLuong, float donGiaBan, float thanhTienBan,string maHD, string maSP)
        {
            try
            {
                daCTHD.UpdateCTHD(soLuong, donGiaBan, thanhTienBan, maHD, maSP);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
