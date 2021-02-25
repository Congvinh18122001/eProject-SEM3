using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Objects
{
    public partial class Interview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<VacancyApplicant> VacancyApplicants { get; set; }

    }
}
