﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webCucbanquyen.Models
{
    public class HitCounter
    {
        public bool AddHitCounter()
        {
            string IPClient = "";
            string BrowserClient = "";
            HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            BrowserClient = browser.Type + "/" + browser.Browser + "/" + browser.Version
               + "/" + browser.EcmaScriptVersion
               + "/" + browser.Platform;

            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    IPClient = addresses[0];
                }
            }
            IPClient = context.Request.ServerVariables["REMOTE_ADDR"];

            HitCounterEntity db = new HitCounterEntity();
            db.Visiters.Add(new Visiter { createTime = DateTime.Now, visiterLocation = "", visiterBrowser = BrowserClient, visiterIP = IPClient });
            db.SaveChanges();
            return true;
        }
    }
}