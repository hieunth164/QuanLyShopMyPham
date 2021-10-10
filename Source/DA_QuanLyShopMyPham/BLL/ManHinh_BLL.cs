using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class ManHinh_BLL
    {
        ManHinh_DAL mh = new ManHinh_DAL();

        public ManHinh_BLL() { }

        public DataTable getData()
        {
            return mh.getData();
        }

        public bool insertMH(string maMH, string tenMH)
        {
            return mh.insertMH(maMH, tenMH);

        }

        public bool updateMH(string tenMH, string maMH)
        {
            return mh.updateMH(tenMH, maMH);
        }
        public bool deleteMH(string maMH)
        {
            return mh.deleteMH(maMH);

        }


        public bool KTKC(string maLNV)
        {
            return mh.KTKC(maLNV);
        }
    }
}
