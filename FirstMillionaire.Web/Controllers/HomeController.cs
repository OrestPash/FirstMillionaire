using System.Web.Mvc;
using FirstMillionaire.Domain.Entities;
using FirstMillionaire.Repositories;
using FirstMillionaire.Web.Models;

namespace FirstMillionaire.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _users;

        public HomeController(IUserRepository userRepository)
         {
            _users = userRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var existingUser = _users.GetByEmail(user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "User already exists");
                return View(user);
            }        

            var savedUser = _users.Add(new User()
            {
                Name = user.Name,
                Email = user.Email
            });

            return RedirectToAction("Start", "Game", new { userId = savedUser.Id });
        }
    }
}