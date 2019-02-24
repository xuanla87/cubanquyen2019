namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TagsPost")]
    public partial class TagsPost
    {
        public int tagsId { get; set; }
        public int postId { get; set; }

        [ForeignKey("tagsId")]
        public virtual Tags Tags { set; get; }

        [ForeignKey("postId")]
        public virtual Post Posts { set; get; }
    }
}
