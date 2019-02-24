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
    public class ChuyenMucsController : Controller
    {
        IVideoService _Service;
        ICategoryService _categoryService;
        IDocumentTypeService _documentTypeService;
        IDocumentService _documentService;
        IMenuService _menuService;
        IPostService _postService;
        public ChuyenMucsController(IVideoService service, IDocumentService documentService, IPostService postService, IMenuService menuService, ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._Service = service;
            this._documentTypeService = documentTypeService;
            this._menuService = menuService;
            this._documentService = documentService;
            this._postService = postService;
        }

        //[OutputCache(Duration = 28800,  Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index(string pageUrl)
        {
            var model = new Category();
            if (!string.IsNullOrEmpty(pageUrl))
            {
                model = _categoryService.GetByUrl(pageUrl);
                ViewBag.Title = model?.categoryName ?? null;
                ViewBag.Url = model?.categoryUrl ?? null;
                if (model != null)
                {
                    var etintuc = _postService.All(null, model.categoryId, false, null, null, null, null, 1);
                    var vanban = _documentService.GetAllByCategoryId(model.categoryId);
                    ViewBag.TinTuc = etintuc?.Posts ?? new List<Post>();
                }
                else
                {
                    ViewBag.TinTuc = new List<Post>();
                }

            }
            return View(model);
        }

        public ActionResult subChuyenmuc(int? id)
        {
            if (id.HasValue)
            {
                var model = _categoryService.GetAllByParentId(id.Value);
                return PartialView(model);
            }
            else
            {
                var model = new List<Category>();
                return PartialView(model);
            }
        }
    }
}