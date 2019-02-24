using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webCucbanquyen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
              name: "TraCuuen",
              url: "search-on-registered-works",
              defaults: new { controller = "TraCuuNienGiam", action = "Index" }
            );
            routes.MapRoute(
             name: "TraCuu",
             url: "tra-cuu-nien-giam",
             defaults: new { controller = "TraCuuNienGiam", action = "Index" }
            );
            routes.MapRoute(
             name: "luatvanban",
             url: "luat-van-ban-duoi-luat",
             defaults: new { controller = "VanBan", action = "Detail" }
            );
            routes.MapRoute(
            name: "HoiDap",
            url: "hoi-dap",
            defaults: new { controller = "QuestionAnswer", action = "Index" }
            );
            routes.MapRoute(
            name: "CauHoi",
            url: "dat-cau-hoi",
            defaults: new { controller = "QuestionAnswer", action = "Detail" }
            );
            routes.MapRoute(
               name: "TinTuc",
               url: "tin-tuc/{pageUrl}",
               defaults: new { controller = "TinTuc", action = "Index", pageUrl = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "VanBan",
               url: "van-ban/{pageUrl}",
               defaults: new { controller = "VanBan", action = "Index", pageUrl = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "ChuyenMuc",
               url: "chuyen-muc/{pageUrl}",
               defaults: new { controller = "ChuyenMucs", action = "Index", pageUrl = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
