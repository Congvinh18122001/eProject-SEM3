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
            List<VacancyApplicant> VacancyApplicants = resp.GetVacancyApplicants();
            return View("InterviewCensorship", VacancyApplicants);
        }
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Login");
        }
        public ActionResult InterviewCensorship()
        {
            Interview interview = new Interview();
            List<VacancyApplicant> VacancyApplicants = resp.GetVacancyApplicants();
            return View(VacancyApplicants.Where(p=>p.Status=="doing" && p.InterviewId==1));
        }
        public ActionResult Edit(int? id)
        {
            List<string> Status = new List<string>() { "doing" , "false" , "pass" };
            if (id.HasValue)
            {
                VacancyApplicant vacancyApplicant = resp.GetVacancyApplicant(id.Value);
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
            List<VacancyApplicant> VacancyApplicants ;
            
            if (data != null)
            {
                bool check = true;
                VacancyApplicants = resp.GetVacancyApplicants().Where(p=>p.InterviewId==data.InterviewId).ToList();
                foreach (var item in VacancyApplicants)
                {
                    if (item.InterviewTime==data.InterviewTime && item.Id != data.Id)
                    {
                        check = false;
                    }
                }
                VacancyApplicants = resp.GetVacancyApplicants().Where(p => p.ApplicantId == data.ApplicantId).ToList();
                foreach (var item in VacancyApplicants)
                {
                    if (item.InterviewTime == data.InterviewTime && item.Id != data.Id)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    VacancyApplicant vacancyApplicant = resp.UpdateVacancyApplicant(data);
                    if (vacancyApplicant != null)
                    {
                        return RedirectToAction("Details", new { id = vacancyApplicant.Id });
                    }
                }
            }
            List<string> Status = new List<string>() { "doing", "false", "pass" };
            ViewBag.Status = new SelectList(Status);
            ViewBag.Interviews = context.Interviews.ToList();
            VacancyApplicant VacancyApplicant = resp.GetVacancyApplicant(data.Id);
            VacancyApplicant.InterviewTime = data.InterviewTime;
            return View(VacancyApplicant);
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                VacancyApplicant vacancyApplicant = resp.GetVacancyApplicant(id.Value);
                if (vacancyApplicant != null)
                {
                    return View(vacancyApplicant);
                }
            }
            return RedirectToAction("InterviewCensorship");
        }
        
    }
}