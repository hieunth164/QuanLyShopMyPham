using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWebMyPham.Models;
namespace DoAnWebMyPham.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/

        QL_ShopMyPhamEntities2 db = new QL_ShopMyPhamEntities2();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection col)
        {
            string ten = col["txtSDT"];
            string mk = col["txtPass"];

            KhachHang khach = db.KhachHangs.SingleOrDefault(k => k.SoDienThoai == ten && k.MatKhau == mk);
            if (khach == null) //không thành công
            {
                ViewBag.tb = "Thông tin đăng nhập sai";
                return View();
            }
            if (khach.SoDienThoai == "0912345678" && khach.MatKhau == "bp2812")
            {
                return RedirectToAction("ShowSanPham", "Admin");
            }

            Session["kh"] = khach;

            return RedirectToAction("Index", "SanPham");
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangXuat()
        {
            GioHang gio = Session["gh"] as GioHang;
            Session["kh"]=null;
            return RedirectToAction("DangNhap","KhachHang");
        }
        public ActionResult DangXuatAdmin()
        {
            Session["kh"] = null;
            return RedirectToAction("DangNhap", "KhachHang");
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang k, FormCollection f)
        {
            var hoten = f["TenKH"];
            var ngaysinh = String.Format("{0: MM/DD/YYYY}", f["NgaySinh"]);
            var sdt = f["SDT"];
            var diachi = f["DiaChi"];
            var email = f["Email"];
            var matkhau = f["Pass"];
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Vui lòng nhập mật khẩu";
            }
            if (String.IsNullOrEmpty(sdt))
            {
                ViewData["Loi5"] = "Vui lòng nhập số điện thoại";
            }
            if (!String.IsNullOrEmpty(hoten)  && !String.IsNullOrEmpty(matkhau) && !String.IsNullOrEmpty(sdt) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(diachi))
            {
                k.MaKhachHang ="";
                k.TenKhachHang = hoten;
                k.NgaySinh = DateTime.Parse(ngaysinh);
                k.MatKhau = matkhau;
                k.SoDienThoai = sdt;
                k.DiaChi = diachi;
                k.Email = email;
                KhachHang khach = db.KhachHangs.SingleOrDefault(h => h.SoDienThoai == sdt);
                if (khach != null)
                {
                    ViewData["Loi6"] = "Số điện thoại đã được đăng kí";
                }
                else
                {
                    db.KhachHangs.Add(k);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap", "KhachHang");
                }
            }
            return View();
        }


    }
    
}
