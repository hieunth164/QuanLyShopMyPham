using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_ShopMyPhamTableAdapters;
using System.Data;

namespace DAL
{
    public class NhaCungCap_DAL
    {
        NhaCungCapTableAdapter daNCC = new NhaCungCapTableAdapter();

        public NhaCungCap_DAL() { }

        public DataTable getData()
        {
            return daNCC.GetData();
        }

        public bool insertNCC(string maNCC, string tenNCC,string sdt,string diachi)
        {
            try
            {
                daNCC.Insert(maNCC, tenNCC,sdt,diachi);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateNCC( string tenNCC, string sdt, string diachi,string maNCC)
        {
            try
            {
                daNCC.UpdateNCC(tenNCC,sdt,diachi, maNCC);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteNCC(string maNCC)
        {
            try
            {
                daNCC.DeleteNCC(maNCC);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maNCC)
        {
            try
            {
                if (daNCC.KTKC(maNCC) > 0)
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

        public DataTable timKiemNCCTheoTen(string tenNCC)
        {
            return daNCC.GetDataByTimKiemTheoTenNCC(tenNCC);
        }
    }
}
