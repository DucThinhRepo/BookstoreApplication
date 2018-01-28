namespace BookManagement2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ISBNNumber = c.String(nullable: false),
                        title = c.String(nullable: false, maxLength: 100),
                        author = c.String(nullable: false, maxLength: 100),
                        status = c.Boolean(nullable: false),
                        photo = c.String(),
                        categoryID = c.Int(nullable: false),
                        borrowID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Borrows", t => t.borrowID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID)
                .Index(t => t.borrowID);
            
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        borrow = c.DateTime(nullable: false),
                        retur = c.DateTime(nullable: false),
                        deadline = c.DateTime(nullable: false),
                        fine = c.Int(nullable: false),
                        studentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Students", t => t.studentID, cascadeDelete: true)
                .Index(t => t.studentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                        name = c.String(nullable: false, maxLength: 100),
                        address = c.String(nullable: false, maxLength: 100),
                        phone = c.String(nullable: false),
                        majorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Majors", t => t.majorID, cascadeDelete: true)
                .Index(t => t.majorID);
            
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        major = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "categoryID", "dbo.Categories");
            DropForeignKey("dbo.Books", "borrowID", "dbo.Borrows");
            DropForeignKey("dbo.Borrows", "studentID", "dbo.Students");
            DropForeignKey("dbo.Students", "majorID", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "majorID" });
            DropIndex("dbo.Borrows", new[] { "studentID" });
            DropIndex("dbo.Books", new[] { "borrowID" });
            DropIndex("dbo.Books", new[] { "categoryID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Majors");
            DropTable("dbo.Students");
            DropTable("dbo.Borrows");
            DropTable("dbo.Books");
            DropTable("dbo.Admins");
        }
    }
}
