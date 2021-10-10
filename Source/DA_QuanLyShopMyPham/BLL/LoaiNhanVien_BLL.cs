using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class LoaiNhanVien_BLL
    {
        LoaiNhanVien_DAL lnv = new LoaiNhanVien_DAL();

        public LoaiNhanVien_BLL() { }

        public DataTable getDataLoaiNV()
        {
            return lnv.getDataLoaiNV();
        }

        public bool insertLNV(string maLNV, string tenLNV){
            return lnv.insertLNV(maLNV, tenLNV);
        
        }

        public bool updateLNV(string tenLNV, string maLNV)
        {
            return lnv.updateLNV(tenLNV, maLNV);
        }
        public bool deleteLNV(string maLNV)
        {
            return lnv.deleteLNV(maLNV);

        }

        public bool KTKC(string maLNV)
        {
            return lnv.KTKC(maLNV);
        }

        public List<string> GetMaNhomNguoiDung(string maNND)
        {
            return lnv.GetMaNhomNguoiDung(maNND);
        }
    }
}
