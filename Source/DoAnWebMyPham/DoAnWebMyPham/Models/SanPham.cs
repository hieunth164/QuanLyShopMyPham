//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnWebMyPham.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        public SanPham()
        {
            this.CT_HoaDon = new HashSet<CT_HoaDon>();
            this.CT_PhieuNhap = new HashSet<CT_PhieuNhap>();
        }
    
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public Nullable<double> GiaNhap { get; set; }
        public Nullable<double> GiamGia { get; set; }
        public string MoTa { get; set; }
        public string MaLoai { get; set; }
        public string MaThuongHieu { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<int> SoLuongTon { get; set; }
        public string HinhAnh { get; set; }
        public string HinhAnhChiTiet { get; set; }
    
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }
        public virtual ICollection<CT_PhieuNhap> CT_PhieuNhap { get; set; }
        public virtual LoaiHang LoaiHang { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
