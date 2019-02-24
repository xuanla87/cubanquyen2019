namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConfigSystem")]
    public partial class ConfigSystem
    {
        [Key]
        [StringLength(50)]
        public string configName { get; set; }

        public string configBody { get; set; }
    }
}
