using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Core.Models;
using Project.Core.Objects;
using Project.Core;
namespace Project.Application.Controllers
{
    public class VacancyApplicantController : Controller
    {
        // GET: VacancyApplicant
        IVacancyResponsibility resp = new VacancyResponsibility();
        private CompanyDbContext context = new CompanyDbContext();
        public ActionResult Index()
        {

            List<VacancyApplicant> VacancyApplicants = resp.GetVacancyApplicant();
            return View(VacancyApplicants);
        }
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Login");
        }
        public ActionResult InterviewCensorship()
        {
            Interview interview = new Interview();
            List<VacancyApplicant> VacancyApplicants = resp.GetVacancyApplicant();
            return View(VacancyApplicants.Where(p=>p.Status=="doing" && p.InterviewId==1));
        }
        public ActionResult Edit(int? id)
        {
            List<string> Status = new List<string>() { "doing" , "false" , "pass" };
            if (id.HasValue)
            {
                VacancyApplicant vacancyApplicant = resp.GetVA(id.Value);
                if (vacancyApplicant!=null)
                {
                    ViewBag.Status = new SelectList(Status);
                    ViewBag.Interviews = context.Interviews.ToList();
                    return View(vacancyApplicant);
                }
            }
            return RedirectToAction("InterviewCensorship");
        }
        [HttpPost]
        public ActionResult Edit(VacancyApplicant data)
        {
            return View();
        }
        
    }
}