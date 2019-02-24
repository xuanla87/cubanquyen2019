namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLog")]
    public partial class tblLog
    {
        [Key]
        public int logId { get; set; }

        public int Idtacpham { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string tacpham { get; set; }

        [Required]
        [StringLength(200)]
        public string sogiaychungnhan { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime logDatetime { get; set; }

        public short logKind { get; set; }

        [Required]
        [StringLength(250)]
        public string ghichu { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
