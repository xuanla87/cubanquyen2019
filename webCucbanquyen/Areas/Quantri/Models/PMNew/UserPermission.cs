namespace webCucbanquyen.Areas.Quantri.Models.PMNew
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CORE.UserPermissions")]
    public partial class UserPermission
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Username { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(120)]
        public string Permission { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        public virtual User User { get; set; }
    }
}
