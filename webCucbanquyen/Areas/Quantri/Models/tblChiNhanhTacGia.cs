namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChiNhanhTacGia")]
    public partial class tblChiNhanhTacGia
    {
        [Key]
        public int IdTacGia { get; set; }

        public int IdTacPham { get; set; }

        [Required]
        [StringLength(250)]
        public string TenTacGia { get; set; }

        public int IdDmQuocTich { get; set; }

        [Required]
        [StringLength(255)]
        public string SoCMT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string DiaChi { get; set; }

        public int? NamSinh { get; set; }

        public int? NamMat { get; set; }

        public int? SoNamConHL { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
