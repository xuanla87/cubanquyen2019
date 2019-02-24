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
    public class MenuController : Controller
    {
        ICategoryService _categoryService;
        IPostService _postService;
        IMenuService _Service;
        ToolAdmin _toolAdmin;
        IDocumentTypeService _documentTypeService;
        public MenuController(ICategoryService categoryService, IMenuService Service, IPostService postService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._postService = postService;
            this._Service = Service;
            this._documentTypeService = documentTypeService;
            this._toolAdmin = new ToolAdmin(_categoryService, _documentTypeService);
        }
        public ActionResult Index(int? parentId)
        {
            var entitys = _Service.GetAll().Where(x => x.isTrash == false && x.parentId == parentId);
            ViewBag.Menu = "active";
            ViewBag.parentId = parentId;
            return View(entitys);
        }

        public ActionResult Add(int? parentId)
        {
            var model = new Menu
            {
                parentId = parentId,
                isTrash = false
            };
            ViewBag.Menu = "active";
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Menu model)
        {
            if (ModelState.IsValid)
            {
                _Service.Add(model);
                _Service.Save();
                return RedirectToAction("Index", new { parentId = model.parentId });
            }
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Menu = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                var model = _Service.GetById(id.Value);
                ViewBag.Menu = "active";
                ViewBag.languageId = _toolAdmin.LanguageSelectList();
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Menu model)
        {
            if (ModelState.IsValid)
            {
                _Service.Update(model);
                _Service.Save();
                return RedirectToAction("Index", new { parentId = model.parentId });
            }
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Menu = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Trash(int id)
        {
            var model = _Service.GetById(id);
            model.isTrash = true;
            _Service.Update(model);
            _Service.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getName(int? id)
        {
            if (id.HasValue)
            {
                var model = _Service.GetById(id.Value);
                ViewBag.Name = model?.menuName ?? null;
            }
            else
            {
                ViewBag.Name = "";
            }
            return PartialView();
        }

    }
}