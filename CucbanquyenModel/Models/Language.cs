namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Language")]
    public partial class Language
    {
        public int languageId { get; set; }

        [Required]
        [StringLength(256)]
        public string languageName { get; set; }

        public string languageNote { get; set; }

        [Required]
        [StringLength(256)]
        public string languageIcon { get; set; }

        public bool isTrash { get; set; }

        public bool isDefault { get; set; }

        public int sortOrder { get; set; }
    }
}
