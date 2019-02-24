namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTacpham")]
    public partial class tblTacpham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTacpham { get; set; }

        [Required]
        [StringLength(255)]
        public string SoTT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string tacpham { get; set; }

        public int idDmTacpham { get; set; }

        [Required]
        [StringLength(255)]
        public string sochungnhan { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ngaycap { get; set; }

        [Required]
        [StringLength(255)]
        public string hinhanh { get; set; }

        [Required]
        [StringLength(255)]
        public string amthanh { get; set; }

        [Required]
        [StringLength(50)]
        public string nguoinhap { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ngaynhap { get; set; }

        public byte pheduyet { get; set; }

        public short loaihinhdangky { get; set; }

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

        public Guid msrepl_tran_version { get; set; }
    }
}
