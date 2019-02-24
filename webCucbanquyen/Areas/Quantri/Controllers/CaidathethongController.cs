using CucbanquyenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webCucbanquyen.Areas.Quantri.Models;

namespace webCucbanquyen.Areas.Quantri.Controllers
{
    //[Authorize]
    public class CaidathethongController : Controller
    {
        IConfigSystemService _service;
        ToolAdmin _toolAdmin;
        ISliderService _sildeService;
        IMenuService _menuService;
        ICategoryService _categoryService;
        IDocumentTypeService _documentTypeService;
        public CaidathethongController(IConfigSystemService service, ICategoryService categoryService, IDocumentTypeService documentTypeService, IMenuService menuService, ISliderService sildeService)
        {
            this._categoryService = categoryService;
            this._documentTypeService = documentTypeService;
            this._service = service;
            this._toolAdmin = new ToolAdmin(_categoryService, _documentTypeService);
            this._sildeService = sildeService;
            this._menuService = menuService;
        }

        public ActionResult Index()
        {
            ViewBag.Caidathethong = "active";
            var model = new SettingModel();
            model.Box1 = _service.GetByName("Box1")?.configBody ?? null;
            model.Box2 = _service.GetByName("Box2")?.configBody ?? null;
            model.Box3 = _service.GetByName("Box3")?.configBody ?? null;
            model.GioiThieuTacPham = _service.GetByName("GioiThieuTacPham")?.configBody ?? null;
            model.Footer = _service.GetByName("Footer")?.configBody ?? null;
            model.MainMenu = _service.GetByName("MainMenu")?.configBody ?? null;
            model.RightMenu = _service.GetByName("RightMenu")?.configBody ?? null;
            model.RightMenu2 = _service.GetByName("RightMenu2")?.configBody ?? null;
            model.RightMenu3 = _service.GetByName("RightMenu3")?.configBody ?? null;
            model.RightMenu4 = _service.GetByName("RightMenu4")?.configBody ?? null;
            model.LienKetWebsite = _service.GetByName("LienKetWebsite")?.configBody ?? null;
            model.Banner = _service.GetByName("Banner")?.configBody ?? null;
            model.BoxRight3 = _service.GetByName("BoxRight3")?.configBody ?? null;
            model.BoxRight4 = _service.GetByName("BoxRight4")?.configBody ?? null;
            ViewBag.Box1 = _toolAdmin.CategorySelectList(null, null, 1);
            ViewBag.Box2 = _toolAdmin.CategorySelectList(null, null, 1);
            ViewBag.Box3 = _toolAdmin.CategorySelectList(null, null, 1);
            ViewBag.GioiThieuTacPham = _toolAdmin.SlideDropdown(_sildeService);
            ViewBag.BoxRight3 = _toolAdmin.SlideDropdown(_sildeService);
            ViewBag.MainMenu = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.RightMenu = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.RightMenu2 = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.RightMenu3 = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.RightMenu4 = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.LienKetWebsite = _toolAdmin.MenuDropdown(_menuService, 1);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(SettingModel model)
        {
            var Box1 = _service.GetByName("Box1");
            if (Box1 != null)
            {
                Box1.configBody = model.Box1;
                _service.Update(Box1);
                _service.Save();
            }
            else
            {
                Box1 = new CucbanquyenModel.Models.ConfigSystem();
                Box1.configBody = model.Box1;
                Box1.configName = "Box1";
                _service.Add(Box1);
                _service.Save();
            }
            var Box2 = _service.GetByName("Box2");
            if (Box2 != null)
            {
                Box2.configBody = model.Box2;
                _service.Update(Box2);
                _service.Save();
            }
            else
            {
                Box2 = new CucbanquyenModel.Models.ConfigSystem();
                Box2.configBody = model.Box2;
                Box2.configName = "Box2";
                _service.Add(Box2);
                _service.Save();
            }
            var Box3 = _service.GetByName("Box3");
            if (Box3 != null)
            {
                Box3.configBody = model.Box3;
                _service.Update(Box3);
                _service.Save();
            }
            else
            {
                Box3 = new CucbanquyenModel.Models.ConfigSystem();
                Box3.configBody = model.Box3;
                Box3.configName = "Box3";
                _service.Add(Box3);
                _service.Save();
            }
            var GioiThieuTacPham = _service.GetByName("GioiThieuTacPham");
            if (GioiThieuTacPham != null)
            {
                GioiThieuTacPham.configBody = model.GioiThieuTacPham;
                _service.Update(GioiThieuTacPham);
                _service.Save();
            }
            else
            {
                GioiThieuTacPham = new CucbanquyenModel.Models.ConfigSystem();
                GioiThieuTacPham.configBody = model.GioiThieuTacPham;
                GioiThieuTacPham.configName = "GioiThieuTacPham";
                _service.Add(GioiThieuTacPham);
                _service.Save();
            }
            var BoxRight3 = _service.GetByName("BoxRight3");
            if (BoxRight3 != null)
            {
                BoxRight3.configBody = model.BoxRight3;
                _service.Update(BoxRight3);
                _service.Save();
            }
            else
            {
                BoxRight3 = new CucbanquyenModel.Models.ConfigSystem();
                BoxRight3.configBody = model.BoxRight3;
                BoxRight3.configName = "BoxRight3";
                _service.Add(BoxRight3);
                _service.Save();
            }
            var Footer = _service.GetByName("Footer");
            if (Footer != null)
            {
                Footer.configBody = model.Footer;
                _service.Update(Footer);
                _service.Save();
            }
            else
            {
                Footer = new CucbanquyenModel.Models.ConfigSystem();
                Footer.configBody = model.Footer;
                Footer.configName = "Footer";
                _service.Add(Footer);
                _service.Save();
            }
            var MainMenu = _service.GetByName("MainMenu");
            if (MainMenu != null)
            {
                MainMenu.configBody = model.MainMenu;
                _service.Update(MainMenu);
                _service.Save();
            }
            else
            {
                MainMenu = new CucbanquyenModel.Models.ConfigSystem();
                MainMenu.configBody = model.MainMenu;
                MainMenu.configName = "MainMenu";
                _service.Add(MainMenu);
                _service.Save();
            }
            var RightMenu = _service.GetByName("RightMenu");
            if (RightMenu != null)
            {
                RightMenu.configBody = model.RightMenu;
                _service.Update(RightMenu);
                _service.Save();
            }
            else
            {
                RightMenu = new CucbanquyenModel.Models.ConfigSystem();
                RightMenu.configBody = model.RightMenu;
                RightMenu.configName = "RightMenu";
                _service.Add(RightMenu);
                _service.Save();
            }
            var RightMenu2 = _service.GetByName("RightMenu2");
            if (RightMenu2 != null)
            {
                RightMenu2.configBody = model.RightMenu2;
                _service.Update(RightMenu2);
                _service.Save();
            }
            else
            {
                RightMenu2 = new CucbanquyenModel.Models.ConfigSystem();
                RightMenu2.configBody = model.RightMenu2;
                RightMenu2.configName = "RightMenu2";
                _service.Add(RightMenu2);
                _service.Save();
            }
            var RightMenu3 = _service.GetByName("RightMenu3");
            if (RightMenu3 != null)
            {
                RightMenu3.configBody = model.RightMenu3;
                _service.Update(RightMenu3);
                _service.Save();
            }
            else
            {
                RightMenu3 = new CucbanquyenModel.Models.ConfigSystem();
                RightMenu3.configBody = model.RightMenu3;
                RightMenu3.configName = "RightMenu3";
                _service.Add(RightMenu3);
                _service.Save();
            }
            var RightMenu4 = _service.GetByName("RightMenu4");
            if (RightMenu4 != null)
            {
                RightMenu4.configBody = model.RightMenu4;
                _service.Update(RightMenu4);
                _service.Save();
            }
            else
            {
                RightMenu4 = new CucbanquyenModel.Models.ConfigSystem();
                RightMenu4.configBody = model.RightMenu4;
                RightMenu4.configName = "RightMenu4";
                _service.Add(RightMenu4);
                _service.Save();
            }
            var LienKetWebsite = _service.GetByName("LienKetWebsite");
            if (LienKetWebsite != null)
            {
                LienKetWebsite.configBody = model.LienKetWebsite;
                _service.Update(LienKetWebsite);
                _service.Save();
            }
            else
            {
                LienKetWebsite = new CucbanquyenModel.Models.ConfigSystem();
                LienKetWebsite.configBody = model.LienKetWebsite;
                LienKetWebsite.configName = "LienKetWebsite";
                _service.Add(LienKetWebsite);
                _service.Save();
            }

            var Banner = _service.GetByName("Banner");
            if (Banner != null)
            {
                Banner.configBody = model.Banner;
                _service.Update(Banner);
                _service.Save();
            }
            else
            {
                Banner = new CucbanquyenModel.Models.ConfigSystem();
                Banner.configBody = model.Banner;
                Banner.configName = "Banner";
                _service.Add(Banner);
                _service.Save();
            }
            var BoxRight4 = _service.GetByName("BoxRight4");
            if (BoxRight4 != null)
            {
                BoxRight4.configBody = model.BoxRight4;
                _service.Update(BoxRight4);
                _service.Save();
            }
            else
            {
                BoxRight4 = new CucbanquyenModel.Models.ConfigSystem();
                BoxRight4.configBody = model.BoxRight4;
                BoxRight4.configName = "BoxRight4";
                _service.Add(BoxRight4);
                _service.Save();
            }
            ViewBag.Box1 = _toolAdmin.CategorySelectList(null, null, 1);
            ViewBag.Box2 = _toolAdmin.CategorySelectList(null, null, 1);
            ViewBag.Box3 = _toolAdmin.CategorySelectList(null, null, 1);
            ViewBag.GioiThieuTacPham = _toolAdmin.SlideDropdown(_sildeService);
            ViewBag.BoxRight3 = _toolAdmin.SlideDropdown(_sildeService);
            ViewBag.MainMenu = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.RightMenu = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.RightMenu2 = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.RightMenu3 = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.RightMenu4 = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.LienKetWebsite = _toolAdmin.MenuDropdown(_menuService, 1);
            ViewBag.Caidathethong = "active";
            return View(model);
        }

        public ActionResult SetEng()
        {
            ViewBag.Caidathethong = "active";
            var model = new SettingModel();
            model.Box1en = _service.GetByName("Box1en")?.configBody ?? null;
            model.Box2en = _service.GetByName("Box2en")?.configBody ?? null;
            model.Box3en = _service.GetByName("Box3en")?.configBody ?? null;
            model.GioiThieuTacPhamen = _service.GetByName("GioiThieuTacPhamen")?.configBody ?? null;
            model.Footeren = _service.GetByName("Footeren")?.configBody ?? null;
            model.MainMenuen = _service.GetByName("MainMenuen")?.configBody ?? null;
            model.RightMenuen = _service.GetByName("RightMenuen")?.configBody ?? null;
            model.RightMenu2en = _service.GetByName("RightMenu2en")?.configBody ?? null;
            model.RightMenu3en = _service.GetByName("RightMenu3en")?.configBody ?? null;
            model.RightMenu4en = _service.GetByName("RightMenu4en")?.configBody ?? null;
            model.LienKetWebsiteen = _service.GetByName("LienKetWebsiteen")?.configBody ?? null;
            model.Banneren = _service.GetByName("Banneren")?.configBody ?? null;
            model.BoxRight3en = _service.GetByName("BoxRight3en")?.configBody ?? null;
            model.BoxRight4en = _service.GetByName("BoxRight4en")?.configBody ?? null;
            ViewBag.Box1en = _toolAdmin.CategorySelectList(null, null, 2);
            ViewBag.Box2en = _toolAdmin.CategorySelectList(null, null, 2);
            ViewBag.Box3en = _toolAdmin.CategorySelectList(null, null, 2);
            ViewBag.GioiThieuTacPhamen = _toolAdmin.SlideDropdown(_sildeService);
            ViewBag.BoxRight3en = _toolAdmin.SlideDropdown(_sildeService);
            ViewBag.MainMenuen = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.RightMenuen = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.RightMenu2en = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.RightMenu3en = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.RightMenu4en = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.LienKetWebsiteen = _toolAdmin.MenuDropdown(_menuService, 2);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SetEng(SettingModel model)
        {
            var Box1en = _service.GetByName("Box1en");
            if (Box1en != null)
            {
                Box1en.configBody = model.Box1en;
                _service.Update(Box1en);
                _service.Save();
            }
            else
            {
                Box1en = new CucbanquyenModel.Models.ConfigSystem();
                Box1en.configBody = model.Box1en;
                Box1en.configName = "Box1en";
                _service.Add(Box1en);
                _service.Save();
            }
            var Box2en = _service.GetByName("Box2en");
            if (Box2en != null)
            {
                Box2en.configBody = model.Box2en;
                _service.Update(Box2en);
                _service.Save();
            }
            else
            {
                Box2en = new CucbanquyenModel.Models.ConfigSystem();
                Box2en.configBody = model.Box2en;
                Box2en.configName = "Box2en";
                _service.Add(Box2en);
                _service.Save();
            }
            var Box3en = _service.GetByName("Box3en");
            if (Box3en != null)
            {
                Box3en.configBody = model.Box3en;
                _service.Update(Box3en);
                _service.Save();
            }
            else
            {
                Box3en = new CucbanquyenModel.Models.ConfigSystem();
                Box3en.configBody = model.Box3en;
                Box3en.configName = "Box3en";
                _service.Add(Box3en);
                _service.Save();
            }
            var GioiThieuTacPhamen = _service.GetByName("GioiThieuTacPhamen");
            if (GioiThieuTacPhamen != null)
            {
                GioiThieuTacPhamen.configBody = model.GioiThieuTacPhamen;
                _service.Update(GioiThieuTacPhamen);
                _service.Save();
            }
            else
            {
                GioiThieuTacPhamen = new CucbanquyenModel.Models.ConfigSystem();
                GioiThieuTacPhamen.configBody = model.GioiThieuTacPhamen;
                GioiThieuTacPhamen.configName = "GioiThieuTacPhamen";
                _service.Add(GioiThieuTacPhamen);
                _service.Save();
            }
            var BoxRight3en = _service.GetByName("BoxRight3en");
            if (BoxRight3en != null)
            {
                BoxRight3en.configBody = model.BoxRight3en;
                _service.Update(BoxRight3en);
                _service.Save();
            }
            else
            {
                BoxRight3en = new CucbanquyenModel.Models.ConfigSystem();
                BoxRight3en.configBody = model.BoxRight3en;
                BoxRight3en.configName = "BoxRight3en";
                _service.Add(BoxRight3en);
                _service.Save();
            }
            var Footeren = _service.GetByName("Footeren");
            if (Footeren != null)
            {
                Footeren.configBody = model.Footeren;
                _service.Update(Footeren);
                _service.Save();
            }
            else
            {
                Footeren = new CucbanquyenModel.Models.ConfigSystem();
                Footeren.configBody = model.Footeren;
                Footeren.configName = "Footeren";
                _service.Add(Footeren);
                _service.Save();
            }
            var MainMenuen = _service.GetByName("MainMenuen");
            if (MainMenuen != null)
            {
                MainMenuen.configBody = model.MainMenuen;
                _service.Update(MainMenuen);
                _service.Save();
            }
            else
            {
                MainMenuen = new CucbanquyenModel.Models.ConfigSystem();
                MainMenuen.configBody = model.MainMenuen;
                MainMenuen.configName = "MainMenuen";
                _service.Add(MainMenuen);
                _service.Save();
            }
            var RightMenuen = _service.GetByName("RightMenuen");
            if (RightMenuen != null)
            {
                RightMenuen.configBody = model.RightMenuen;
                _service.Update(RightMenuen);
                _service.Save();
            }
            else
            {
                RightMenuen = new CucbanquyenModel.Models.ConfigSystem();
                RightMenuen.configBody = model.RightMenuen;
                RightMenuen.configName = "RightMenuen";
                _service.Add(RightMenuen);
                _service.Save();
            }
            var RightMenu2en = _service.GetByName("RightMenu2en");
            if (RightMenu2en != null)
            {
                RightMenu2en.configBody = model.RightMenu2en;
                _service.Update(RightMenu2en);
                _service.Save();
            }
            else
            {
                RightMenu2en = new CucbanquyenModel.Models.ConfigSystem();
                RightMenu2en.configBody = model.RightMenu2en;
                RightMenu2en.configName = "RightMenu2en";
                _service.Add(RightMenu2en);
                _service.Save();
            }
            var RightMenu3en = _service.GetByName("RightMenu3en");
            if (RightMenu3en != null)
            {
                RightMenu3en.configBody = model.RightMenu3en;
                _service.Update(RightMenu3en);
                _service.Save();
            }
            else
            {
                RightMenu3en = new CucbanquyenModel.Models.ConfigSystem();
                RightMenu3en.configBody = model.RightMenu3en;
                RightMenu3en.configName = "RightMenu3en";
                _service.Add(RightMenu3en);
                _service.Save();
            }
            var RightMenu4en = _service.GetByName("RightMenu4en");
            if (RightMenu4en != null)
            {
                RightMenu4en.configBody = model.RightMenu4en;
                _service.Update(RightMenu4en);
                _service.Save();
            }
            else
            {
                RightMenu4en = new CucbanquyenModel.Models.ConfigSystem();
                RightMenu4en.configBody = model.RightMenu4en;
                RightMenu4en.configName = "RightMenu4en";
                _service.Add(RightMenu4en);
                _service.Save();
            }
            var LienKetWebsiteen = _service.GetByName("LienKetWebsiteen");
            if (LienKetWebsiteen != null)
            {
                LienKetWebsiteen.configBody = model.LienKetWebsiteen;
                _service.Update(LienKetWebsiteen);
                _service.Save();
            }
            else
            {
                LienKetWebsiteen = new CucbanquyenModel.Models.ConfigSystem();
                LienKetWebsiteen.configBody = model.LienKetWebsiteen;
                LienKetWebsiteen.configName = "LienKetWebsiteen";
                _service.Add(LienKetWebsiteen);
                _service.Save();
            }

            var Banneren = _service.GetByName("Banneren");
            if (Banneren != null)
            {
                Banneren.configBody = model.Banneren;
                _service.Update(Banneren);
                _service.Save();
            }
            else
            {
                Banneren = new CucbanquyenModel.Models.ConfigSystem();
                Banneren.configBody = model.Banneren;
                Banneren.configName = "Banneren";
                _service.Add(Banneren);
                _service.Save();
            }
            var BoxRight4en = _service.GetByName("BoxRight4en");
            if (BoxRight4en != null)
            {
                BoxRight4en.configBody = model.BoxRight4en;
                _service.Update(BoxRight4en);
                _service.Save();
            }
            else
            {
                BoxRight4en = new CucbanquyenModel.Models.ConfigSystem();
                BoxRight4en.configBody = model.BoxRight4en;
                BoxRight4en.configName = "BoxRight4en";
                _service.Add(BoxRight4en);
                _service.Save();
            }
            ViewBag.Box1en = _toolAdmin.CategorySelectList(null, null, 2);
            ViewBag.Box2en = _toolAdmin.CategorySelectList(null, null, 2);
            ViewBag.Box3en = _toolAdmin.CategorySelectList(null, null, 2);
            ViewBag.GioiThieuTacPhamen = _toolAdmin.SlideDropdown(_sildeService);
            ViewBag.BoxRight3en = _toolAdmin.SlideDropdown(_sildeService);
            ViewBag.MainMenuen = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.RightMenuen = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.RightMenu2en = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.RightMenu3en = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.RightMenu4en = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.LienKetWebsiteen = _toolAdmin.MenuDropdown(_menuService, 2);
            ViewBag.Caidathethong = "active";
            return View(model);
        }
    }
}