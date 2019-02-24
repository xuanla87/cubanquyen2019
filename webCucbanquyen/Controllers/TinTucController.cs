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
                model.postView = model.postView + 1;
                _postService.Update(model);
                _postService.Save();
            }
            return View();
        }
    }
}