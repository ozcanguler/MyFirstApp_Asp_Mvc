using MyFirstApp_Asp_Mvc.Models;
using MyFirstApp_Asp_Mvc.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp_Asp_Mvc.Controllers
{
    public class MoviesController : Controller
    {
       public ActionResult Index()
        {
            List<FilmModel> films = new List<FilmModel>();
            MovieDAO movieDAO = new MovieDAO();
            films = movieDAO.FetchAll();

            return View("Index", films);
        }
        public ActionResult Details(int id)
        {
            MovieDAO movieDAO = new MovieDAO();      //dependency injection
            FilmModel film = movieDAO.FetchOne(id);
            return View("Details", film);
        }
    }
}