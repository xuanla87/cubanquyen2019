namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TPQUYETDINHTHUHOI
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

        [StringLength(2)]
        public string trangthai { get; set; }

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
        [StringLength(255)]
        public string sochungnhan { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "smalldatetime")]
        public DateTime ngaycap { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(500)]
        public string dmTacpham { get; set; }

        [StringLength(50)]
        public string SoQDTH { get; set; }

        [StringLength(50)]
        public string NgayQDTH { get; set; }

        [StringLength(1000)]
        public string LyDoTH { get; set; }
    }
}
