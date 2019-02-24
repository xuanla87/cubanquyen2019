namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChiNhanhChuSoHuu")]
    public partial class tblChiNhanhChuSoHuu
    {
        [Key]
        public int IdChuSoHuu { get; set; }

        public int IdTacPham { get; set; }

        [Required]
        [StringLength(1000)]
        public string TenChuSoHuu { get; set; }

        public int IdDmQuocTich { get; set; }

        [Required]
        [StringLength(255)]
        public string SoCMT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string DiaChi_Csh { get; set; }

        [Required]
        [StringLength(255)]
        public string SoDKKD { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
