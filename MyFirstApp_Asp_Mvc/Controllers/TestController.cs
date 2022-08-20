using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp_Asp_Mvc.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public string PrintMessage()
        {
            return "<h1>Welcome</h1><p>This is the first custom page of your application</p>";
        }
        public ActionResult ErrorMessage()
        {
            return View();
        }
        public string Welcome(string Name,int numTimes=1)
        {
            return "Hello " + Name + " Number of times is " + numTimes;
        }
    }
}