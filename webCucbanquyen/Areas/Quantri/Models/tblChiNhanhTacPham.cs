namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChiNhanhTacPham")]
    public partial class tblChiNhanhTacPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTacPham { get; set; }

        [StringLength(255)]
        public string SoTT { get; set; }

        [Required]
        [StringLength(1000)]
        public string TacPham { get; set; }

        public int IdDmTacPham { get; set; }

        [StringLength(255)]
        public string SoChungNhan { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayCap { get; set; }

        [Required]
        [StringLength(255)]
        public string HinhAnh { get; set; }

        [Required]
        [StringLength(255)]
        public string AmThanh { get; set; }

        [Required]
        [StringLength(50)]
        public string NguoiNhap { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayNhap { get; set; }

        public byte PheDuyet { get; set; }

        public short LoaiHinhDangKy { get; set; }

        public long SoSapXep { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }

        [StringLength(2)]
        public string TrangThai { get; set; }

        [StringLength(50)]
        public string DaiDien { get; set; }

        [StringLength(50)]
        public string VungMien { get; set; }

        [StringLength(500)]
        public string QuocGia { get; set; }

        [StringLength(500)]
        public string TenDaiDien { get; set; }

        [StringLength(50)]
        public string NoiNhap { get; set; }

        [StringLength(50)]
        public string TrangThaiCap { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
