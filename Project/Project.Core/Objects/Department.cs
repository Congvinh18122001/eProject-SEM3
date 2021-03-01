using System;
using System.Collections.Generic;

namespace Project.Core.Objects
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
