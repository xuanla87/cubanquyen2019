namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDanhsachdenCSH")]
    public partial class tblDanhsachdenCSH
    {
        [Key]
        [Column(Order = 0)]
        public int idChusohuu { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Tenchusohuu { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string SoDKKD { get; set; }
    }
}
