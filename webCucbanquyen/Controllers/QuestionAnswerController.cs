using BotDetect.Web.Mvc;
using CucbanquyenModel.Models;
using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webCucbanquyen.Controllers
{
    public class QuestionAnswerController : Controller
    {
        private readonly IQuestionService _Service;
        private readonly IAnswerService _answerService;
        public QuestionAnswerController(IQuestionService Service, IAnswerService answerService)
        {
            this._Service = Service;
            this._answerService = answerService;
        }
        public ActionResult Index(int? pageIndex)
        {
            int? languageId = null;
            var model = _Service.All(null, false, null, null, pageIndex, 10, languageId);
            pageIndex = pageIndex ?? 1;
            ViewBag.pageIndex = pageIndex;
            ViewBag.TotalPage = model.Total;
            return View(model.Questions);
        }

        public ActionResult Detail()
        {
            var model = new Question
            {
                createTime = DateTime.Now,
                isTrash = true,
                languageId = 1
            };
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Trường yêu cầu bắt buộc!")]
        public ActionResult Detail(Question model, HttpPostedFileBase fileInput)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (fileInput.ContentLength > 0)
                    {
                        string _fileName = Path.GetFileName(fileInput.FileName);
                        bool exists = System.IO.Directory.Exists(Server.MapPath("~/FileAttach"));
                        if (!exists)
                            Directory.CreateDirectory(Server.MapPath("~/FileAttach"));
                        string _path = Path.Combine(Server.MapPath("~/FileAttach"), _fileName);
                        fileInput.SaveAs(_path);
                        model.attachment = _fileName;
                    }

                }
                catch (Exception ex)
                {
                }
                MvcCaptcha.ResetCaptcha("ExampleCaptcha");
                model.createTime = DateTime.Now;
                _Service.Add(model);
                _Service.Save();
                return Content("<script language='javascript' type='text/javascript'>alert('Câu hỏi đã được gửi đi thành công!');window.location = '/hoi-dap';</script>");
            }
            return View(model);
        }

        public ActionResult getAnswer(int questionId)
        {
            var model = _answerService.GetByQuestionId(questionId).Where(x => x.isTrash == false);
            return PartialView(model);
        }
    }
}