namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNguoiCapCN")]
    public partial class tblNguoiCapCN
    {
        public int id { get; set; }

        [StringLength(200)]
        public string tennguoicap { get; set; }

        [StringLength(200)]
        public string chucvu { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
