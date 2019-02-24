namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TBLDMQUOCTICH_TACGIA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTacgia { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTacpham { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ntext")]
        public string tentacgia { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDmquoctich { get; set; }

        [StringLength(500)]
        public string dmquoctich { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string soCMT { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "ntext")]
        public string diachi { get; set; }

        public int? namSinh { get; set; }

        public int? namMat { get; set; }

        public int? soNamConHL { get; set; }
    }
}
