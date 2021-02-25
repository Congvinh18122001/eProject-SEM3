using System;
using System.Collections.Generic;

namespace Project.Core.Objects
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Create_At { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
