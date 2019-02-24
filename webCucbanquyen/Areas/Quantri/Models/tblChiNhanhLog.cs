namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChiNhanhLog")]
    public partial class tblChiNhanhLog
    {
        [Key]
        public int LogId { get; set; }

        public int IdTacPham { get; set; }

        [StringLength(1000)]
        public string TacPham { get; set; }

        [StringLength(200)]
        public string SoGiayChungNhan { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LogDatetime { get; set; }

        public short? LogKind { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
