using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class PhanQuyen_DAL
    {
        PhanQuyenTableAdapter daPQ = new PhanQuyenTableAdapter();

        GetPhanQuyenTableAdapter daGetPQ = new GetPhanQuyenTableAdapter();

        public PhanQuyen_DAL() { }

        public DataTable GetMaManHinh(string pMaNhomMH)
        {
            return daPQ.GetDataByDSMH(pMaNhomMH);
        }

        public DataTable getData(string maLNV)
        {
            return daGetPQ.GetData(maLNV);
        }

        public bool KTKC(string maLNV, string maMH)
        {
            try
            {
                if (daPQ.KTKC(maLNV,maMH)>0)
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

        public bool updatePQ(bool coquyen, string maLNV, string maMH)
        {
            try
            {
                daPQ.UpdatePQ(coquyen, maLNV, maMH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insertPQ(string maLNV, string maMH,bool coquyen)
        {
            try
            {
                daPQ.Insert( maLNV, maMH,coquyen);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
