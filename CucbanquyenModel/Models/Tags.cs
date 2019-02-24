namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tags")]
    public partial class Tags
    {
        public int tagsId { get; set; }

        [Required]
        [StringLength(256)]
        public string tagsName { get; set; }

        public bool isTrash { get; set; }

        public virtual IEnumerable<TagsPost> TagsPosts { set; get; }
    }
}
