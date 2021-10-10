using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class ManHinh_DAL
    {
        ManHinhTableAdapter daMH = new ManHinhTableAdapter();

        public ManHinh_DAL() { }

        public DataTable getData()
        {
            return daMH.GetData();
        }

        public bool insertMH(string maMH, string tenMH)
        {
            try
            {
                daMH.Insert(maMH, tenMH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateMH(string tenMH, string maMH)
        {
            try
            {
                daMH.UpdateMH(tenMH, maMH);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteMH(string maMH)
        {
            try
            {
                daMH.DeleteMH(maMH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maMH)
        {
            try
            {
                if (daMH.KTKC(maMH) > 0)
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

    }
}
