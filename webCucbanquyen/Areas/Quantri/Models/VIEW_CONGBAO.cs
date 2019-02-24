namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_CONGBAO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTacpham { get; set; }

        public int? idTacgia { get; set; }

        public int? Idchusohuu { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string SoTT { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ntext")]
        public string tacpham { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDmTacpham { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string sochungnhan { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "smalldatetime")]
        public DateTime ngaycap { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string hinhanh { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(255)]
        public string amthanh { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string nguoinhap { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "smalldatetime")]
        public DateTime ngaynhap { get; set; }

        [Key]
        [Column(Order = 10)]
        public byte pheduyet { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short loaihinhdangky { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sosapxep { get; set; }

        [StringLength(500)]
        public string dmTacpham { get; set; }

        [Column(TypeName = "ntext")]
        public string tencsh { get; set; }

        [StringLength(255)]
        public string socmtcsh { get; set; }

        [StringLength(500)]
        public string quoctichcsh { get; set; }

        [StringLength(255)]
        public string sodkkdcsh { get; set; }

        [Column(TypeName = "ntext")]
        public string diachicsh { get; set; }

        [Column(TypeName = "ntext")]
        public string tentacgia { get; set; }

        [StringLength(255)]
        public string socmttacgia { get; set; }

        [Column(TypeName = "ntext")]
        public string diachitacgia { get; set; }

        [StringLength(500)]
        public string quoctichtacgia { get; set; }

        public int? idQuoctichTacgia { get; set; }

        public int? idQuoctichCSH { get; set; }

        [StringLength(500)]
        public string dmTacphamByEng { get; set; }
    }
}
