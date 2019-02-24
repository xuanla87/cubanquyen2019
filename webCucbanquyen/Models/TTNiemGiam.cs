using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webCucbanquyen.Models
{
    public class TTNiemGiam
    {
        public int IdTacPham { get; set; }
        public string TenTacPham { get; set; }
        public string SoChungNhan { get; set; }
        public string TenTacGia { get; set; }
        public string TenDaiDien { get; set; }
        public DateTime NgayDangKy { get; set; }
    }

    public class TotalTTNienGiam
    {
        public IEnumerable<TTNiemGiam> TTNiemGiam { get; set; }
        public IEnumerable<TTNiemGiam> TTNiemGiam2 { get; set; }
    }
}