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

namespace Project.Application.Controllers
{
    public class ApplicantManagesController : Controller
    {
        private CompanyDbContext db = new CompanyDbContext();

        // GET: ApplicantManages
        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
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

        // GET: ApplicantManages/Create
       

        // GET: ApplicantManages/Delete/5
      
    }
}
