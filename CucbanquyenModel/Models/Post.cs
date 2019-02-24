namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        public int postId { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name ="Tiêu đề")]
        public string postName { get; set; }

        [Required]
        [StringLength(256)]
        public string postUrl { get; set; }

        [StringLength(512)]
        [Display(Name = "Mô tả")]
        public string postNote { get; set; }

        [Display(Name = "Nội dung chi tiết")]
        public string postBody { get; set; }

        public bool isTrash { get; set; }

        public int postView { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        [Required]
        [StringLength(256)]
        public string createBy { get; set; }

        [Display(Name = "Chuyên mục")]
        public int? categoryId { get; set; }

        [StringLength(256)]
        [Display(Name = "Ảnh mô tả")]
        public string thumbnail { get; set; }

        public bool hotFlag { get; set; }

        public bool newFlag { get; set; }

        public int languageId { get; set; }

        [StringLength(256)]
        public string metaTitle { get; set; }

        [StringLength(256)]
        public string metakeyword { get; set; }

        [StringLength(256)]
        public string metaDescription { get; set; }

        public virtual IEnumerable<TagsPost> TagsPosts { set; get; }

        [ForeignKey("categoryId")]
        public virtual Category Category { set; get; }
    }

    public class PostView
    {
        public int Total { set; get; }
        public IEnumerable<Post> Posts { set; get; }
    }
}
