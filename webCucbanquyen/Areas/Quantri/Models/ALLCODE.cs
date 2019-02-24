namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALLCODE")]
    public partial class ALLCODE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string CODE { get; set; }

        [Required]
        [StringLength(500)]
        public string VALUE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SCOP { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
