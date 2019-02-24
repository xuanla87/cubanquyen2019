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
    public class VanBanController : Controller
    {
        IVideoService _Service;
        ICategoryService _categoryService;
        IDocumentTypeService _documentTypeService;
        IDocumentService _documentService;
        IMenuService _menuService;
        IPostService _postService;
        public VanBanController(IVideoService service, IDocumentService documentService, IPostService postService, IMenuService menuService, ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._Service = service;
            this._documentTypeService = documentTypeService;
            this._menuService = menuService;
            this._postService = postService;
            this._documentService = documentService;
        }

        //[OutputCache(Duration = 28800,  Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index(string pageUrl)
        {
            if (!string.IsNullOrEmpty(pageUrl))
            {
                var model = _documentService.GetByUrl(pageUrl);
                ViewBag.Detail = model ?? new Document();
                ViewBag.Title = model?.documentName ?? null;
            }
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Luat()
        {
            var eDocument = _documentService.GetAllByCategoryId(1);
            return PartialView(eDocument);
        }
        public ActionResult VanBanDuoiLuat(int typeId)
        {
            var eDocument = _documentService.GetAllByCategoryId(2).Where(x => x.documentTypeId == typeId);
            return PartialView(eDocument);
        }
        public ActionResult DocumentType()
        {
            var eType = _documentTypeService.GetAll();
            return PartialView(eType);
        }
    }
}