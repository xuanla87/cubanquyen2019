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
    public class QuanlybaivietController : Controller
    {
        ICategoryService _categoryService;
        IPostService _postService;
        ToolAdmin _toolAdmin;
        IDocumentTypeService _documentTypeService;
        public QuanlybaivietController(ICategoryService categoryService, IPostService postService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._postService = postService;
            this._documentTypeService = documentTypeService;
            this._toolAdmin = new ToolAdmin(_categoryService, _documentTypeService);
        }
        public ActionResult Index(string searchKey, int? categoryId, DateTime? fromDate, DateTime? toDate, int? pageIndex, int? languageId)
        {
            ViewBag.Quanlybaiviet = "active";
            var result = _postService.All(searchKey, categoryId, false, fromDate, toDate, pageIndex, 20, languageId);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.pageIndex = pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(searchKey) ? string.Empty : searchKey;
            ViewBag.FromDate = fromDate?.ToString("MM/dd/yyyy") ?? null;
            ViewBag.ToDate = toDate?.ToString("MM/dd/yyyy") ?? null;
            return View(result?.Posts ?? new List<Post>());
        }

        public ActionResult Add()
        {
            var model = new Post
            {
                createBy = User.Identity.Name,
                createTime = DateTime.Now,
                updateTime = DateTime.Now,
                isTrash = false,
                postView = 0,
                languageId = 1
            };
            ViewBag.categoryId = _toolAdmin.CategorySelectList(null, null, model.languageId);
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlybaiviet = "active";
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Post model)
        {
            if (ModelState.IsValid)
            {
                if (!model.postUrl.Contains("/tin-tuc/"))
                {
                    model.postUrl = "/tin-tuc/" + model.postUrl;
                }
                _postService.Add(model);
                _postService.Save();
                return RedirectToAction("Index", new { categoryId = model.categoryId, languageId = model.languageId });
            }
            ViewBag.categoryId = _toolAdmin.CategorySelectList(model.categoryId, null, model.languageId);
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlybaiviet = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                var model = _postService.GetById(id.Value);
                ViewBag.categoryId = _toolAdmin.CategorySelectList(null, null, model.languageId);
                ViewBag.languageId = _toolAdmin.LanguageSelectList();
                ViewBag.Quanlybaiviet = "active";
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Post model)
        {
            if (ModelState.IsValid)
            {
                if (!model.postUrl.Contains("/tin-tuc/"))
                {
                    model.postUrl = "/tin-tuc/" + model.postUrl;
                }
                _postService.Update(model);
                _postService.Save();
                return RedirectToAction("Index", new { categoryId = model.categoryId, languageId = model.languageId });
            }
            ViewBag.categoryId = _toolAdmin.CategorySelectList(model.categoryId, null, model.languageId);
            ViewBag.languageId = _toolAdmin.LanguageSelectList();
            ViewBag.Quanlybaiviet = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Trash(int id)
        {
            var model = _postService.GetById(id);
            model.isTrash = true;
            _postService.Update(model);
            _postService.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public string getCateName(int _id)
        {
            return _categoryService.GetById(_id)?.categoryName ?? "";
        }
    }
}