using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Core.Models;
using Project.Core.Objects;
using Project.Core;
using PagedList;

namespace Project.Application.Controllers
{
    public class VacancyApplicantController : Controller
    {
        // GET: VacancyApplicant
        IVacancyResponsibility resp = new VacancyResponsibility();
        private CompanyDbContext context = new CompanyDbContext();
        public ActionResult Index(FormCollection f, int? page)
        {
            string search = f["search"];
            List<VacancyApplicant> VacancyApplicants = resp.GetVacancyApplicants().Where(p=>p.Status==0).ToList();
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if(search != null)
            {
                return View(VacancyApplicants.Where(p => p.Applicant.Name.Contains(search)).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize));
            }
            return View(VacancyApplicants.OrderBy(x=>x.Id).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult List(FormCollection f, int? page)
        {
            string search = f["search"];
            List<VacancyApplicant> VacancyApplicants = resp.GetVacancyApplicants().ToList();
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (search != null)
            {
                return View(VacancyApplicants.Where(p => p.Applicant.Name.Contains(search)).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize));
            }
            return View(VacancyApplicants.OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Login");
        }
        public ActionResult InterviewCensorship(int? page)
        { 
            List<VacancyApplicant> VacancyApplicants = resp.GetVacancyApplicants();
            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            Interview interview = new Interview();
          
            return View(VacancyApplicants.Where(p=>p.Status==0 && p.InterviewId==1).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                VacancyApplicant vacancyApplicant = resp.GetVacancyApplicant(id.Value);
                if (vacancyApplicant!=null)
                {
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
        public ActionResult Details01(int? id)
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
        public ActionResult Interview(int? page)
        {
            if (Session["Login"] != null)
            {
                User user = Session["Login"] as User;
                List<Interview> Interviews = user.Interviews.ToList();
                if (page == null) page = 1;
                int pageSize = 1;
                int pageNumber = (page ?? 1);
                return View(Interviews.Where(p => p.Id != 1).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize));
            }
            return RedirectToAction("Index", "Vacancies");

        }

    }
}