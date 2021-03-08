namespace Project.Core.Migrations
{
    using Project.Core.Objects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project.Core.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Project.Core.CompanyDbContext context)
        {
            List<Interview> interviews = new List<Interview>() {
               new Interview(){Id = 1 , UserId = 1 }
            };
            context.Interviews.AddRange(interviews);
            context.SaveChanges();
        }
    }
}
