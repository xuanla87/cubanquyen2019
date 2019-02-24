using CucbanquyenModel.Models;
using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webCucbanquyen.Areas.Quantri.Models;

namespace webCucbanquyen.Areas.Quantri.Controllers
{

    [Authorize]
    public class QuanlyvideoController : Controller
    {
        ICategoryService _categoryService;
        IVideoService _Service;
        ToolAdmin _toolAdmin;
        IDocumentTypeService _documentTypeService;
        public QuanlyvideoController(IVideoService service, ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._Service = service;
            this._documentTypeService = documentTypeService;
            this._toolAdmin = new ToolAdmin(_categoryService, _documentTypeService);
        }
        public ActionResult Index(string searchKey, DateTime? fromDate, DateTime? toDate, int? pageIndex)
        {
            var model = _Service.All(searchKey, fromDate, false, toDate, pageIndex, 20);
            int totalPage = model?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.pageIndex = pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(searchKey) ? string.Empty : searchKey;
            ViewBag.FromDate = fromDate?.ToString("MM/dd/yyyy") ?? null;
            ViewBag.ToDate = toDate?.ToString("MM/dd/yyyy") ?? null;
            ViewBag.Quanlyvideo = "active";
            return View(model?.Videos ?? new List<Video>());
        }

        public ActionResult Add()
        {
            var model = new Video
            {
                isTrash = false,
                createTime = DateTime.Now,
                updateTime = DateTime.Now          
            };
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlyvideo = "active";
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Video model, HttpPostedFileBase fileVideo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (fileVideo.ContentLength > 0)
                    {
                        string _fileName = Path.GetFileName(fileVideo.FileName);
                        string _path = Path.Combine(Server.MapPath("~/FileVideo"), _fileName);
                        fileVideo.SaveAs(_path);
                        model.videoBody = _fileName;
                        _Service.Add(model);
                        _Service.Save();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                }
            }
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlyvideo = "active";
            return View(model);
        }
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                var model = _Service.GetById(id.Value);
                ViewBag.languageId = _toolAdmin.LanguageSelectList();
                ViewBag.Quanlyvideo = "active";
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Video model, HttpPostedFileBase fileVideo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (fileVideo != null && fileVideo.ContentLength > 0)
                    {
                        string _fileName = Path.GetFileName(fileVideo.FileName);
                        string _path = Path.Combine(Server.MapPath("~/FileVideo"), _fileName);
                        fileVideo.SaveAs(_path);
                        model.videoBody = _fileName;
                        model.updateTime = DateTime.Now;
                        _Service.Update(model);
                        _Service.Save();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        model.updateTime = DateTime.Now;
                        _Service.Update(model);
                        _Service.Save();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                }
            }
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlyvideo = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Trash(int id)
        {
            var model = _Service.GetById(id);
            if (model != null)
            {
                model.isTrash = true;
                _Service.Update(model);
                _Service.Save();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}