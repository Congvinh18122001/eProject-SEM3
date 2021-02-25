using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Objects
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public bool UserStatus { get; set; }
        public int TypeUserId { get; set; }
        [ForeignKey("TypeUserId")]
        public virtual TypeUser TypeUser { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
