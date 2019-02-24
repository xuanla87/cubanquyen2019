using CucbanquyenModel.Models;
using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webCucbanquyen.Areas.Quantri.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        public QuestionController(IQuestionService questionService, IAnswerService answerService)
        {
            this._questionService = questionService;
            this._answerService = answerService;
        }
        public ActionResult Index(string searchKey, DateTime? fromDate, DateTime? toDate, int? pageIndex, int? languageId)
        {
            var model = _questionService.All(searchKey, null, fromDate, toDate, pageIndex, 20, languageId);
            pageIndex = pageIndex ?? 1;
            ViewBag.pageIndex = pageIndex;
            ViewBag.TotalPage = model.Total;
            ViewBag.languageId = languageId ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(searchKey) ? string.Empty : searchKey;
            ViewBag.FromDate = fromDate?.ToString("MM/dd/yyyy") ?? null;
            ViewBag.ToDate = toDate?.ToString("MM/dd/yyyy") ?? null;
            ViewBag.Quanlycauhoi = "active";
            return View(model.Questions);
        }

        public ActionResult AnswerQuestion(int? id, int questionId, int? pageIndex)
        {
            var model = new Answer
            {
                createTime = DateTime.Now,
                isTrash = false,
                questionId = questionId,
                userName = User.Identity.Name,
                Question = _questionService.GetById(questionId)

            };
            if (id.HasValue)
            {
                ViewBag.Title = "Cập nhật câu trả lời";
                model = _answerService.GetById(id.Value);
            }
            else
            {
                ViewBag.Title = "Thêm mới câu trả lời";
            }
            ViewBag.Quanlycauhoi = "active";
            ViewBag.pageIndex = pageIndex;
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AnswerQuestion(Answer model, int? pageIndex)
        {
            if (ModelState.IsValid)
            {
                if (model.answerId > 0)
                {
                    _answerService.Update(model);
                    _answerService.Save();
                }
                else
                {
                    model.createTime = DateTime.Now;
                    model.isTrash = false;
                    model.userName = User.Identity.Name;
                    _answerService.Add(model);
                    _answerService.Save();
                }
                return RedirectToAction("Index", new { pageIndex = pageIndex, languageId = model.languageId });
            }
            ViewBag.Quanlycauhoi = "active";
            return View(model);
        }

        public ActionResult Trash(int id)
        {
            var model = _questionService.GetById(id);
            if (model.isTrash)

                model.isTrash = false;
            else
                model.isTrash = true;
            _questionService.Update(model);
            _questionService.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var model = _answerService.GetByQuestionId(id).ToList();
            foreach (var item in model)
            {
                _answerService.Delete(item.answerId);
                _answerService.Save();
            }
            _questionService.Delete(id);
            _questionService.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult TrashAnswer(int id)
        {
            var model = _answerService.GetById(id);
            if (model.isTrash)
                model.isTrash = false;
            else
                model.isTrash = true;
            _answerService.Update(model);
            _answerService.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListAnswer(int questionId)
        {
            var model = _answerService.GetByQuestionId(questionId).Where(x => x.isTrash == false);
            return PartialView(model);
        }
    }
}