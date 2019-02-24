namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RelatedPost")]
    public partial class RelatedPost
    {
        public int relatedId { get; set; }

        public int postId { get; set; }

        public int id { get; set; }

    }
}
