using Project.Core.Objects;
using System.Collections.Generic;

namespace Project.Core.Models
{
    public interface IVacancyResponsibility
    {
        Vacancy CreateVacancy(Vacancy vacancy);
        List<Vacancy> GetVacancies();
        Vacancy GetVacancy(int id);
        Vacancy UpdateVacancy(Vacancy data);

        List<VacancyApplicant> GetVacancyApplicants();
        VacancyApplicant GetVacancyApplicant(int id);
        VacancyApplicant UpdateVacancyApplicant(VacancyApplicant data);
    }
}
