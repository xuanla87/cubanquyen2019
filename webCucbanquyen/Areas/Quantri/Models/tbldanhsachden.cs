namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbldanhsachden")]
    public partial class tbldanhsachden
    {
        [Key]
        public int idTacgia { get; set; }

        [Required]
        [StringLength(100)]
        public string tentacgia { get; set; }

        [Required]
        [StringLength(50)]
        public string soCMT { get; set; }

        public int quoctichtg { get; set; }

        public Guid msrepl_tran_version { get; set; }
    }
}
