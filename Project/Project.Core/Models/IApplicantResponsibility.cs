using Project.Core.Objects;
using System.Collections.Generic;
namespace Project.Core.Models
{
    public interface IApplicantResponsibility
    {
        List<Applicant> GetApplicants();
        Applicant GetApplicant(string Email);
        Applicant AddApplication(Applicant applicant);
        void AddVacancyApplicant(VacancyApplicant vacancyApplicant);
    }
}
