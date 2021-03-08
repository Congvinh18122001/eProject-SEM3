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
    public class ApplicantsController : Controller
    {
        private CompanyDbContext db = new CompanyDbContext();
        IApplicantResponsibility context = new ApplicantResponsibility();
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                Vacancy vacancy = db.Vacancies.SingleOrDefault(p => p.Id == id.Value);
                if (vacancy != null)
                {
                    ViewBag.vacancyId = id;
                    return View();
                }
            }
            return RedirectToAction("Index", "Vacancies");

        }
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            string email = f["Email"];
            string phone = f["Phone"];
            TempData["StatusMessage"] = "You have applied for this job, please check your mail to receive more information.";
            Applicant CheckApplicant = context.GetApplicant(email, phone);
            if (CheckApplicant == null)
            {
                Applicant applicant = new Applicant();
                applicant.Name = f["Name"];
                applicant.Phone = f["Phone"];
                applicant.Status = true;
                applicant.Experience = f["Experience"];
                applicant.BirthDay = Convert.ToDateTime(f["BirthDay"]);
                applicant.Address = f["Address"];
                applicant.Email = f["Email"];
                applicant.AcademicLevel = f["AcademicLevel"];
                applicant.CreateAt = DateTime.Now;
                CheckApplicant = context.AddApplication(applicant);

            }
            if (CheckApplicant.Status==false)
            {
                TempData["messErr"] = "You applied to company.";
                ViewBag.vacancyId = Int32.Parse(f["vacancyId"]);
                return View();
            }
            VacancyApplicant vacancyApplicant = new VacancyApplicant();
            vacancyApplicant.ApplicantId = CheckApplicant.Id;
            vacancyApplicant.VacancyId = Int32.Parse(f["vacancyId"]);
            vacancyApplicant.InterviewTime = Convert.ToDateTime(f["InterviewTime"]);
            vacancyApplicant.Status = 0;
            vacancyApplicant.CreateAt = DateTime.Now;
            vacancyApplicant.InterviewId = 1;
            context.AddVacancyApplicant(vacancyApplicant);
            return RedirectToAction("Details","Vacancies",new { id = Int32.Parse(f["vacancyId"]) });
        }
      
    }
}
