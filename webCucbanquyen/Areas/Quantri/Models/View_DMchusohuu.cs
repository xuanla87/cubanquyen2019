namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_DMchusohuu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        [StringLength(255)]
        public string soCMT { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "ntext")]
        public string diachi_csh { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string soDKKD { get; set; }

        [StringLength(500)]
        public string dmQuoctich { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idQuoctichCSH { get; set; }
    }
}
