using MyFirstApp_Asp_Mvc.Models;
using MyFirstApp_Asp_Mvc.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp_Asp_Mvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            SecurityDAO securityDAO = new SecurityDAO();      //dependency injection
            UserModel user = securityDAO.FetchOne(id);
            return View("Details", user);
        }
        public ActionResult ProcessCreate(UserModel userModel)
        {
            //save to the database
            SecurityDAO securityDAO = new SecurityDAO();
            securityDAO.Create(userModel);
            return View("Details", userModel);

        }
        public ActionResult Create()
        {
            return View("CreateUserForm");
        }
    }
}