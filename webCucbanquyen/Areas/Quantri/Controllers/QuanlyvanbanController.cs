using CucbanquyenModel.Models;
using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webCucbanquyen.Areas.Quantri.Models;

namespace webCucbanquyen.Areas.Quantri.Controllers
{
    [Authorize]
    public class QuanlyvanbanController : Controller
    {
        ICategoryService _categoryService;
        IDocumentService _Service;
        IDocumentTypeService _documentTypeService;
        ToolAdmin _toolAdmin;
        public QuanlyvanbanController(IDocumentService service, ICategoryService categoryService, IDocumentTypeService documentTypeService)
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
            ViewBag.Quanlyvanban = "active";
            return View(model?.Documents ?? new List<Document>());
        }

        public ActionResult Add()
        {
            var model = new Document
            {
                isTrash = false,
                createTime = DateTime.Now,
                updateTime = DateTime.Now,
                issuedTime = DateTime.Now.Date,
                languageId = 1
            };
            ViewBag.documentTypeId = _toolAdmin.DocumentTypeSelectList();
            ViewBag.categoryId = _toolAdmin.DocumentTypeDropdown(model.categoryId);
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlyvanban = "active";

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Document model)
        {
            if (ModelState.IsValid)
            {
                if (!model.documentUrl.Contains("/van-ban/"))
                {
                    model.documentUrl = "/van-ban/" + model.documentUrl;
                }
                _Service.Add(model);
                _Service.Save();
                return RedirectToAction("Index");
            }
            ViewBag.documentTypeId = _toolAdmin.DocumentTypeSelectList();
            ViewBag.categoryId = _toolAdmin.DocumentTypeDropdown(model.categoryId);
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlyvanban = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                var model = _Service.GetById(id.Value);
                ViewBag.documentTypeId = _toolAdmin.DocumentTypeSelectList();
                ViewBag.categoryId = _toolAdmin.DocumentTypeDropdown(model.categoryId);
                ViewBag.languageId = _toolAdmin.LanguageSelectList();
                ViewBag.Quanlyvanban = "active";
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Document model)
        {
            if (ModelState.IsValid)
            {
                if (!model.documentUrl.Contains("/van-ban/"))
                {
                    model.documentUrl = "/van-ban/" + model.documentUrl;
                }
                model.updateTime = DateTime.Now;
                _Service.Update(model);
                _Service.Save();
                return RedirectToAction("Index");
            }
            ViewBag.documentTypeId = _toolAdmin.DocumentTypeSelectList();
            ViewBag.categoryId = _toolAdmin.DocumentTypeDropdown(model.categoryId);
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlyvanban = "active";
            return View(model);
        }

        public ActionResult ListType()
        {
            var model = _documentTypeService.GetAll();
            return View(model);
        }

        public ActionResult AddType(int? id)
        {
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlyvanban = "active";
            var model = new DocumentType { isTrash = false };
            if (id.HasValue)
            {
                model = _documentTypeService.GetById(id.Value);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddType(DocumentType model)
        {
            if (ModelState.IsValid)
            {
                if (model.documentTypeId > 0)
                    _documentTypeService.Update(model);
                else
                    _documentTypeService.Add(model);
                _documentTypeService.Save();
                return RedirectToAction("ListType");
            }
            ViewBag.Quanlyvanban = "active";
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _documentTypeService.Delete(id);
            _documentTypeService.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}