namespace webCucbanquyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visiter")]
    public partial class Visiter
    {
        public int visiterId { get; set; }

        [StringLength(50)]
        public string visiterIP { get; set; }

        public DateTime createTime { get; set; }

        [StringLength(256)]
        public string visiterLocation { get; set; }

        [StringLength(256)]
        public string visiterBrowser { get; set; }
    }
}
