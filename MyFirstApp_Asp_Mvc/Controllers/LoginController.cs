using MyFirstApp_Asp_Mvc.Models;
using MyFirstApp_Asp_Mvc.Services.Business;
using MyFirstApp_Asp_Mvc.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp_Asp_Mvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(UserModel userModel)
        {
            //return "Results: UserName = " + userModel.UserName + " Password = " + userModel.Password;

            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);

            if (success == true)
            {
                return View("LoginSuccess",userModel);
            }
            else
            {
                return View("LoginFailure",userModel);
            }
        }
     

    }
}