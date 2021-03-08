using Project.Core.Models;
using Project.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Application.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ILogin resp = new LoginResponsibility();
        // GET: Login
        public PartialViewResult Index()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            User CheckUser = resp.GetUser(user.Email, user.Password);
            if (CheckUser != null)
            {
                CheckUser.Password = null;
                Session["Login"] = CheckUser;
                if (CheckUser.TypeUserId == 1)
                {
                    return RedirectToAction("Index", "Default");
                }
                else if (CheckUser.TypeUserId == 2)
                {
                    return RedirectToAction("Interview", "VacancyApplicant");
                }
            }
            TempData["StatusMessage"] = "Email or Password is not valid.";

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Index", "Login");
        }
        //public PartialViewResult User()
        //{
        //    return PartialView();
        //}
        //public ActionResult Error()
        //{
        //    return RedirectToAction("Index");
        //}
    }
}