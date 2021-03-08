using Project.Core.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Project.Core.Models
{
    public class ApplicantResponsibility : IApplicantResponsibility
    {
        CompanyDbContext context = new CompanyDbContext();

        public Applicant AddApplication(Applicant applicant)
        {
            context.Applicants.Add(applicant);
            context.SaveChanges();
            return applicant;

        }

        public void AddVacancyApplicant(VacancyApplicant vacancyApplicant)
        {
            context.VacancyApplicants.Add(vacancyApplicant);
            context.SaveChanges();
        }

        public Applicant GetApplicant(string Email ,string Phone)
        {
            return context.Applicants.SingleOrDefault(p=>p.Email==Email || p.Phone==Phone);
        }

        public List<Applicant> GetApplicants()
        {
            return context.Applicants.ToList();
        }
    }
}
