using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Objects
{
    public partial class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public int Status { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string Experience { get; set; }
        public DateTime Posted { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }

        public virtual ICollection<VacancyApplicant> VacancyApplicants { get; set; }

    }
}
