using CucbanquyenModel.Models;
using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webCucbanquyen.Models;

namespace webCucbanquyen.Controllers
{
    public class HomeController : Controller
    {
        private IVideoService _Service;
        private ICategoryService _categoryService;
        private readonly IDocumentTypeService _documentTypeService;
        private IMenuService _menuService;
        private IPostService _postService;
        private readonly ISliderService _sliderService;
        private IDetailSilderService _detailSilderService;
        private IConfigSystemService _configService;
        private HttpCookie languagecode;
        public HomeController(IVideoService service, IConfigSystemService configService, IDetailSilderService detailSilderService, ISliderService sliderService, IPostService postService, IMenuService menuService, ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            _categoryService = categoryService;
            _Service = service;
            _documentTypeService = documentTypeService;
            _menuService = menuService;
            _postService = postService;
            _sliderService = sliderService;
            _detailSilderService = detailSilderService;
            _configService = configService;

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
                IEnumerable<Video> result = _Service.GetAll().Where(x => x.isTrash == false && x.languageId == 2).Take(20);
                return PartialView(result);
            }
            else
            {
                IEnumerable<Video> result = _Service.GetAll().Where(x => x.isTrash == false && x.languageId == 1).Take(20);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
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
                IEnumerable<Post> result = _postService.GetAll().Where(x => x.newFlag == true && x.isTrash == false && x.languageId == 2).OrderByDescending(x => x.updateTime).Take(5);
                return PartialView(result);
            }
            else
            {
                IEnumerable<Post> result = _postService.GetAll().Where(x => x.newFlag == true && x.isTrash == false && x.languageId == 1).OrderByDescending(x => x.updateTime).Take(5);
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
                    Category chuyenmuc = _categoryService.GetById(id.Value);
                    ViewBag.Name = chuyenmuc?.categoryName ?? null;
                    ViewBag.Url = chuyenmuc?.categoryUrl ?? null;
                    IEnumerable<Post> result = _postService.GetAll().Where(x => x.categoryId == id && x.isTrash == false && x.languageId == 2).OrderByDescending(x => x.updateTime).Take(4);
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
                    Category chuyenmuc = _categoryService.GetById(id.Value);
                    ViewBag.Name = chuyenmuc?.categoryName ?? null;
                    ViewBag.Url = chuyenmuc?.categoryUrl ?? null;
                    IEnumerable<Post> result = _postService.GetAll().Where(x => x.categoryId == id && x.isTrash == false && x.languageId == 1).OrderByDescending(x => x.updateTime).Take(4);
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
            {
                try { id = Convert.ToInt16(_configService.GetByName("Box2").configBody); } catch { }
            }

            if (id.HasValue)
            {
                Category chuyenmuc = _categoryService.GetById(id.Value);
                ViewBag.Name = chuyenmuc?.categoryName ?? null;
                ViewBag.Url = chuyenmuc?.categoryUrl ?? null;
                IEnumerable<Post> result = _postService.GetAll().Where(x => x.categoryId == id && x.isTrash == false && x.languageId == languageId).OrderByDescending(x => x.updateTime).Take(6);
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
            {
                try { id = Convert.ToInt16(_configService.GetByName("Box3").configBody); } catch { }
            }

            if (id.HasValue)
            {
                Category chuyenmuc = _categoryService.GetById(id.Value);
                ViewBag.Name = chuyenmuc?.categoryName ?? null;
                ViewBag.Url = chuyenmuc?.categoryUrl ?? null;
                IEnumerable<Post> result = _postService.GetAll().Where(x => x.categoryId == id && x.isTrash == false && x.languageId == languageId).OrderByDescending(x => x.updateTime).Take(6);
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
            {
                languageId = 2;
            }

            IEnumerable<Post> result = _postService.GetAll().Where(x => x.isTrash == false && x.languageId == languageId).OrderByDescending(x => x.postView).Take(5);
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
                    IEnumerable<SliderDetail> result = _detailSilderService.GetAllBySliderId(id.Value);
                    return PartialView(result);
                }
                else
                {
                    List<SliderDetail> result = new List<SliderDetail>();
                    return PartialView(result);
                }
            }
            else
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("GioiThieuTacPham").configBody); } catch { }
                if (id.HasValue)
                {
                    IEnumerable<SliderDetail> result = _detailSilderService.GetAllBySliderId(id.Value);
                    return PartialView(result);
                }
                else
                {
                    List<SliderDetail> result = new List<SliderDetail>();
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
                    IEnumerable<SliderDetail> result = _detailSilderService.GetAllBySliderId(id.Value);
                    return PartialView(result);
                }
                else
                {
                    List<SliderDetail> result = new List<SliderDetail>();
                    return PartialView(result);
                }
            }
            else
            {
                int? id = null;
                try { id = Convert.ToInt16(_configService.GetByName("BoxRight3").configBody); } catch { }
                if (id.HasValue)
                {
                    IEnumerable<SliderDetail> result = _detailSilderService.GetAllBySliderId(id.Value);
                    return PartialView(result);
                }
                else
                {
                    List<SliderDetail> result = new List<SliderDetail>();
                    return PartialView(result);
                }
            }
        }

        public ActionResult BoxRight4()
        {

            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                string result = _configService.GetByName("BoxRight4en")?.configBody ?? null;
                ViewBag.Link4 = result;
            }
            else
            {
                string result = _configService.GetByName("BoxRight4")?.configBody ?? null;
                ViewBag.Link4 = result;
            }
            return PartialView();
        }

        public ActionResult Footer()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                string result = _configService.GetByName("Footeren")?.configBody ?? null;
                ViewBag.Footer = result ?? null;
            }
            else
            {
                string result = _configService.GetByName("Footer")?.configBody ?? null;
                ViewBag.Footer = result ?? null;
            }
            return PartialView();
        }

        public ActionResult Banner()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ConfigSystem result = _configService.GetByName("Banneren");
                return PartialView(result);
            }
            else
            {
                ConfigSystem result = _configService.GetByName("Banner");
                return PartialView(result);
            }
        }

        public ActionResult HitCounterTotal()
        {
            HitCounterEntity db = new HitCounterEntity();
            List<Visiter> result = db.Visiters.ToList();
            long _total = result.Count;
            _total += 31538606;
            string hit = "000000000";
            if (_total < 1000000000 && _total >= 100000000)
            {
                hit = _total.ToString();
            }

            if (_total < 100000000 && _total >= 10000000)
            {
                hit = "0" + _total.ToString();
            }

            if (_total < 10000000 && _total >= 1000000)
            {
                hit = "00" + _total.ToString();
            }

            if (_total < 1000000 && _total >= 100000)
            {
                hit = "000" + _total.ToString();
            }

            if (_total < 100000 && _total >= 10000)
            {
                hit = "0000" + _total.ToString();
            }

            if (_total < 10000 && _total >= 1000)
            {
                hit = "00000" + _total.ToString();
            }

            if (_total < 1000 && _total >= 100)
            {
                hit = "000000" + _total.ToString();
            }

            if (_total < 100 && _total >= 10)
            {
                hit = "0000000" + _total.ToString();
            }

            if (_total < 10 && _total >= 1)
            {
                hit = "00000000" + _total.ToString();
            }

            string outST = "";
            for (int i = 0; i < hit.Length; i++)
            {
                outST += "<span class=\"num\">" + hit[i] + "</span>";
            }
            ViewBag.TotalHitcounter = outST;
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ViewBag.LanguageId = 2;
            }
            else
            {
                ViewBag.LanguageId = 1;
            }

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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
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
                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
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
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu4en").configBody); } catch { }
                if (id.HasValue)
                {
                    Menu entity = _menuService.GetById(id.GetValueOrDefault());
                    if (entity != null)
                    {
                        ViewBag.Name = entity.menuName;
                    }

                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 2).OrderBy(x => x.sortOrder);
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
                try { id = Convert.ToInt16(_configService.GetByName("RightMenu4").configBody); } catch { }
                if (id.HasValue)
                {
                    Menu entity = _menuService.GetById(id.GetValueOrDefault());
                    if (entity != null)
                    {
                        ViewBag.Name = entity.menuName;
                    }

                    IOrderedEnumerable<Menu> result = _menuService.GetAll().Where(x => x.parentId == id && x.isTrash == false && x.languageId == 1).OrderBy(x => x.sortOrder);
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
                Cookie = new HttpCookie("languagecode")
                {
                    Value = code
                };
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
                Cookie = new HttpCookie("languagecode")
                {
                    Value = code
                };
                HttpContext.Response.Cookies.Add(Cookie);
                Cookie.Expires = DateTime.Now.AddDays(5);

            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult searchregisteredWorks()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ViewBag.LanguageId = 2;
            }
            else
            {
                ViewBag.LanguageId = 1;
            }

            return PartialView();
        }

        public ActionResult viewLaguage()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ViewBag.LanguageId = 2;
            }
            else
            {
                ViewBag.LanguageId = 1;
            }

            return PartialView();
        }

        public ActionResult viewQuestionAnswer()
        {
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                ViewBag.LanguageId = 2;
            }
            else
            {
                ViewBag.LanguageId = 1;
            }

            return PartialView();
        }

        public ActionResult viewTime()
        {
            DateTime _time = DateTime.Now;
            string _stTime = null;
            languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                _stTime = _time.DayOfWeek.ToString();
            }
            else
            {
                if (_time.DayOfWeek == DayOfWeek.Monday)
                    _stTime = "Thứ 2";
                else if (_time.DayOfWeek == DayOfWeek.Tuesday)
                    _stTime = "Thứ 3";
                else if (_time.DayOfWeek == DayOfWeek.Wednesday)
                    _stTime = "Thứ 4";
                else if (_time.DayOfWeek == DayOfWeek.Thursday)
                    _stTime = "Thứ 5";
                else if (_time.DayOfWeek == DayOfWeek.Friday)
                    _stTime = "Thứ 6";
                else if (_time.DayOfWeek == DayOfWeek.Saturday)
                    _stTime = "Thứ 7";
                else if (_time.DayOfWeek == DayOfWeek.Sunday)
                    _stTime = "Chủ nhật";
            }
            _stTime += ", " + _time.ToString("dd/MM/yyyy");
            ViewBag.TimePage = _stTime;
            return PartialView();
        }
    }
}