using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksAPI;
using KBookSearch.Models;
using KBookSearch.Models.DAL;

namespace KBookSearch.Controllers
{
    public class HomeController : Controller
    {
        private IBookDAL _bookDAL;
        //Binds the dal for ninject so the controller has access to it
        public HomeController(IBookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookSearch(string query)
        {
            BookSearch bookSearch = new BookSearch();
            List<BookModel> bookModels = bookSearch.Search(query);

            return View(bookModels);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}