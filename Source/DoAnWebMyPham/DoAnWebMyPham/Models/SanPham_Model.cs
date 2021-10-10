using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DoAn_PTPMUDTM_WebMiPham.Models
{
    [Table("SanPham")]
    public class SanPham_Model
    {
        [Key]
        [Required(ErrorMessage = "Không được bỏ trống")]

        public string MaSP { set; get; }

        [Required]
        public string TenSP { set; get; }

        [Required]
        public float GiaBan { set; get; }

        [Required]
        public float GiamGia { set; get; }

        [Required]
        public float GiaNhap { set; get; }

        [Required]
        public string MoTa { set; get; }

        [Required()]
        public string MaLoai { set; get; }

        [Required()]
        public string MaThuongHieu { set; get; }

        [Required()]
        public string DonViTinh { set; get; }

        [Required()]
        public int SoLuongTon { set; get; }

        [Required()]
        public string Anh { set; get; }

        [Required()]
        public string AnhCT { set; get; }

    }
}