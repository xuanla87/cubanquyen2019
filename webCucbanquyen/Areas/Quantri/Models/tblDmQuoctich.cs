namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDmQuoctich")]
    public partial class tblDmQuoctich
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDmQuoctich { get; set; }

        [Required]
        [StringLength(500)]
        public string dmQuoctich { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
