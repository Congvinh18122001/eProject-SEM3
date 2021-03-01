using System;
using System.Collections.Generic;

namespace Project.Core.Objects
{
    public partial class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Experience { get; set; }
        public string AcademicLevel { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }//CreatedAt
        public virtual ICollection<VacancyApplicant> VacancyApplicants { get; set; }
    }
}
