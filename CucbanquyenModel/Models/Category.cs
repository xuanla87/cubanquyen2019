namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int categoryId { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Tên chuyên mục")]
        public string categoryName { get; set; }

        [Required]
        [StringLength(256)]
        public string categoryUrl { get; set; }

        [StringLength(512)]
        [Display(Name = "Mô tả")]
        public string categoryNote { get; set; }

        [Display(Name = "Chi tiết")]
        public string categoryBody { get; set; }

        [Display(Name = "Chuyên mục cha")]
        public int? parentId { get; set; }

        public bool isTrash { get; set; }

        [Display(Name = "Sắp xếp")]
        public int sortOrder { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public int languageId { get; set; }

        [StringLength(256)]
        public string metaTitle { get; set; }

        [StringLength(256)]
        public string metakeyword { get; set; }

        [StringLength(256)]
        public string metaDescription { get; set; }

        public virtual IEnumerable<Post> Posts { set; get; }
    }
}
