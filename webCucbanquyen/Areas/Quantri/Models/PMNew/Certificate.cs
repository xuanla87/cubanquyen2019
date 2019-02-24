namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COV.Certificates")]
    public partial class Certificate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CertificateNo { get; set; }

        public DateTime CertificateDate { get; set; }

        public int? CertificatedObjects { get; set; }

        public int? ProgramTypeId { get; set; }

        public int? LicensorId { get; set; }

        [Required]
        [StringLength(700)]
        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Licensor Licensor { get; set; }

        public virtual ProgramType ProgramType { get; set; }

        public virtual Work Work { get; set; }
    }
}
