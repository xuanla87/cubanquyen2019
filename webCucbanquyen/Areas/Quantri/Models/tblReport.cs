namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblReport")]
    public partial class tblReport
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string soTT { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ntext")]
        public string tentacpham { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string loaihinhTP { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string sochungnhan { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "smalldatetime")]
        public DateTime ngaycap { get; set; }

        [Column(TypeName = "ntext")]
        public string hoten_tg { get; set; }

        [StringLength(50)]
        public string quoctich_tg { get; set; }

        [StringLength(50)]
        public string soCMT_tg { get; set; }

        [Column(TypeName = "ntext")]
        public string diachi_tg { get; set; }

        [Column(TypeName = "ntext")]
        public string hoten_csh { get; set; }

        [StringLength(50)]
        public string quoctich_csh { get; set; }

        [StringLength(50)]
        public string soCMT_csh { get; set; }

        [Column(TypeName = "ntext")]
        public string diachi_csh { get; set; }

        [StringLength(50)]
        public string soDKKD { get; set; }

        [StringLength(50)]
        public string tenphim { get; set; }

        [StringLength(50)]
        public string tenanh { get; set; }
    }
}
