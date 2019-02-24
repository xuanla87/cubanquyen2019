using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CucbanquyenModel.Models;
using CucbanquyenService;
using webCucbanquyen.Areas.Quantri.Models;
using System.Web.UI;
using webCucbanquyen.Models;

namespace webCucbanquyen.Controllers
{
    public class HomeController : Controller
    {
        IVideoService _Service;
        ICategoryService _categoryService;
        IDocumentTypeService _documentTypeService;
        IMenuService _menuService;
        IPostService _postService;
        ISliderService _sliderService;
        IDetailSilderService _detailSilderService;
        IConfigSystemService _configService;
        HttpCookie languagecode;
        public HomeController(IVideoService service, IConfigSystemService configService, IDetailSilderService detailSilderService, ISliderService sliderService, IPostService postService, IMenuService menuService, ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._Service = service;
            this._documentTypeService = documentTypeService;
            this._menuService = menuService;
            this._postService = postService;
            this._sliderService = sliderService;
            this._detailSilderService = detailSilderService;
            this._configService = configService;

        }

        //[OutputCache(Duration = 28800, Location = OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ViewBag.Title = "Home";
                ViewBag.Title2 = "Introducing the work";
            }
               
            else
            {
                ViewBag.Title2 = "Giới thiệu tác phẩm";
                ViewBag.Title = "Trang chủ";
            }
               
            return View();
        }

        public ActionResult boxVideo()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                var result = _Service.GetAll().Where(x => x.isTrash == false && x.languageId == 2).Take(20);
                return PartialView(result);
            }
            else
            {
                var result = _Service.GetAll().Where(x => x.isTrash == false && x.languageId == 1).Take(20);
                return PartialView(result);
            }
        }

        public ActionResult menuHasSub(string stClass)
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("MainMenuen").configBody); } catch { id = null; }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
            else
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("MainMenu").configBody); } catch { id = null; }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }


        }

        public ActionResult menuSub(int? id, string stClass)
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
            else
            {
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }


        }

        public ActionResult menuNoSub(string stClass)
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ViewBag.Name = "Administrative Procedure:<br/> Register Copyright, Related Rights";
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("RightMenuen").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
            else
            {
                ViewBag.Name = "Thủ tục hành chính:<br/> Đăng ký Quyền tác giả, Quyền liên quan";
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }

        }

        public ActionResult LienKetWebsite(string stClass)
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ViewBag.Name = "LINKS TO WEBSITE";
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("LienKetWebsiteen").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
            else
            {
                ViewBag.Name = "Liên kết WEBSITE";
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("LienKetWebsite").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }

        }

        public ActionResult box1()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                var result = _postService.GetAll().Where(x => x.newFlag == true && x.isTrash == false && x.languageId == 2).OrderByDescending(x => x.updateTime).Take(5);
                return PartialView(result);
            }
            else
            {
                var result = _postService.GetAll().Where(x => x.newFlag == true && x.isTrash == false && x.languageId == 1).OrderByDescending(x => x.updateTime).Take(5);
                return PartialView(result);
            }
        }

        public ActionResult box2()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("Box1en").configBody); } catch { }
                if (id.HasValue)
                {
                    var chuyenmuc = _categoryService.GetById(id.Value);
                    ViewBag.Name = chuyenmuc?.categoryName ?? null;
                    ViewBag.Url = chuyenmuc?.categoryUrl ?? null;
                    var result = _postService.GetAll().Where(x => x.categoryId == id && x.isTrash == false && x.languageId == 2).OrderByDescending(x => x.updateTime).Take(4);
                    return PartialView(result);
                }
                else
                {
                    return PartialView(null);
                }
            }
            else
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("Box1").configBody); } catch { }
                if (id.HasValue)
                {
                    var chuyenmuc = _categoryService.GetById(id.Value);
                    ViewBag.Name = chuyenmuc?.categoryName ?? null;
                    ViewBag.Url = chuyenmuc?.categoryUrl ?? null;
                    var result = _postService.GetAll().Where(x => x.categoryId == id && x.isTrash == false && x.languageId == 1).OrderByDescending(x => x.updateTime).Take(4);
                    return PartialView(result);
                }
                else
                {
                    return PartialView(null);
                }
            }

        }

        public ActionResult box3()
        {
            int? id = null;
            languagecode = HttpContext.Request.Cookies["languagecode"];
            int languageId = 1;
            if (languagecode != null && languagecode.Value == "en")
            {
                languageId = 2;
                try { id = Convert.ToInt16(_configService.GetByName("Box2en").configBody); } catch { }
            }
            else
                try { id = Convert.ToInt16(_configService.GetByName("Box2").configBody); } catch { }
            if (id.HasValue)
            {
                var chuyenmuc = _categoryService.GetById(id.Value);
                ViewBag.Name = chuyenmuc?.categoryName ?? null;
                ViewBag.Url = chuyenmuc?.categoryUrl ?? null;
                var result = _postService.GetAll().Where(x => x.categoryId == id && x.isTrash == false && x.languageId == languageId).OrderByDescending(x => x.updateTime).Take(6);
                return PartialView(result);
            }
            else
            {
                return PartialView(null);
            }
        }

        public ActionResult box4()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            int languageId = 1;
            int? id = null;
            if (languagecode != null && languagecode.Value == "en")
            {
                languageId = 2;
                try { id = Convert.ToInt16(_configService.GetByName("Box3en").configBody); } catch { }
            }
            else
                try { id = Convert.ToInt16(_configService.GetByName("Box3").configBody); } catch { }
            if (id.HasValue)
            {
                var chuyenmuc = _categoryService.GetById(id.Value);
                ViewBag.Name = chuyenmuc?.categoryName ?? null;
                ViewBag.Url = chuyenmuc?.categoryUrl ?? null;
                var result = _postService.GetAll().Where(x => x.categoryId == id && x.isTrash == false && x.languageId == languageId).OrderByDescending(x => x.updateTime).Take(6);
                return PartialView(result);
            }
            else
            {
                return PartialView(null);
            }
        }

        public ActionResult tinDocNhieu()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            int languageId = 1;
            if (languagecode != null && languagecode.Value == "en")
                languageId = 2;
            var result = _postService.GetAll().Where(x => x.isTrash == false && x.languageId == languageId).OrderByDescending(x => x.postView).Take(5);
            ViewBag.LanguageId = languageId;
            return PartialView(result);
        }

        public ActionResult Slider()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("GioiThieuTacPhamen").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _detailSilderService.GetAllBySliderId(id.Value);
                    return PartialView(result);
                }
                else
                {
                    var result = new List<SliderDetail>();
                    return PartialView(result);
                }
            }
            else
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("GioiThieuTacPham").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _detailSilderService.GetAllBySliderId(id.Value);
                    return PartialView(result);
                }
                else
                {
                    var result = new List<SliderDetail>();
                    return PartialView(result);
                }
            }

        }

        public ActionResult BoxRight3()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("BoxRight3en").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _detailSilderService.GetAllBySliderId(id.Value);
                    return PartialView(result);
                }
                else
                {
                    var result = new List<SliderDetail>();
                    return PartialView(result);
                }
            }
            else
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("BoxRight3").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _detailSilderService.GetAllBySliderId(id.Value);
                    return PartialView(result);
                }
                else
                {
                    var result = new List<SliderDetail>();
                    return PartialView(result);
                }
            }
        }

        public ActionResult BoxRight4()
        {

            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                var result = _configService.GetByName("BoxRight4en")?.configBody ?? null;
                ViewBag.Link4 = result;
            }
            else
            {
                var result = _configService.GetByName("BoxRight4")?.configBody ?? null;
                ViewBag.Link4 = result;
            }
            return PartialView();
        }

        public ActionResult Footer()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                var result = _configService.GetByName("Footeren")?.configBody ?? null;
                ViewBag.Footer = result ?? null;
            }
            else
            {
                var result = _configService.GetByName("Footer")?.configBody ?? null;
                ViewBag.Footer = result ?? null;
            }
            return PartialView();
        }

        public ActionResult Banner()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                var result = _configService.GetByName("Banneren");
                return PartialView(result);
            }
            else
            {
                var result = _configService.GetByName("Banner");
                return PartialView(result);
            }
        }

        public ActionResult HitCounterTotal()
        {
            HitCounterEntity db = new HitCounterEntity();
            var result = db.Visiters.ToList();

            string hit = "000000000";
            if (result.Count < 1000000000 && result.Count >= 100000000)
                hit = result.Count.ToString();
            if (result.Count < 100000000 && result.Count >= 10000000)
                hit = "0" + result.Count.ToString();
            if (result.Count < 10000000 && result.Count >= 1000000)
                hit = "00" + result.Count.ToString();
            if (result.Count < 1000000 && result.Count >= 100000)
                hit = "000" + result.Count.ToString();
            if (result.Count < 100000 && result.Count >= 10000)
                hit = "0000" + result.Count.ToString();
            if (result.Count < 10000 && result.Count >= 1000)
                hit = "00000" + result.Count.ToString();
            if (result.Count < 1000 && result.Count >= 100)
                hit = "000000" + result.Count.ToString();
            if (result.Count < 100 && result.Count >= 10)
                hit = "0000000" + result.Count.ToString();
            if (result.Count < 10 && result.Count >= 1)
                hit = "00000000" + result.Count.ToString();
            string outST = "";
            for (int i = 0; i < hit.Length; i++)
            {
                outST += "<span class=\"num\">" + hit[i] + "</span>";
            }
            ViewBag.TotalHitcounter = outST;
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
                ViewBag.LanguageId = 2;
            else
                ViewBag.LanguageId = 1;
            return PartialView();
        }

        public ActionResult menuNoSub2(string stClass)
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu2en").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
            else
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu2").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
        }

        public ActionResult menuNoSub3(string stClass)
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu3en").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
            else
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu3").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
        }

        public ActionResult menuNoSub4(string stClass)
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                int? id = null;
                ViewBag.Name = "PROMOTION OF THE STATE, THE PUBLIC";
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu4en").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }

            }
            else
            {
                ViewBag.Name = "HIẾN TẶNG NHÀ NƯỚC, CÔNG CHÚNG";
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu4").configBody); } catch { }
                if (id.HasValue)
                {
                    var result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
                    ViewBag.stclass = stClass;
                    return PartialView(result);
                }
                else
                {
                    ViewBag.stclass = stClass;
                    return PartialView(null);
                }
            }
        }
        public ActionResult setLanguage(string code)
        {
            HttpCookie Cookie = HttpContext.Request.Cookies["languagecode"];
            if (string.IsNullOrEmpty(code))
            {
                code = "'vn";
            }
            if (Cookie == null)
            {
                Cookie = new HttpCookie("languagecode");
                Cookie.Value = code;
                HttpContext.Response.Cookies.Add(Cookie);
                Cookie.Expires = DateTime.Now.AddDays(5);
                if (code == "vn")
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (code == Cookie.Value)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                Cookie = new HttpCookie("languagecode");
                Cookie.Value = code;
                HttpContext.Response.Cookies.Add(Cookie);
                Cookie.Expires = DateTime.Now.AddDays(5);

            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult searchregisteredWorks()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
                ViewBag.LanguageId = 2;
            else
                ViewBag.LanguageId = 1;
            return PartialView();
        }

        public ActionResult viewLaguage()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
                ViewBag.LanguageId = 2;
            else
                ViewBag.LanguageId = 1;
            return PartialView();
        }

        public ActionResult viewQuestionAnswer()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
                ViewBag.LanguageId = 2;
            else
                ViewBag.LanguageId = 1;
            return PartialView();
        }
    }
}