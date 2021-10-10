using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWebMyPham.Models;


namespace DoAn_PTPMUDTM_WebMiPham.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/

        QL_ShopMyPhamEntities2 db = new QL_ShopMyPhamEntities2();
        public ActionResult Index()
        {
            List<SanPham> ds = db.SanPhams.ToList();
            return View(ds);
        }

        public ActionResult Details(string msp)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(item => item.MaSanPham == msp);
            List<SanPham> ds_Loai = db.SanPhams.Where(s => s.MaLoai == sp.MaLoai).Take(8).ToList();
            ViewBag.Loai = ds_Loai;
            return View(sp);
        }
        public ActionResult KhoiTaoLayout()
        {
            GioHang gio = (GioHang)Session["gh"];

            //bổ sung
            KhachHang Khach = Session["kh"] as KhachHang;
            ViewBag.kh = Khach;
            //

            return PartialView(gio);
        }
        public ActionResult Search(FormCollection col)
        {
            string keyword = col["txtsearch"];
            List<SanPham> dssp = db.SanPhams.Where(s => s.TenSanPham.Contains(keyword)).ToList();
            ViewBag.tb = "Tìm Kiếm " + keyword.ToString();
            return View("Index", dssp);
        }

        public ActionResult PhanMat()
        {
            List<SanPham> spn = db.SanPhams.ToList();
            return View(spn);
        }

        public ActionResult KeMat()
        {
            List<SanPham> spn = db.SanPhams.ToList();
            return View(spn);
        }

        public ActionResult Son()
        {
            List<SanPham> spn = db.SanPhams.ToList();
            return View(spn);
        }

        public ActionResult Kem()
        {
            List<SanPham> spn = db.SanPhams.ToList();
            return View(spn);
        }

        public ActionResult Serum()
        {
            List<SanPham> spn = db.SanPhams.ToList();
            return View(spn);
        }

        public ActionResult SRM()
        {
            List<SanPham> spn = db.SanPhams.ToList();
            return View(spn);
        }

        public ActionResult NuocHoaNam()
        {
            List<SanPham> spn = db.SanPhams.ToList();
            return View(spn);
        }

        public ActionResult NuocHoaNu()
        {
            List<SanPham> spn = db.SanPhams.ToList();
            return View(spn);
        }
    }
}
