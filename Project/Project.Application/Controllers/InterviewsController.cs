using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Core.Objects;
using Project.Core.Models;
using Project.Core;
using PagedList;

namespace Project.Application.Controllers
{
    public class InterviewsController : Controller
    {
        // GET: Interviews
        IInterViewResponsibility resp = new InterviewResponsibility();
        private CompanyDbContext context = new CompanyDbContext();
        public ActionResult Index(int? page)
        {
            List<Interview> Interviews = resp.GetInterviews();
            if (page == null) page = 1;
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(Interviews.Where(p => p.Id != 1).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(context.Users.Where(p=>p.TypeUserId==2),"Id","Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create( Interview interview)
        {
            if (interview != null)
            {
                interview = resp.CreateInterView(interview);
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(context.Users.Where(p => p.TypeUserId == 2), "Id", "Name");
            return View();
        }
    }
}