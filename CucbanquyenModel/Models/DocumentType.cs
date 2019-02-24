

namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocumentType")]
    public partial class DocumentType
    {
        public int documentTypeId { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Loại văn bản")]
        public string documentTypeName { get; set; }

        public bool isTrash { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public int languageId { get; set; }

        public virtual IEnumerable<Document> Documents { set; get; }
    }
}
