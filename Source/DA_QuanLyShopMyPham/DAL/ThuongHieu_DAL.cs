using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class ThuongHieu_DAL
    {
         ThuongHieuTableAdapter daTH = new ThuongHieuTableAdapter();

         public ThuongHieu_DAL() { }

        public DataTable getData()
        {
            return daTH.GetData();
        }

        public bool insertTH(string maTH, string tenTH)
        {
            try
            {
                daTH.Insert(maTH, tenTH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateTH(string tenTH, string maTH)
        {
            try
            {
                daTH.UpdateThuongHieu(tenTH, maTH);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteTH(string maTH)
        {
            try
            {
                daTH.DeleteThuongHieu(maTH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maTH)
        {
            try
            {
                if (daTH.KTKC(maTH) > 0)
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
