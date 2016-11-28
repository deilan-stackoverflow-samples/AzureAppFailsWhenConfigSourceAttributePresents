using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureAppFailsWhenConfigSourceAttributePresents.DemoApp.Controllers
{
    public class HomeController : Controller
    {
        // This page should never fail, whether there are connection string or app setting defined or some of them is absent
        public string Index()
        {
            return @"<a href=/Home/Demo>Go here</a>";
        }

        // This page should fail only when there are no appropriate connection string or app setting
        public string Demo()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;
            var appSetting = ConfigurationManager.AppSettings["DemoAppSetting"];
            var text = string.Join("<br>", $@"<strong>DemoConnectionString</strong>: {connectionString}", $@"<strong>DemoAppSetting</strong>: {appSetting}");
            return text;
        }
    }
}