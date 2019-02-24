namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COV.RevokedDecisions")]
    public partial class RevokedDecision
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkId { get; set; }

        [Required]
        [StringLength(20)]
        public string DecisionNo { get; set; }

        public DateTime DecisionDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Reasion { get; set; }

        [Required]
        [StringLength(500)]
        public string MoreInfo { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Work Work { get; set; }
    }
}
