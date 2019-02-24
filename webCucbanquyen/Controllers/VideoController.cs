using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace webCucbanquyen.Controllers
{
    public class VideoController : Controller
    {
        IVideoService _Service;
        ICategoryService _categoryService;
        IDocumentTypeService _documentTypeService;
        public VideoController(IVideoService service, ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._Service = service;
            this._documentTypeService = documentTypeService;
        }

        //[OutputCache(Duration = 28800, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index(int? pageIndex)
        {
            var model = _Service.All(null, null, false, null, pageIndex, 20);
            int totalPage = model?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = pageIndex ?? 1;
            return View(model.Videos);
        }

        public ActionResult Detail(int? id)
        {
            if (id.HasValue)
            {
                var result = _Service.GetById(id.Value);
                ViewBag.Title = result?.videoTitle ?? "";
                return View(result);
            }
            return RedirectToAction("Index");
        }
    }
}