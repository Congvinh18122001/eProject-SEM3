using Project.Core.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Project.Core.Models
{
    public class VacancyResponsibility : IVacancyResponsibility
    {
        CompanyDbContext context = new CompanyDbContext();
        public Vacancy CreateVacancy(Vacancy vacancy)
        {
            context.Vacancies.Add(vacancy);
            context.SaveChanges();
            return vacancy;
        }

        public VacancyApplicant GetVacancyApplicant(int id)
        {
            return context.VacancyApplicants.SingleOrDefault(p => p.Id == id);
        }

        public List<Vacancy> GetVacancies()
        {
            return context.Vacancies.ToList();
        }

        public Vacancy GetVacancy(int id)
        {
            return context.Vacancies.SingleOrDefault(p=>p.Id==id);
        }

        public List<VacancyApplicant> GetVacancyApplicants()
        {
            return context.VacancyApplicants.ToList();
        }

        public Vacancy UpdateVacancy(Vacancy data)
        {
            Vacancy vacancy = context.Vacancies.Single(p=>p.Id==data.Id);
            vacancy.Language = data.Language;
            vacancy.Location = data.Location;
            vacancy.Salary = data.Salary;
            vacancy.Status = data.Status;
            vacancy.Description = data.Description;
            vacancy.Experience = data.Experience;
            context.SaveChanges();
            return vacancy;

        }

        public VacancyApplicant UpdateVacancyApplicant(VacancyApplicant data)
        {
            VacancyApplicant vacancyApplicant = context.VacancyApplicants.SingleOrDefault(p=>p.Id==data.Id);
            if (vacancyApplicant != null)
            {
                vacancyApplicant.InterviewTime = data.InterviewTime;
                vacancyApplicant.Status = data.Status;
                vacancyApplicant.InterviewId = data.InterviewId;
                context.SaveChanges();
                if (vacancyApplicant.Status == 2)
                {
                    List<VacancyApplicant> vacancyApplicants = context.VacancyApplicants.Where(p => p.ApplicantId == data.ApplicantId && p.Status != 2).ToList();
                    foreach (var item in vacancyApplicants)
                    {
                        item.Status = 1;
                    }
                    context.SaveChanges();
                }
            }
            return vacancyApplicant;
        }
    }
}
