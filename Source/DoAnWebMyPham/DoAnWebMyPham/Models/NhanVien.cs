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
    
    public partial class NhanVien
    {
        public NhanVien()
        {
            this.HoaDons = new HashSet<HoaDon>();
            this.PhieuNhaps = new HashSet<PhieuNhap>();
        }
    
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string MaLoaiNhanVien { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string ChungMinhThu { get; set; }
        public string HinhAnh { get; set; }
        public string MatKhau { get; set; }
    
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual LoaiNhanVien LoaiNhanVien { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}