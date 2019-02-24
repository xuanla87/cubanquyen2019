namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDmbaocao")]
    public partial class tblDmbaocao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDmBaocao { get; set; }

        [Required]
        [StringLength(500)]
        public string DmBaocao { get; set; }

        public int? OrderBy { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
