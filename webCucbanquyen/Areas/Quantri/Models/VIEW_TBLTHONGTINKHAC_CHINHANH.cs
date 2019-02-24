namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TBLTHONGTINKHAC_CHINHANH
    {
        [Key]
        [Column(Order = 0)]
        public int IdThongtinkhac { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Idtacpham { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4000)]
        public string thuhoigiayCN { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4000)]
        public string thaydoiCSH { get; set; }

        [Key]
        [Column(Order = 4)]
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

        [Key]
        [Column(Order = 5)]
        public Guid msrepl_tran_version { get; set; }
    }
}
