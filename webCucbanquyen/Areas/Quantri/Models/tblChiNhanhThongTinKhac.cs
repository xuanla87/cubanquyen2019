namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChiNhanhThongTinKhac")]
    public partial class tblChiNhanhThongTinKhac
    {
        [Key]
        public int IdThongTinKhac { get; set; }

        public int IdTacPham { get; set; }

        [Required]
        [StringLength(10)]
        public string ThuHoiGiayCN { get; set; }

        [Required]
        [StringLength(10)]
        public string ThayDoiCSH { get; set; }

        [Required]
        [StringLength(4000)]
        public string ThongTinKhac { get; set; }

        [StringLength(50)]
        public string NgayCongBoTP { get; set; }

        [StringLength(50)]
        public string NgayHoanThanhTP { get; set; }

        [StringLength(200)]
        public string NoiCongBo { get; set; }

        public int? CongBo { get; set; }

        [StringLength(100)]
        public string SoQDTH { get; set; }

        [StringLength(50)]
        public string NgayQDTH { get; set; }

        [StringLength(1000)]
        public string LyDoTH { get; set; }

        public int? CheckStatus { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
