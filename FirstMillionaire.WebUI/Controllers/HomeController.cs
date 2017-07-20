using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMillionaire.WebUI.Models;
using FirstMillionaire.Repositories;
using FirstMillionaire.Domain;
using FirstMillionaire.WebUI.ViewModels;


namespace FirstMillionaire.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Question> repository;
        List<Question> questionsList;
        StartViewModel model = new StartViewModel();
        static int i = 0;

        public HomeController()
        {
            repository = new XmlQuestionRepository();
            questionsList = new List<Question>(repository.GetAll());
        }

        [HttpGet]
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpPost]
        public ViewResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View("GameMenu", user);
        }

        public ViewResult Results()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GameOver()
        {
            return View();
        }

    }
}