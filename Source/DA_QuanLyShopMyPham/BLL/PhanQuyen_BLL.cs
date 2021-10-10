using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class PhanQuyen_BLL
    {
        PhanQuyen_DAL pq = new PhanQuyen_DAL();

        public PhanQuyen_BLL() { }

        public DataTable GetMaManHinh(string pMaNhomMH)
        {
            return pq.GetMaManHinh(pMaNhomMH);
        }

        public DataTable getData(string maLNV)
        {
            return pq.getData(maLNV);
        }

        public bool KTKC(string maLNV, string maMH)
        {
            return pq.KTKC(maLNV, maMH);
        }

        public bool updatePQ(bool coquyen, string maLNV, string maMH)
        {
            return pq.updatePQ(coquyen, maLNV, maMH);
        }

        public bool insertPQ( string maLNV, string maMH,bool coquyen)
        {
            return pq.insertPQ( maLNV, maMH,coquyen);
        }
    }
}
