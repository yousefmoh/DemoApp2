namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StdClasses",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Major = c.String(),
                        Average = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.String(),
                        ClassName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StdClasses", t => t.ClassName, cascadeDelete: true)
                .Index(t => t.ClassName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassName", "dbo.StdClasses");
            DropIndex("dbo.Students", new[] { "ClassName" });
            DropTable("dbo.Students");
            DropTable("dbo.StdClasses");
        }
    }
}
