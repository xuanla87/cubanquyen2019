namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_CHINHANH_TBLTACPHAM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTacPham { get; set; }

        [StringLength(255)]
        public string SoTT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1000)]
        public string TacPham { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDmTacPham { get; set; }

        [StringLength(255)]
        public string SoChungNhan { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "smalldatetime")]
        public DateTime NgayCap { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string HinhAnh { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string AmThanh { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string NguoiNhap { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "smalldatetime")]
        public DateTime NgayNhap { get; set; }

        [StringLength(100)]
        public string trangthaiduyet { get; set; }

        [StringLength(100)]
        public string tenloaidk { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SoSapXep { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }

        [StringLength(2)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string nguoidaidien { get; set; }

        [StringLength(50)]
        public string VungMien { get; set; }

        [StringLength(50)]
        public string QuocGia { get; set; }

        [StringLength(500)]
        public string TenDaiDien { get; set; }

        [StringLength(50)]
        public string NoiNhap { get; set; }

        [StringLength(50)]
        public string TrangThaiCap { get; set; }

        [StringLength(500)]
        public string dmTacpham { get; set; }

        [Key]
        [Column(Order = 9)]
        public byte PheDuyet { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short LoaiHinhDangKy { get; set; }

        [StringLength(50)]
        public string DaiDien { get; set; }
    }
}
