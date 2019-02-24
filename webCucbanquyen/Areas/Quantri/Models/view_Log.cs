namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class view_Log
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int logId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Idtacpham { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ntext")]
        public string tacpham { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string sogiaychungnhan { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string username { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "smalldatetime")]
        public DateTime logDatetime { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(500)]
        public string logKind { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(250)]
        public string ghichu { get; set; }
    }
}
