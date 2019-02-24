namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CORE.BusinessClientVersions")]
    public partial class BusinessClientVersion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Edition { get; set; }

        public int Major { get; set; }

        public int Minor { get; set; }

        public int Build { get; set; }

        public int Revision { get; set; }

        public DateTime PublishedDate { get; set; }

        public bool IsCurrent { get; set; }

        [Required]
        public byte[] Data { get; set; }
    }
}
