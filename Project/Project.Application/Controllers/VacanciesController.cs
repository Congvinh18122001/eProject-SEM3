using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Core;
using Project.Core.Objects;
using Project.Core.Models;

namespace Project.Application.Controllers
{
    public class VacanciesController : Controller
    {
        private CompanyDbContext db = new CompanyDbContext();
        IVacancyResponsibility resp = new VacancyResponsibility();
        // GET: Vacancies
        private User GetUser()
        {
            User user = Session["Login"] as User;
            return user;
        }
        public ActionResult Index()
        {
            var vacancies = db.Vacancies.Where(p=>p.Status=="doing").Include(v => v.Department);
            return View(vacancies.ToList());
        }

        // GET: Vacancies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                vacancy.Create_by = GetUser().Id;
                vacancy.Posted = DateTime.Now;
                vacancy.Status = "doing";
                resp.CreateVacancy(vacancy);
                return RedirectToAction("List");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();

        }
        public ActionResult List()
        {
            List<Vacancy> vacancies = resp.GetVacancies();
            return View(vacancies);
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                List<string> status = new List<string>() {"doing","pause","done" };
                ViewBag.Status = new SelectList(status);
                Vacancy vacancy = resp.GetVacancy(id.Value);
                if (vacancy == null)
                {
                    return RedirectToAction("List");
                }
                User Creater = db.Users.Single(p => p.Id ==vacancy.Create_by);
                ViewBag.Creater = Creater.Name;
                return View(vacancy);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(Vacancy vacancy)
        {
            if (vacancy.Create_by==GetUser().Id)
            {
                resp.UpdateVacancy(vacancy);
                return RedirectToAction("DetailsVacancy", new { id=vacancy.Id });
            }
            return RedirectToAction("List");
        }
        public ActionResult DetailsVacancy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return RedirectToAction("List");
            }
            return View(vacancy);
        }
    }
}
