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
            MovieDAO movieDAO = new MovieDAO();     
            FilmModel film = movieDAO.FetchOne(id);
            return View("Details", film);
        }
        public ActionResult ProcessCreate(FilmModel filmModel)
        {
            MovieDAO movieDAO = new MovieDAO();
            movieDAO.CreateOrUpdate(filmModel);
            return View("Details", filmModel);
        }
        public ActionResult Create()
        {
            return View("MovieForm");
        }
        public ActionResult Edit(int id)
        {
            MovieDAO movieDAO = new MovieDAO();      
            FilmModel film = movieDAO.FetchOne(id);
            return View("MovieForm", film);
        }
        public ActionResult Delete(int id)
        {
            MovieDAO movieDAO = new MovieDAO();     
            movieDAO.Delete(id);
            List<FilmModel> films = movieDAO.FetchAll(); 
            return View("Index", films);
        }
        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }
        public ActionResult SearchForName(string searchPhrase)
        {
            MovieDAO movieDAO = new MovieDAO();
            List<FilmModel> searchResults = movieDAO.SearchForName(searchPhrase);
            return View("Index", searchResults);
        }
    }
}