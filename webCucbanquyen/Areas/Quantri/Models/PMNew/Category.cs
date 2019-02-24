namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COV.Categories")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Categories1 = new HashSet<Category>();
            Works = new HashSet<Work>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public int Level { get; set; }

        [Required]
        [StringLength(100)]
        public string Path { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        [Required]
        [StringLength(300)]
        public string EnglishTitle { get; set; }

        public bool ForRelatedRightOnly { get; set; }

        public bool Enable { get; set; }

        public int SortOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories1 { get; set; }

        public virtual Category Category1 { get; set; }

        public virtual ProgramType ProgramType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Work> Works { get; set; }
    }
}
