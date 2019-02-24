namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblThongtinkhac")]
    public partial class tblThongtinkhac
    {
        [Key]
        public int IdThongtinkhac { get; set; }

        public int Idtacpham { get; set; }

        [Required]
        [StringLength(4000)]
        public string thuhoigiayCN { get; set; }

        [Required]
        [StringLength(4000)]
        public string thaydoiCSH { get; set; }

        [Required]
        [StringLength(4000)]
        public string thongtinkhac { get; set; }

        [StringLength(50)]
        public string NgaycongboTP { get; set; }

        [StringLength(50)]
        public string NgayhoanthanhTP { get; set; }

        [StringLength(200)]
        public string Noicongbo { get; set; }

        public int? Congbo { get; set; }

        [StringLength(50)]
        public string SoQDTH { get; set; }

        [StringLength(50)]
        public string NgayQDTH { get; set; }

        [StringLength(1000)]
        public string LyDoTH { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
