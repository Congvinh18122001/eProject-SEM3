using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.Core;
using Project.Core.Objects;

namespace Project.Application.Controllers
{
    public class ApplicantManagesController : Controller
    {
        private CompanyDbContext db = new CompanyDbContext();

        // GET: ApplicantManages
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(db.Applicants.OrderBy(p=>p.Id).ToPagedList(pageNumber,pageSize));
        }
        [HttpPost]
        public ActionResult Index(FormCollection f, int? page)
        {
            string search = f["search"];

            var applicant = db.Applicants.Where(p => p.Name.Contains(search)).OrderBy(x => x.Id);
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (String.IsNullOrEmpty(search))
            {
                return View(applicant.ToPagedList(pageNumber, pageSize));
            }
            return View(applicant.ToPagedList(pageNumber, pageSize));
        }
        // GET: ApplicantManages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Login");
        }

        // GET: ApplicantManages/Create


        // GET: ApplicantManages/Delete/5

    }
}
