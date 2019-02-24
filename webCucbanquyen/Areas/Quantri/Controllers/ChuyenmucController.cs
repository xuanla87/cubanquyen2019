using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CucbanquyenModel.Models;
using CucbanquyenService;
using webCucbanquyen.Areas.Quantri.Models;

namespace webCucbanquyen.Areas.Quantri.Controllers
{
    [Authorize]
    public class ChuyenmucController : Controller
    {

        ICategoryService _categoryService;
        ToolAdmin _toolAdmin;
        IDocumentTypeService _documentTypeService;
        public ChuyenmucController(ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._documentTypeService = documentTypeService;
            this._toolAdmin = new ToolAdmin(_categoryService, _documentTypeService);
        }

        [HttpGet]
        public ActionResult Index(string searchKey, int? parentId, int? pageIndex, int? pageSize, int? languageId)
        {
            var result = _categoryService.GetAll().Where(x => x.isTrash == false);
            ViewBag.Chuyenmuc = "active";
            return View(result);
        }

        [HttpGet]
        public ActionResult AllTrash(string searchKey, int? parentId, int? pageIndex, int? pageSize, int? languageId)
        {
            ViewBag.Chuyenmuc = "active";
            return View();
        }

        public ActionResult Add()
        {
            var model = new Category { isTrash = false, categoryId = 0, languageId = 1 };
            ViewBag.Chuyenmuc = "active";
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.parentId = _toolAdmin.CategorySelectList(null, null, model.languageId);

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                if (!model.categoryUrl.Contains("/chuyen-muc/"))
                {
                    model.categoryUrl = "/chuyen-muc/" + model.categoryUrl;
                }
                _categoryService.Add(model);
                _categoryService.Save();
                return RedirectToAction("Index", new { parentId = model.parentId, languageId = model.languageId });
            }
            ViewBag.parentId = _toolAdmin.CategorySelectList(model.categoryId, null, model.languageId);
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Chuyenmuc = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                var model = _categoryService.GetById(id.Value);
                ViewBag.languageId = _toolAdmin.LanguageSelectList();
                ViewBag.parentId = _toolAdmin.CategorySelectList(model.categoryId, id, model.languageId);
                return View(model);
            }
            ViewBag.Chuyenmuc = "active";
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Category model)
        {
            if (ModelState.IsValid)
            {
                if (!model.categoryUrl.Contains("/chuyen-muc/"))
                {
                    model.categoryUrl = "/chuyen-muc/" + model.categoryUrl;
                }
                _categoryService.Update(model);
                _categoryService.Save();
                return RedirectToAction("Index", new { parentId = model.parentId, languageId = model.languageId });
            }
            ViewBag.parentId = _toolAdmin.CategorySelectList(model.categoryId, null, model.languageId);
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Chuyenmuc = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            _categoryService.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Trash(int id)
        {
            var model = _categoryService.GetById(id);
            model.isTrash = true;
            _categoryService.Update(model);
            _categoryService.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public string getName(int? _id)
        {
            if (_id.HasValue)
                return _categoryService.GetById(_id.Value)?.categoryName ?? "";
            else return "";
        }
    }
}