namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChusohuu")]
    public partial class tblChusohuu
    {
        [Key]
        public int Idchusohuu { get; set; }

        public int IdTacpham { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string tenchusohuu { get; set; }

        public int idDmquoctich { get; set; }

        [Required]
        [StringLength(255)]
        public string soCMT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string diachi_csh { get; set; }

        [Required]
        [StringLength(255)]
        public string soDKKD { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
