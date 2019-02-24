namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_ALLCODE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string CODE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string VALUE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string SCOP { get; set; }
    }
}
