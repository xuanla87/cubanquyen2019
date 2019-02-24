namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string hoten { get; set; }

        [Required]
        [StringLength(50)]
        public string chucvu { get; set; }

        public short admin { get; set; }

        [StringLength(50)]
        public string chinhanh { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
