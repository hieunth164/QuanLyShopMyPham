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
    
    public partial class PhanQuyen
    {
        public string MaLoaiNhanVien { get; set; }
        public string MaManHinh { get; set; }
        public Nullable<bool> CoQuyen { get; set; }
    
        public virtual LoaiNhanVien LoaiNhanVien { get; set; }
        public virtual ManHinh ManHinh { get; set; }
    }
}
