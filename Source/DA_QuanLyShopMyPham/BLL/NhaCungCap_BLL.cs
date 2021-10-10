using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class NhaCungCap_BLL
    {
        NhaCungCap_DAL ncc = new NhaCungCap_DAL();

        public NhaCungCap_BLL() { }

        public DataTable getData()
        {
            return ncc.getData();
        }

        public bool insertNCC(string maNCC, string tenNCC,string sdt,string diachi)
        {
            return ncc.insertNCC(maNCC, tenNCC, sdt, diachi);
        }

        public bool updateNCC( string tenNCC, string sdt, string diachi,string maNCC)
        {
            return ncc.updateNCC(tenNCC, sdt, diachi, maNCC);
        }
        public bool deleteNCC(string maNCC)
        {
            return ncc.deleteNCC(maNCC);
        }

        public bool KTKC(string maNCC)
        {
            return ncc.KTKC(maNCC);
        }

        public DataTable timKiemNCCTheoTen(string tenNCC)
        {
            return ncc.timKiemNCCTheoTen(tenNCC);
        }
    }
}
