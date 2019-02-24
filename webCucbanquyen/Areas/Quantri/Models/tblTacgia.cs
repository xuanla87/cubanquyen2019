namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTacgia")]
    public partial class tblTacgia
    {
        [Key]
        public int idTacgia { get; set; }

        public int idTacpham { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string tentacgia { get; set; }

        public int idDmquoctich { get; set; }

        [Required]
        [StringLength(255)]
        public string soCMT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string diachi { get; set; }

        public int? namSinh { get; set; }

        public int? namMat { get; set; }

        public int? soNamConHL { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
