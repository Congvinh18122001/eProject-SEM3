using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Objects
{
    public partial class VacancyApplicant
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public virtual Applicant Applicant { get; set; }
        public int VacancyId { get; set; }
        [ForeignKey("VacancyId")]
        public virtual Vacancy Vacancy { get; set; }
        public int Status { get; set; }
        public DateTime InterviewTime { get; set; }
        public DateTime CreateAt { get; set; }
        public int InterviewId { get; set; }
        [ForeignKey("InterviewId")]
        public virtual Interview Interview { get; set; }
    }
}
