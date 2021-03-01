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
using PagedList;

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
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var vacancies = db.Vacancies.Where(p => p.Status == 0).OrderBy(x => x.Id);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(vacancies.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(FormCollection f, int? page)
        {
            string search = f["search"];
            string option = f["option"];
            if (page == null) page = 1;
            var vacancies = db.Vacancies.Where(p => p.Status == 0).OrderBy(x => x.Id);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if (option == "Name")
            {
                 vacancies = db.Vacancies.Where(p => p.Status == 0&&p.Name.Contains(search)).OrderBy(x => x.Id);
                return View(vacancies.ToPagedList(pageNumber, pageSize));
            }
            else if (option == "Language")
            {
                 vacancies = db.Vacancies.Where(p => p.Status == 0 && p.Language.Contains(search)).OrderBy(x => x.Id);
                return View(vacancies.ToPagedList(pageNumber, pageSize));
            }
            else if (option == "Salary")
            {
                 vacancies = db.Vacancies.Where(p => p.Status == 0 && p.Salary.Contains(search)).OrderBy(x => x.Id);
                return View(vacancies.ToPagedList(pageNumber, pageSize));
            }
            else if (option == "Location")
            {
                 vacancies = db.Vacancies.Where(p => p.Status == 0 && p.Location.Contains(search)).OrderBy(x => x.Id);
                return View(vacancies.ToPagedList(pageNumber, pageSize));
            }
            else if (option == "Experience")
            {
                 vacancies = db.Vacancies.Where(p => p.Status == 0 && p.Experience.Contains(search)).OrderBy(x => x.Id);
                return View(vacancies.ToPagedList(pageNumber, pageSize));
            }
            return View(vacancies.ToPagedList(pageNumber, pageSize));
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
                vacancy.CreateBy = GetUser().Id;
                vacancy.Posted = DateTime.Now;
                vacancy.Status = 0;
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
                Vacancy vacancy = resp.GetVacancy(id.Value);
                if (vacancy == null)
                {
                    return RedirectToAction("List");
                }
                User Creater = db.Users.Single(p => p.Id ==vacancy.CreateBy);
                ViewBag.Creater = Creater.Name;
                return View(vacancy);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(Vacancy vacancy)
        {
            if (vacancy.CreateBy==GetUser().Id)
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
