namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SliderDetail")]
    public partial class SliderDetail
    {
        [Key]
        public int detailId { get; set; }

        public int sliderId { get; set; }

      
        [StringLength(256)]
        [Required]
        public string sliderTitle { get; set; }

        [StringLength(512)]
        public string sliderNote { get; set; }

        [StringLength(256)]
        public string sliderLink { get; set; }

        [Required]
        [StringLength(256)]
        public string detailUrl { get; set; }

        public int sliderType { get; set; }

        [ForeignKey("sliderId")]
        public virtual Slider Slider { set; get; }
    }
}
