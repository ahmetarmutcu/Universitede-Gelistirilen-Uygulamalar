﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using WebPdfOdev;


namespace WebPdfOdev
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public object FilterConfig { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();


            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
        protected void Application_BeginRequest(object sender,EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];
            if(cookie!=null&&cookie.Value!=null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
        }
    }
}
