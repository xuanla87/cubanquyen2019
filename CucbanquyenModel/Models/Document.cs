

namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Document")]
    public partial class Document
    {
        public int documentId { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Tên văn bản")]
        public string documentName { get; set; }

        [Required]
        [StringLength(256)]
        public string documentUrl { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Số/kí hiệu")]
        public string numberCode { get; set; }

        [StringLength(512)]
        [Display(Name = "Trích yếu nội dung")]
        public string documentNote { get; set; }

        [Display(Name = "Nội dung")]
        public string documentBody { get; set; }

        public bool isTrash { get; set; }

        [Display(Name = "Ngày ban hành")]
        public DateTime issuedTime { get; set; }

        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }

        [Display(Name = "Chuyên mục")]
        public int? categoryId { get; set; }

        [Display(Name = "Loại văn bản")]
        public int? documentTypeId { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public int languageId { get; set; }
       
    }

    public class DocumentView
    {
        public int Total { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}
