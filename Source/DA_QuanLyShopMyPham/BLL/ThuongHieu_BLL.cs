using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class ThuongHieu_BLL
    {
        ThuongHieu_DAL th = new ThuongHieu_DAL();

        public ThuongHieu_BLL() { }

        public DataTable getData()
        {
            return th.getData();
        }

        public bool insertTH(string maTH, string tenTH)
        {
            return th.insertTH(maTH, tenTH);

        }

        public bool updateTH(string tenTH, string maTH)
        {
            return th.updateTH(tenTH, maTH);
        }
        public bool deleteTH(string maTH)
        {
            return th.deleteTH(maTH);
        }

        public bool KTKC(string maTH)
        {
            return th.KTKC(maTH);
        }
    }
}
