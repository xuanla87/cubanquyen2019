using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webCucbanquyen.Controllers
{
    public class SearchPageController : Controller
    {
        IVideoService _Service;
        ICategoryService _categoryService;
        IDocumentTypeService _documentTypeService;
        IMenuService _menuService;
        IPostService _postService;
        IDocumentService _documentService;
        public SearchPageController(IVideoService service, IDocumentService documentService, IPostService postService, IMenuService menuService, ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._Service = service;
            this._documentTypeService = documentTypeService;
            this._menuService = menuService;
            this._postService = postService;
            this._documentService = documentService;
        }
        public ActionResult Index(string searchKey)
        {
            var languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
            {
                if (!string.IsNullOrEmpty(searchKey))
                {
                    ViewBag.SearchKey = searchKey;
                    var lnews = _postService.GetAll().Where(x => x.isTrash == false && x.languageId == 2 && x.postName.ToLower().Contains(searchKey.ToLower().Trim()));
                    var ldocument = _documentService.GetAll().Where(x => x.isTrash == false && x.languageId == 2 && x.documentName.ToLower().Contains(searchKey.ToLower().Trim()));
                    ViewBag.News = lnews;
                    ViewBag.Document = ldocument;
                    ViewBag.LanguageId = 2;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(searchKey))
                {
                    ViewBag.SearchKey = searchKey;
                    var lnews = _postService.GetAll().Where(x => x.isTrash == false && x.languageId == 1 && x.postName.ToLower().Contains(searchKey.ToLower().Trim()));
                    var ldocument = _documentService.GetAll().Where(x => x.isTrash == false && x.languageId == 1 && x.documentName.ToLower().Contains(searchKey.ToLower().Trim()));
                    ViewBag.News = lnews;
                    ViewBag.Document = ldocument;
                    ViewBag.LanguageId = 1;
                }
            }

            return View();
        }

        public ActionResult viewSearch()
        {
            var languagecode = HttpContext.Request.Cookies["languagecode"];
            if (languagecode != null && languagecode.Value == "en")
                ViewBag.LanguageId = 2;
            else
                ViewBag.LanguageId = 1;
            return PartialView();
        }
    }
}