using Project.Core.Objects;
using System.Collections.Generic;

namespace Project.Core.Models
{
    public interface IInterViewResponsibility
    {
        List<Interview> GetInterviews();
        Interview CreateInterView(Interview interview);
    }
}
