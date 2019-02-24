namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDmTacpham")]
    public partial class tblDmTacpham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDmtacpham { get; set; }

        [Required]
        [StringLength(500)]
        public string dmTacpham { get; set; }

        [Required]
        [StringLength(500)]
        public string dmTacphamByEng { get; set; }

        public int idDmBaocao { get; set; }

        public int loaihinhdangky { get; set; }

        public byte Invisible { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
