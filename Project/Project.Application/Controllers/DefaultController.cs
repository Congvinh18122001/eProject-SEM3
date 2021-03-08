using Project.Core;
using Project.Core.Models;
using Project.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Project.Application.Controllers
{
    public class DefaultController : Controller
    {
        private CompanyDbContext db = new CompanyDbContext();
        IUserAccount resp = new UserAccResponsibility();
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.TotalApplicant = db.Applicants.Count();
            ViewBag.TotalVacancy = db.Vacancies.Count();
            ViewBag.VacancyApplicant = db.VacancyApplicants.Count();
            List<Applicant> Applicants = db.Applicants.Where(p => p.Status == false).ToList();
            if (Applicants!=null)
            {
                ViewBag.ApplicantSuccess = Applicants.Count();
            }
            else
            {
                ViewBag.ApplicantSuccess = 0;
            }
            return View();
        }
        public PartialViewResult Menu()
        {
            return PartialView();
        }

        public ActionResult Error()
        {
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Profile(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Logout", "Login");
            }
            User user = resp.GetUser(id.Value);
            return View(user);
        }
        public ActionResult Edit(int id)
        {

            User user = resp.GetUser(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            int id = Int32.Parse(f["Id"]);
            User user = resp.GetUser(id);
            if (!String.IsNullOrEmpty(f["OldPass"]))
            {
                string OldPass = f["OldPass"];
                if (user.Password != OldPass)
                {
                    RedirectToAction("Logout", "Login");
                }
            }
            if (!String.IsNullOrEmpty(f["NewPass"]))
            {
                string NewPass = f["NewPass"];
                user.Password = NewPass;
            }
            user.Email = f["Email"];
            user.Avatar = f["Avatar"];
            resp.UpdateUser(user);
            return RedirectToAction("Profile", new { id = id });
        }

    }
}