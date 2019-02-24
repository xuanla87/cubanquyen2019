namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COV.Works")]
    public partial class Work
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Work()
        {
            Authors = new HashSet<Author>();
            Owners = new HashSet<Owner>();
            Works1 = new HashSet<Work>();
        }

        public int Id { get; set; }

        public int RootId { get; set; }

        public int? ParentId { get; set; }

        public byte Level { get; set; }

        [Required]
        [StringLength(100)]
        public string Path { get; set; }

        public int? GlobalIndex { get; set; }

        [Required]
        [StringLength(30)]
        public string GlobalCode { get; set; }

        public int? AreaIndex { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Title { get; set; }

        [Required]
        [StringLength(700)]
        public string PlainTitle { get; set; }

        public bool IsRelatedRights { get; set; }

        [Required]
        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [StringLength(255)]
        public string Media { get; set; }

        public bool IsRepresentative { get; set; }

        public int Published { get; set; }

        public DateTime? PublishedDate { get; set; }

        [Required]
        [StringLength(255)]
        public string PublishedLocation { get; set; }

        public DateTime? CompletedDate { get; set; }

        public short Status { get; set; }

        public int CreatedReasion { get; set; }

        [Required]
        [StringLength(255)]
        public string ChangeFromPreviousDescription { get; set; }

        [Required]
        [StringLength(255)]
        public string ChangeToNextDescription { get; set; }

        [Required]
        [StringLength(1000)]
        public string Note { get; set; }

        public int WorkAreaId { get; set; }

        public int CreatedAreaId { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ApprovedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Department Department { get; set; }

        public virtual Department Department1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Authors { get; set; }

        public virtual Category Category { get; set; }

        public virtual Certificate Certificate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Owner> Owners { get; set; }

        public virtual RevokedDecision RevokedDecision { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Work> Works1 { get; set; }

        public virtual Work Work1 { get; set; }
    }
}
