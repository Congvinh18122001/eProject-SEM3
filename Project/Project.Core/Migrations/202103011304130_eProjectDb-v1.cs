namespace Project.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eProjectDbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Experience = c.String(),
                        AcademicLevel = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VacancyApplicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantId = c.Int(nullable: false),
                        VacancyId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        InterviewTime = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        InterviewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Vacancies", t => t.VacancyId, cascadeDelete: true)
                .ForeignKey("dbo.Interviews", t => t.InterviewId, cascadeDelete: true)
                .Index(t => t.ApplicantId)
                .Index(t => t.VacancyId)
                .Index(t => t.InterviewId);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(),
                        Avatar = c.String(),
                        UserStatus = c.Boolean(nullable: false),
                        TypeUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeUsers", t => t.TypeUserId, cascadeDelete: true)
                .Index(t => t.TypeUserId);
            
            CreateTable(
                "dbo.TypeUsers",
                c => new
                    {
                        TypeUserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sale = c.Int(),
                    })
                .PrimaryKey(t => t.TypeUserId);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Language = c.String(),
                        Location = c.String(),
                        Salary = c.String(),
                        Experience = c.String(),
                        Posted = c.DateTime(nullable: false),
                        Description = c.String(),
                        CreateBy = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.DepartmentId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VacancyApplicants", "InterviewId", "dbo.Interviews");
            DropForeignKey("dbo.Vacancies", "User_Id", "dbo.Users");
            DropForeignKey("dbo.VacancyApplicants", "VacancyId", "dbo.Vacancies");
            DropForeignKey("dbo.Vacancies", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "TypeUserId", "dbo.TypeUsers");
            DropForeignKey("dbo.Interviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.VacancyApplicants", "ApplicantId", "dbo.Applicants");
            DropIndex("dbo.Vacancies", new[] { "User_Id" });
            DropIndex("dbo.Vacancies", new[] { "DepartmentId" });
            DropIndex("dbo.Users", new[] { "TypeUserId" });
            DropIndex("dbo.Interviews", new[] { "UserId" });
            DropIndex("dbo.VacancyApplicants", new[] { "InterviewId" });
            DropIndex("dbo.VacancyApplicants", new[] { "VacancyId" });
            DropIndex("dbo.VacancyApplicants", new[] { "ApplicantId" });
            DropTable("dbo.Departments");
            DropTable("dbo.Vacancies");
            DropTable("dbo.TypeUsers");
            DropTable("dbo.Users");
            DropTable("dbo.Interviews");
            DropTable("dbo.VacancyApplicants");
            DropTable("dbo.Applicants");
        }
    }
}
