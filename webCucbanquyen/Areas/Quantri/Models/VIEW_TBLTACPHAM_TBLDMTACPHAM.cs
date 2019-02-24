namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TBLTACPHAM_TBLDMTACPHAM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTacpham { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string SoTT { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ntext")]
        public string tacpham { get; set; }

        [StringLength(300)]
        public string tacgia { get; set; }

        [StringLength(300)]
        public string quoctichtacgia { get; set; }

        [StringLength(300)]
        public string socmt { get; set; }

        [StringLength(300)]
        public string diachitacgia { get; set; }

        [StringLength(300)]
        public string chusohuu { get; set; }

        [StringLength(300)]
        public string socmtchusohuu { get; set; }

        [StringLength(300)]
        public string quoctichchusohuu { get; set; }

        [StringLength(300)]
        public string diachichusohuu { get; set; }

        [StringLength(300)]
        public string sodkkd { get; set; }

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

        [StringLength(255)]
        public string imagepath { get; set; }

        [StringLength(2)]
        public string trangthai { get; set; }

        [StringLength(50)]
        public string daidien { get; set; }

        [StringLength(50)]
        public string vungmien { get; set; }

        [StringLength(200)]
        public string quocgia { get; set; }

        [StringLength(500)]
        public string tendaidien { get; set; }

        [StringLength(50)]
        public string noinhap { get; set; }

        [StringLength(50)]
        public string trangthaicap { get; set; }

        [StringLength(100)]
        public string tenloaidk { get; set; }

        [StringLength(100)]
        public string trangthaiduyet { get; set; }

        [StringLength(100)]
        public string nguoidaidien { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(500)]
        public string dmTacpham { get; set; }

        public int? loaibaocao { get; set; }

        [StringLength(500)]
        public string capcho { get; set; }
    }
}
