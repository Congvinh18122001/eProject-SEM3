using Project.Core.Objects;
using System.Data.Entity;

namespace Project.Core
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("name=connstring")
        {
            Database.SetInitializer(new DbInit());
        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<VacancyApplicant> VacancyApplicants { get; set; }
        public virtual DbSet<TypeUser> TypeUsers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
