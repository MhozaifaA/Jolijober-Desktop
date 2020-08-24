namespace Jober.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                        UserId = c.Int(nullable: false),
                        SpecificationId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Specification", t => t.SpecificationId)
                .Index(t => t.UserId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.ReactApplyPostCompany",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        IsAccept = c.Boolean(nullable: false),
                        ApplyPostId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplyPost", t => t.ApplyPostId, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.ApplyPostId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Company",
                c => new 
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Mail = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        FieldId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Field", t => t.FieldId)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.CompanyArea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.AreaId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Mail = c.String(),
                        Phone = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Note = c.String(),
                        Gender = c.Boolean(),
                        AreaId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.AreaId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.RequestCompanyJobPostUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsAccept = c.Boolean(nullable: false),
                        Note = c.String(),
                        CompanyJobPostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyJobPost", t => t.CompanyJobPostId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CompanyJobPostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CompanyJobPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumJob = c.Int(),
                        CompanyAreaId = c.Int(nullable: false),
                        JobPostId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyArea", t => t.CompanyAreaId, cascadeDelete: true)
                .ForeignKey("dbo.JobPost", t => t.JobPostId, cascadeDelete: true)
                .Index(t => t.CompanyAreaId)
                .Index(t => t.JobPostId);
            
            CreateTable(
                "dbo.JobPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        NumReact = c.Int(nullable: false),
                        Age = c.String(),
                        WorkHour = c.String(),
                        Salary = c.Double(nullable: false),
                        Skills = c.String(),
                        Note = c.String(),
                        CompanySpecificationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanySpecification", t => t.CompanySpecificationId, cascadeDelete: true)
                .Index(t => t.CompanySpecificationId);
            
            CreateTable(
                "dbo.CompanySpecification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        SpecificationId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.Specification", t => t.SpecificationId)
                .Index(t => t.CompanyId)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.Specification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobPostCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobPostId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.JobPost", t => t.JobPostId, cascadeDelete: true)
                .Index(t => t.JobPostId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserQualification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        QualificationId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Qualification", t => t.QualificationId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.QualificationId);
            
            CreateTable(
                "dbo.Qualification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Field",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Command",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Query = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReactApplyPostCompany", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Company", "FieldId", "dbo.Field");
            DropForeignKey("dbo.Contract", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.CompanyArea", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.UserQualification", "UserId", "dbo.User");
            DropForeignKey("dbo.UserQualification", "QualificationId", "dbo.Qualification");
            DropForeignKey("dbo.RequestCompanyJobPostUser", "UserId", "dbo.User");
            DropForeignKey("dbo.RequestCompanyJobPostUser", "CompanyJobPostId", "dbo.CompanyJobPost");
            DropForeignKey("dbo.JobPostCategory", "JobPostId", "dbo.JobPost");
            DropForeignKey("dbo.JobPostCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CompanySpecification", "SpecificationId", "dbo.Specification");
            DropForeignKey("dbo.ApplyPost", "SpecificationId", "dbo.Specification");
            DropForeignKey("dbo.JobPost", "CompanySpecificationId", "dbo.CompanySpecification");
            DropForeignKey("dbo.CompanySpecification", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.CompanyJobPost", "JobPostId", "dbo.JobPost");
            DropForeignKey("dbo.CompanyJobPost", "CompanyAreaId", "dbo.CompanyArea");
            DropForeignKey("dbo.User", "AreaId", "dbo.Area");
            DropForeignKey("dbo.ApplyPost", "UserId", "dbo.User");
            DropForeignKey("dbo.CompanyArea", "AreaId", "dbo.Area");
            DropForeignKey("dbo.ReactApplyPostCompany", "ApplyPostId", "dbo.ApplyPost");
            DropIndex("dbo.Contract", new[] { "CompanyId" });
            DropIndex("dbo.UserQualification", new[] { "QualificationId" });
            DropIndex("dbo.UserQualification", new[] { "UserId" });
            DropIndex("dbo.JobPostCategory", new[] { "CategoryId" });
            DropIndex("dbo.JobPostCategory", new[] { "JobPostId" });
            DropIndex("dbo.CompanySpecification", new[] { "SpecificationId" });
            DropIndex("dbo.CompanySpecification", new[] { "CompanyId" });
            DropIndex("dbo.JobPost", new[] { "CompanySpecificationId" });
            DropIndex("dbo.CompanyJobPost", new[] { "JobPostId" });
            DropIndex("dbo.CompanyJobPost", new[] { "CompanyAreaId" });
            DropIndex("dbo.RequestCompanyJobPostUser", new[] { "UserId" });
            DropIndex("dbo.RequestCompanyJobPostUser", new[] { "CompanyJobPostId" });
            DropIndex("dbo.User", new[] { "AreaId" });
            DropIndex("dbo.CompanyArea", new[] { "CompanyId" });
            DropIndex("dbo.CompanyArea", new[] { "AreaId" });
            DropIndex("dbo.Company", new[] { "FieldId" });
            DropIndex("dbo.ReactApplyPostCompany", new[] { "CompanyId" });
            DropIndex("dbo.ReactApplyPostCompany", new[] { "ApplyPostId" });
            DropIndex("dbo.ApplyPost", new[] { "SpecificationId" });
            DropIndex("dbo.ApplyPost", new[] { "UserId" });
            DropTable("dbo.Command");
            DropTable("dbo.Field");
            DropTable("dbo.Contract");
            DropTable("dbo.Qualification");
            DropTable("dbo.UserQualification");
            DropTable("dbo.Category");
            DropTable("dbo.JobPostCategory");
            DropTable("dbo.Specification");
            DropTable("dbo.CompanySpecification");
            DropTable("dbo.JobPost");
            DropTable("dbo.CompanyJobPost");
            DropTable("dbo.RequestCompanyJobPostUser");
            DropTable("dbo.User");
            DropTable("dbo.Area");
            DropTable("dbo.CompanyArea");
            DropTable("dbo.Company");
            DropTable("dbo.ReactApplyPostCompany");
            DropTable("dbo.ApplyPost");
        }
    }
}
