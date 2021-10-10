using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class LoaiSanPham_BLL
    {
         LoaiSanPham_DAL lsp = new LoaiSanPham_DAL();

         public LoaiSanPham_BLL() { }

        public DataTable getData()
        {
            return lsp.getData();
        }

        public bool insertLSP(string maLSP, string tenLSP)
        {
            return lsp.insertLSP(maLSP, tenLSP);

        }

        public bool updateLSP(string tenLSP, string maLSP)
        {
            return lsp.updateLSP(tenLSP, maLSP);
        }
        public bool deleteLSP(string maLSP)
        {
            return lsp.deleteLSP(maLSP);
        }

        public bool KTKC(string maLSP)
        {
            return lsp.KTKC(maLSP);
        }
    }
}
