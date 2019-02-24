
namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Video")]
    public partial class Video
    {
        public int videoId { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Tiều đề")]
        public string videoTitle { get; set; }

        [Required]
        [StringLength(512)]
        [Display(Name = "Chọn video")]
        public string videoBody { get; set; }

        [StringLength(512)]
        [Display(Name = "Mô tả")]
        public string videoDecription { get; set; }

        public bool isTrash { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public int languageId { get; set; }

        public DateTime updateTime { get; set; }

        public DateTime createTime { get; set; }

        [Display(Name = "Ảnh mô tả")]
        [StringLength(256)]
        [Required]
        public string thumbnail { get; set; }
    }

    public class VideoView
    {
        public int Total { get; set; }
        public IEnumerable<Video> Videos { get; set; }
    }

    //public class VisiterView
    //{
    //    public int Total { get; set; }
    //    public IEnumerable<Visiter> Visiters { get; set; }
    //}
}
