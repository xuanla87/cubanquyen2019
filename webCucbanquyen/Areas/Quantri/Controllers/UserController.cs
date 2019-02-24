using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using webCucbanquyen.Models;

namespace webCucbanquyen.Areas.Quantri.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;

        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var users = db.Users.Include(x=>x.Roles);
            foreach (var item in users)
            {
                string UserName = item.UserName;
                string Roles = string.Join(",", item.Roles.Select(r => r.RoleId).ToList());
            }
            ViewBag.User = "active";
            return View(users);
        }

        public ActionResult Add()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var roles = db.Roles.ToList();
            ViewBag.RoleName = roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Name });
            ViewBag.User = "active";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(RegisterViewModel model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, FullName = model.FullName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    UserManager.AddToRole(user.Id, model.RoleName);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            var roles = db.Roles.ToList();
            ViewBag.RoleName = roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Name });
            ViewBag.User = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ApplicationDbContext db = new ApplicationDbContext();
                ViewBag.User = "active";
                var user = db.Users.Find(id);
                return View(user);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(RegisterViewModel model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, FullName = model.FullName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.RoleName))
                    {
                        UserManager.AddToRole(user.Id, model.RoleName);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            var roles = db.Roles.ToList();
            ViewBag.RoleName = roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Name });
            ViewBag.User = "active";
            return View(model);
        }

        public ActionResult ListRole()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var roles = db.Roles.ToList();
            ViewBag.User = "active";
            return View(roles);
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.Roles.Add(model);
                db.SaveChanges();
                return RedirectToAction("ListRole");
            }
            ViewBag.User = "active";
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteRole(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var role = db.Roles.FirstOrDefault(x => x.Id == id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("/");
        }
    }
}