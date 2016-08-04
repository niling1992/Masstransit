using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Providers;

namespace UserManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserProvider _userProvider;

        public HomeController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetNames()
        {
            var users = _userProvider.Names();

            return Json(users,JsonRequestBehavior.AllowGet);
        }
    }
}

