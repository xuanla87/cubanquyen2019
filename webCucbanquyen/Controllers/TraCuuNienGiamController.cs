using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using webCucbanquyen.Areas.Quantri.Models;
using webCucbanquyen.Areas.Quantri.Models.PMNew;
using webCucbanquyen.Models;
namespace webCucbanquyen.Controllers
{
    public class TraCuuNienGiamController : Controller
    {
        private readonly Tracuuniengiam _db;
        private readonly PMNews _db2;
        HttpCookie languagecode;
        public TraCuuNienGiamController()
        {
            _db = new Tracuuniengiam();
            _db2 = new PMNews();
        }
        //[OutputCache(Duration = 28800, Location = OutputCacheLocation.Server)]
        public ActionResult Index(DateTime? fromDate, DateTime? toDate, string name, string number, string nameAuthor, string nameOwner, string tab, int? pageIndex)
        {
            IEnumerable<View_TTniengiam> model; ;
            IEnumerable<Work> model2;
            model = _db.View_TTniengiam;
            model2 = _db2.Works;
            if (!fromDate.HasValue && !toDate.HasValue && name == null && nameAuthor == null && nameAuthor == null)
            {
                model = new List<View_TTniengiam>();
                model2 = new List<Work>();
            }

            if (fromDate.HasValue)
            {
                model = model.Where(x => x.ngaycap.Date >= fromDate.Value.Date);
                model2 = model2.Where(x => x.CreatedDate.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                model = model.Where(x => x.ngaycap.Date <= toDate.Value.Date);
                model2 = model2.Where(x => x.CreatedDate.Date <= toDate.Value.Date);
            }
            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(x => ConvertFont.TCVN3ToUnicode(x.tacpham).ToLower().Contains(name.ToLower().Trim()));
                model2 = model2.Where(x => x.Title.ToLower().Contains(name.ToLower().Trim()));
            }
            if (!string.IsNullOrEmpty(number))
            {
                model = model.Where(x => ConvertFont.TCVN3ToUnicode(x.sochungnhan).ToLower().Contains(number.ToLower().Trim()));
                model2 = model2.Where(x => ConvertFont.TCVN3ToUnicode(x.GlobalCode).ToLower().Contains(number.ToLower().Trim()));
            }
            if (!string.IsNullOrEmpty(nameOwner))
            {
                model = model.Where(x => ConvertFont.TCVN3ToUnicode(x.tendaidien).ToLower().Contains(nameOwner.ToLower().Trim()));
                model2 = (from q in model2
                          join p in _db2.Owners on q.Id equals p.WorkId
                          where p.FullName.ToLower().Contains(nameOwner.ToLower().Trim())
                          select q);
            }
            if (!string.IsNullOrEmpty(nameAuthor))
            {
                model = model.Where(x => ConvertFont.TCVN3ToUnicode(x.IDquoctich_tg).ToLower().Contains(nameAuthor.ToLower().Trim()));
                model2 = (from q in model2
                          join p in _db2.Owners on q.Id equals p.WorkId
                          where p.FullName.ToLower().Contains(nameAuthor.ToLower().Trim())
                          select q);
            }

            var query = model;
            var query2 = model2.AsEnumerable();
            var result = query.Select(x => new TTNiemGiam
            {
                IdTacPham = 0,
                NgayDangKy = x.ngaycap,
                SoChungNhan = ConvertFont.TCVN3ToUnicode(x.sochungnhan),
                TenDaiDien = ConvertFont.TCVN3ToUnicode(x.daidien),
                TenTacGia = ConvertFont.TCVN3ToUnicode(x.IDquoctich_tg),
                TenTacPham = ConvertFont.TCVN3ToUnicode(x.tacpham)
            });
            var result2 = query2.Select(x => new TTNiemGiam
            {
                IdTacPham = 1,
                NgayDangKy = x.CreatedDate,
                SoChungNhan = x.GlobalCode,
                TenDaiDien = _db2.Owners.FirstOrDefault(c => c.WorkId == x.Id)?.FullName ?? null,
                TenTacGia = _db2.Owners.FirstOrDefault(c => c.WorkId == x.Id)?.FullName ?? null,
                TenTacPham = x.Title
            });
            var resultTotal = new List<TTNiemGiam>();
            try { resultTotal.AddRange(result2); }
            catch (Exception) { }
            try { resultTotal.AddRange(result); }
            catch (Exception ex) { }
            resultTotal = resultTotal.OrderByDescending(x => x.NgayDangKy).ToList();
            int totalPage = 0;
            int? pageSize = 20;
            var totalRecord = resultTotal.Count();
            var QueryTotal = resultTotal;
            if (pageIndex != null && pageSize != null)
            {
                if (pageIndex.Value == 0)
                {
                    pageIndex = 1;
                }
                QueryTotal = QueryTotal.Skip(((int)pageIndex - 1) * (int)pageSize).ToList();
            }
            if (pageSize != null)
            {
                totalPage = (totalRecord / pageSize.Value) + 1;
                totalPage = totalRecord == pageSize.Value ? 1 : totalPage;
                QueryTotal = QueryTotal.Take((int)pageSize).ToList();
            }
            ViewBag.name = name;
            ViewBag.nameAuthor = nameAuthor;
            ViewBag.nameOwner = nameOwner;
            ViewBag.number = number;
            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;
            ViewBag.PageIndex = pageIndex ?? 1;
            ViewBag.TotalPage = totalPage;
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ViewBag.Title = "Yearbook lookup system";
                ViewBag.Time = "Registration time:";
                ViewBag.From = "From Date:";
                ViewBag.To = "To Date:";
                ViewBag.Info = "Information about the work:";
                ViewBag.NameTacPham = "Name of the work:";
                ViewBag.TNumber = "Certification Number:";
                ViewBag.InfoAuthor = "Information about the author:";
                ViewBag.InfoOwner = "Information about the owner:";
                ViewBag.Author = "FullName:";
                ViewBag.Owner = "FullName:";
            }

            else
            {
                ViewBag.Title = "Hệ thống tra cứu niên giám";
                ViewBag.Time = "Thời gian đăng ký:";
                ViewBag.From = "Từ ngày:";
                ViewBag.To = "Đến ngày:";
                ViewBag.Info = "Thông tin về tác phẩm:";
                ViewBag.NameTacPham = "Tên tác phẩm:";
                ViewBag.TNumber = "Số chứng nhận:";
                ViewBag.InfoAuthor = "Thông tin về tác giả:";
                ViewBag.InfoOwner = "Thông tin về chủ sở hữu:";
                ViewBag.Author = "Họ tên:";
                ViewBag.Owner = "Họ tên:";
            }
            return View(QueryTotal);
        }
    }

}