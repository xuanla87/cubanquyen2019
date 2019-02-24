namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int menuId { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name ="Tên menu")]
        public string menuName { get; set; }

        [StringLength(256)]
        [Display(Name = "Đường dẫn")]
        public string menuUrl { get; set; }

        [Display(Name = "Sắp xếp")]
        public int sortOrder { get; set; }

        public bool isTrash { get; set; }

        [Display(Name = "Menu cha")]
        public int? parentId { get; set; }

        [StringLength(50)]
        public string taget { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public int languageId { get; set; }
    }
}
