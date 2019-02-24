namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        public int sliderId { get; set; }

        [Required]
        [StringLength(256)]
        public string sliderName { get; set; }

        public string sliderBody { get; set; }

        public bool isTrash { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public virtual IEnumerable<SliderDetail> SliderDetails { set; get; }
    }

    public class SliderView
    {
        public int Total { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}
