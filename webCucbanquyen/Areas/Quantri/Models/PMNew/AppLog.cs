namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CORE.AppLogs")]
    public partial class AppLog
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string ByUser { get; set; }

        public byte LogTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string Action { get; set; }

        [Required]
        [StringLength(700)]
        public string Description { get; set; }

        public virtual LogType LogType { get; set; }
    }
}
