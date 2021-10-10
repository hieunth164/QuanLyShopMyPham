using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWebMyPham.Models
{
    public class CartItem
    {
        QL_ShopMyPhamEntities2 db = new QL_ShopMyPhamEntities2();
        public string iMaSP { get; set; }
        public string iTenSP { get; set; }
        public string iAnhBia { get; set; }
        public double iDonGia { get; set; }
        public int isoluong { get; set; }

        public double ThanhTien
        {
            get { return isoluong * iDonGia; }
        }
        public CartItem(string Masp)
        {
            SanPham sp = db.SanPhams.Single(n => n.MaSanPham == Masp);
            if (sp != null)
            {
                iMaSP = Masp;
                iTenSP = sp.TenSanPham;
                iAnhBia = sp.HinhAnh;
                iDonGia = double.Parse(sp.GiamGia.ToString());
                isoluong = 1;
            }
        }
    }
    
}