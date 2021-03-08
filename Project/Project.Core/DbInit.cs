using Project.Core.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core
{
    class DbInit : DropCreateDatabaseIfModelChanges<CompanyDbContext>
    {
        protected override void Seed(CompanyDbContext context)
        {
            List<Department> departments = new List<Department>() {
            new Department(){Name="HR",CreateAt=DateTime.Now },
            new Department(){Name="Java",CreateAt=DateTime.Now },
            new Department(){Name="PHP",CreateAt=DateTime.Now },
            new Department(){Name="doNet",CreateAt=DateTime.Now }
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();
            List<TypeUser> typeUsers = new List<TypeUser>()
            {
                new TypeUser(){Name="Hr",TypeUserId=1 },
                new TypeUser(){Name="Interviewer",TypeUserId=2 }

            };
            context.TypeUsers.AddRange(typeUsers);
            context.SaveChanges();
            List<User> users = new List<User>()
            {
                new User(){Name="a",Email="a@Gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=1,UserStatus=true,Password="123456" },
                new User(){Name="a",Email="abc@gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=1,UserStatus=true,Password="123456" },
                new User(){Name="b",Email="b@Gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=2,UserStatus=true,Password="123456" },
                new User(){Name="bdbdbdbd",Email="bd@gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=2,UserStatus=true,Password="123456" },
                new User(){Name="bdbdbd01",Email="bd1@gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=2,UserStatus=true,Password="123456" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
            List<Interview> interviews = new List<Interview>() {
               new Interview(){Id=1, UserId = 1 }
            };
            context.Interviews.AddRange(interviews);
            context.SaveChanges();
            List<Vacancy> vacancies = new List<Vacancy>()
             {
                 new Vacancy(){Name="Web Designer",Language="Angular JS",Salary="Negotiable",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Lead Android Developer",Language="Java",Salary="!.000$",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Front - End Enginerr",Language="HTML/CSS/JS",Salary="Negotiable",Experience="Master",Location="dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Java Developer",Language="Java",Salary="2.000$",Experience="Expert",Location="loremipsum",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                  new Vacancy(){Name="Web Designer",Language="Angular JS",Salary="Negotiable",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Lead Android Developer",Language="Java",Salary="!.000$",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Front - End Enginerr",Language="HTML/CSS/JS",Salary="Negotiable",Experience="Master",Location="dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Java Developer",Language="Java",Salary="2.000$",Experience="Expert",Location="loremipsum",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                  new Vacancy(){Name="Web Designer",Language="Angular JS",Salary="Negotiable",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Lead Android Developer",Language="Java",Salary="!.000$",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Front - End Enginerr",Language="HTML/CSS/JS",Salary="Negotiable",Experience="Master",Location="dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Java Developer",Language="Java",Salary="2.000$",Experience="Expert",Location="loremipsum",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                  new Vacancy(){Name="Web Designer",Language="Angular JS",Salary="Negotiable",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Lead Android Developer",Language="Java",Salary="!.000$",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Front - End Enginerr",Language="HTML/CSS/JS",Salary="Negotiable",Experience="Master",Location="dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Java Developer",Language="Java",Salary="2.000$",Experience="Expert",Location="loremipsum",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                  new Vacancy(){Name="Web Designer",Language="Angular JS",Salary="Negotiable",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Lead Android Developer",Language="Java",Salary="!.000$",Experience="Expert",Location="loremipsum, dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Front - End Enginerr",Language="HTML/CSS/JS",Salary="Negotiable",Experience="Master",Location="dolor",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
                 new Vacancy(){Name="Senior Java Developer",Language="Java",Salary="2.000$",Experience="Expert",Location="loremipsum",Posted=DateTime.Now,Status=0, DepartmentId=6, CreateBy=1,Description="Lorem ipsum dolor sit amet,sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, At vero eos et accusam et justo duo dolores et ea rebum. Lorem ipsum dolor sit amet, no sea  takimata sanctus est Lorem ipsum dolor sit amet. Stet clita kasd gubergren, no sea takimata sanctus est sanctus est Lorem ipsum dolor sit amet. sed diam voluptua. "},
             };
            context.Vacancies.AddRange(vacancies);
            context.SaveChanges();
        }
    }
}
