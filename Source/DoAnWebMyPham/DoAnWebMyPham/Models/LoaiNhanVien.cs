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
    
    public partial class LoaiNhanVien
    {
        public LoaiNhanVien()
        {
            this.NhanViens = new HashSet<NhanVien>();
            this.PhanQuyens = new HashSet<PhanQuyen>();
        }
    
        public string MaLoaiNhanVien { get; set; }
        public string TenLoaiNhanVien { get; set; }
    
        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
