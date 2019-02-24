using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webCucbanquyen.Areas.Quantri.Models
{
    public class SettingModel
    {
        [Display(Name = "BoxLeft")]
        public string Box1 { get; set; }

        [Display(Name = "BoxLeft2")]
        public string Box2 { get; set; }

        [Display(Name = "BoxLeft3")]
        public string Box3 { get; set; }

        [Display(Name = "BoxLeft4")]
        public string GioiThieuTacPham { get; set; }

        [Display(Name = "Footer")]
        public string Footer { get; set; }

        [Display(Name = "Main Menu")]
        public string MainMenu { get; set; }

        [Display(Name = "BoxRight1")]
        public string RightMenu { get; set; }

        [Display(Name = "BoxRight2")]
        public string LienKetWebsite { get; set; }

        [Display(Name = "BoxRight3")]
        public string BoxRight3 { get; set; }

        [Display(Name = "BoxRight4")]
        public string BoxRight4 { get; set; }

        [Display(Name = "RightMenu2")]
        public string RightMenu2 { get; set; }

        [Display(Name = "RightMenu3")]
        public string RightMenu3 { get; set; }
        [Display(Name = "HIẾN TẶNG NHÀ NƯỚC, CÔNG CHÚNG")]
        public string RightMenu4 { get; set; }

        [Display(Name = "Banner")]
        public string Banner { get; set; }

        [Display(Name = "BoxLeft")]
        public string Box1en { get; set; }

        [Display(Name = "BoxLeft2")]
        public string Box2en { get; set; }

        [Display(Name = "BoxLeft3")]
        public string Box3en { get; set; }

        [Display(Name = "BoxLeft4")]
        public string GioiThieuTacPhamen { get; set; }

        [Display(Name = "Footer")]
        public string Footeren { get; set; }

        [Display(Name = "Main Menu")]
        public string MainMenuen { get; set; }

        [Display(Name = "BoxRight1")]
        public string RightMenuen { get; set; }

        [Display(Name = "BoxRight2")]
        public string LienKetWebsiteen { get; set; }

        [Display(Name = "BoxRight3")]
        public string BoxRight3en { get; set; }

        [Display(Name = "BoxRight4")]
        public string BoxRight4en { get; set; }

        [Display(Name = "RightMenu2")]
        public string RightMenu2en { get; set; }

        [Display(Name = "RightMenu3")]
        public string RightMenu3en { get; set; }

        [Display(Name = "HIẾN TẶNG NHÀ NƯỚC, CÔNG CHÚNG")]
        public string RightMenu4en { get; set; }

        [Display(Name = "Banner")]
        public string Banneren { get; set; }
    }
}