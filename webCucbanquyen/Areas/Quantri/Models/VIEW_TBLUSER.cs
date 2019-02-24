namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIEW_TBLUSER
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string username { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string password { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string hoten { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string chucvu { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short admin { get; set; }

        [StringLength(50)]
        public string chinhanh { get; set; }
    }
}
