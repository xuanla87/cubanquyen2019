namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TBLDMTACPHAM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDmtacpham { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string dmTacpham { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string dmTacphamByEng { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDmBaocao { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int loaihinhdangky { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte Invisible { get; set; }
    }
}
