namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COV.Authors")]
    public partial class Author
    {
        public int Id { get; set; }

        public int WorkId { get; set; }

        public int? NationalityId { get; set; }

        [Required]
        [StringLength(300)]
        public string FullName { get; set; }

        public int? BirthYear { get; set; }

        public int? DeathYear { get; set; }

        [Required]
        [StringLength(50)]
        public string PassportNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PassportDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PassportLocation { get; set; }

        [Required]
        [StringLength(300)]
        public string Address { get; set; }

        public int? ProvinceId { get; set; }

        public int SortOrder { get; set; }

        public virtual National National { get; set; }

        public virtual Province Province { get; set; }

        public virtual Work Work { get; set; }
    }
}
