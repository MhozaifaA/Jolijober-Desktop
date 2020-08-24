namespace Jober.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReactUserJobPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        JobPostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPost", t => t.JobPostId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.JobPostId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReactUserJobPost", "UserId", "dbo.User");
            DropForeignKey("dbo.ReactUserJobPost", "JobPostId", "dbo.JobPost");
            DropIndex("dbo.ReactUserJobPost", new[] { "UserId" });
            DropIndex("dbo.ReactUserJobPost", new[] { "JobPostId" });
            DropTable("dbo.ReactUserJobPost");
        }
    }
}
