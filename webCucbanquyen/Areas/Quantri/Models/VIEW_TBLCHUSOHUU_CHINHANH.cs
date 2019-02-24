namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TBLCHUSOHUU_CHINHANH
    {
        [Key]
        [Column(Order = 0)]
        public int Idchusohuu { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTacpham { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "ntext")]
        public string tenchusohuu { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDmquoctich { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string soCMT { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "ntext")]
        public string diachi_csh { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string soDKKD { get; set; }

        [Key]
        [Column(Order = 7)]
        public Guid msrepl_tran_version { get; set; }
    }
}
