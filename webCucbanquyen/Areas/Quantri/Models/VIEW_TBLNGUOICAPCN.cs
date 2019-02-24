namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TBLNGUOICAPCN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(200)]
        public string tennguoicap { get; set; }

        [StringLength(200)]
        public string chucvu { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid msrepl_tran_version { get; set; }
    }
}
