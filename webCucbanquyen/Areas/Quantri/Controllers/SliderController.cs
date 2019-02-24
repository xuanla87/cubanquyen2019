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
    //[Authorize]
    public class SliderController : Controller
    {
        ISliderService _Service;
        IDetailSilderService _detail;
        public SliderController(ISliderService service, IDetailSilderService detail)
        {
            this._Service = service;
            this._detail = detail;
        }
        public ActionResult Index(string searchKey, DateTime? fromDate, DateTime? toDate, int? pageIndex)
        {
            ViewBag.Slider = "active";
            var model = _Service.All(searchKey, fromDate, false, toDate, pageIndex, 20);
            int totalPage = model?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.pageIndex = pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(searchKey) ? string.Empty : searchKey;
            ViewBag.FromDate = fromDate?.ToString("MM/dd/yyyy") ?? null;
            ViewBag.ToDate = toDate?.ToString("MM/dd/yyyy") ?? null;
            return View(model?.Sliders ?? new List<Slider>());
        }

        public ActionResult Add()
        {
            var model = new Slider
            {
                isTrash = false,
                createTime = DateTime.Now,
                updateTime = DateTime.Now
            };
            ViewBag.Slider = "active";
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Slider model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _Service.Add(model);
                    _Service.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                }
            }
            ViewBag.Slider = "active";
            return View(model);
        }
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                var model = _Service.GetById(id.Value);
                ViewBag.Slider = "active";
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Slider model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.updateTime = DateTime.Now;
                    _Service.Update(model);
                    _Service.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                }
            }
            ViewBag.Slider = "active";
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
            _detail.Delete(id);
            _detail.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int Id)
        {
            var model = _detail.GetAllBySliderId(Id);
            ViewBag.SliderId = Id;
            ViewBag.SliderName = _Service.GetById(Id)?.sliderName ?? null;
            return View(model);
        }

        public ActionResult AddDetail(int? Id)
        {
            if (Id.HasValue)
            {
                var model = new SliderDetail();
                model.sliderId = Id.Value;
                model.sliderType = 1;
                ViewBag.Slider = "active";
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddDetail(SliderDetail model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _detail.Add(model);
                    _detail.Save();
                    return RedirectToAction("Detail", new { Id = model.sliderId });
                }
                catch (Exception ex)
                {
                }
            }
            ViewBag.Slider = "active";
            return View(model);
        }

    }
}