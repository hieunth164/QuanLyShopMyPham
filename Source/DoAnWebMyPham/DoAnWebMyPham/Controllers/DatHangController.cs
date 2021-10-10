using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWebMyPham.Models;

namespace DoAnWebMyPham.Controllers
{
    public class DatHangController : Controller
    {
        //
        // GET: /DatHang/

        QL_ShopMyPhamEntities2 db = new QL_ShopMyPhamEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GioHangTrong()
        {
            return View();
        }
        public ActionResult ThemMatHang(string msp)
        {
            GioHang gio = (GioHang)Session["gh"];              
            if (gio == null)
                gio = new GioHang();
            int kq = gio.Them(msp);
            Session["gh"] = gio;
            return RedirectToAction("Index", "SanPham");
        }
        [HttpGet]
        public ActionResult XemGioHang()
        {
            GioHang gio = (GioHang)Session["gh"];
            KhachHang khach = Session["kh"] as KhachHang;
            if (khach == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            if (gio != null)
            {
                gio = Session["gh"] as GioHang;
                ViewBag.kh = khach;
                ViewBag.tongsl = gio.tongSLHang().ToString();
                ViewBag.tongthanhtien = gio.tongThanhTien().ToString();
                return View(gio);
            }          
            return RedirectToAction("GioHangTrong", "DatHang");
        }
        public ActionResult XoaGioHang(string msp)
        {
            GioHang gio = (GioHang)Session["gh"];
            CartItem sp = gio.dssp.Single(m => m.iMaSP == msp);
            if (sp!=null)
            {
                gio.dssp.RemoveAll(m => m.iMaSP == msp);
                return RedirectToAction("XemGioHang", "DatHang");
            }
            else if (gio.dssp.Count == 0)
            {
                return RedirectToAction("GioHangTrong", "DatHang");
            }
            return RedirectToAction("XemGioHang", "DatHang");
        }
        public ActionResult UpdateGioHang(string msp, FormCollection f)
        {

            
            GioHang gio = (GioHang)Session["gh"];
            CartItem sp = gio.dssp.Single(m => m.iMaSP == msp);
            if (sp != null)
            {
                sp.isoluong=int.Parse(f["txtsl"].ToString());
            }
            if (gio.dssp.Count == 0)
            {
                return RedirectToAction("GioHangTrong", "DatHang");
            }
            return RedirectToAction("XemGioHang", "DatHang");
        }
        public ActionResult XoaGioHangAll()
        {
            GioHang gio = (GioHang)Session["gh"];
            gio.dssp.Clear();
            return RedirectToAction("Index", "SanPham");
        }
        public ActionResult kiemTraDH()
        {
            KhachHang khach = Session["kh"] as KhachHang;
            if (khach == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            GioHang gio = Session["gh"] as GioHang;
            ViewBag.k = khach;
            ViewBag.tsl = gio.tongSLHang();
            ViewBag.ttt = gio.tongThanhTien();
            return View(gio);
        }
        public ActionResult ChiTietGiaoDich()
        {
            KhachHang khach = Session["kh"] as KhachHang;
            if (khach == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            List<HoaDon> dshd = db.HoaDons.Where(m => m.MaKhachHang == khach.MaKhachHang).ToList();
            return View(dshd);
        }
        public ActionResult ChitietHD(string mahd)
        {
            List<CT_HoaDon> dshd = db.CT_HoaDon.Where(m => m.MaHoaDon == mahd).ToList();
            return View(dshd);
        }
        [HttpPost]
        public ActionResult XacNhanDonHang(FormCollection col)
        {
            KhachHang khach = Session["kh"] as KhachHang;
            GioHang gio = Session["gh"] as GioHang;
            string ghiChu = col["txtGhiChu"];
            string MaHD = "";
            //lưu thông tin 1 dòng vào hóa đơn
            HoaDon dh = new HoaDon();
            dh.MaHoaDon = "";
            dh.MaNhanVien = "NV001";
            dh.MaKhachHang = khach.MaKhachHang;
            dh.NgayLap = DateTime.Now;
            //dh.TinhTrang = Int32.Parse(tinhTrang);
            //dh.GhiChu = ghiChu;
            dh.TongTien = gio.tongThanhTien();
            dh.GhiChu = ghiChu;
            db.HoaDons.Add(dh);
            db.SaveChanges();
            var x = from k in db.HoaDons select k;
            foreach(HoaDon hd in x)
            {
                MaHD = hd.MaHoaDon;
            }
            foreach (CartItem item in gio.dssp)
            {
                CT_HoaDon ct = new CT_HoaDon();
                ct.MaHoaDon = MaHD;
                ct.MaSanPham = item.iMaSP;
                ct.SoLuongBan = item.isoluong;
                ct.DonGiaBan = item.iDonGia;
                ct.ThanhTienBan = item.ThanhTien;
                db.CT_HoaDon.Add(ct);
                db.SaveChanges();
            }
            gio.dssp = null;
            return View(dh);
        }       

    
    }
}
