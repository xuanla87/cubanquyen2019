using CucbanquyenModel.Models;
using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace webCucbanquyen.Controllers
{
    public class TinTucController : Controller
    {
        IVideoService _Service;
        ICategoryService _categoryService;
        IDocumentTypeService _documentTypeService;
        IMenuService _menuService;
        IPostService _postService;
        private HttpCookie languagecode;
        public TinTucController(IVideoService service, IPostService postService, IMenuService menuService, ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._Service = service;
            this._documentTypeService = documentTypeService;
            this._menuService = menuService;
            this._postService = postService;
        }
        //[OutputCache(Duration = 28800,  Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index(string pageUrl)
        {
            if (!string.IsNullOrEmpty(pageUrl))
            {
                var model = _postService.GetByUrl(pageUrl);
                ViewBag.Detail = model ?? new Post();
                ViewBag.Title = model?.postName ?? null;
                DateTime _time = model.updateTime;
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
                _stTime += ", " + _time.ToString("dd-MM-yyyy hh:mm");
                ViewBag.PostTime = _stTime;
                model.postView = model.postView + 1;
                _postService.Update(model);
                _postService.Save();
            }
            return View();
        }
    }
}