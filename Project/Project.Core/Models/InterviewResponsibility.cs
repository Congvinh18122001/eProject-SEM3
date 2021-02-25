using Project.Core.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Project.Core.Models
{
    public class InterviewResponsibility : IInterViewResponsibility
    {
        CompanyDbContext context = new CompanyDbContext();

        public Interview CreateInterView(Interview interview)
        {
            context.Interviews.Add(interview);
            context.SaveChanges();
            return interview;
        }

        public List<Interview> GetInterviews()
        {
            return context.Interviews.ToList();
        }
    }
}
