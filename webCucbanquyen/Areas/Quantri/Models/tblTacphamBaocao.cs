namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTacphamBaocao")]
    public partial class tblTacphamBaocao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Idtacpham { get; set; }

        public int loaibaocao { get; set; }

        public int loaihinhdangky { get; set; }

        public int? nguoicap { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
