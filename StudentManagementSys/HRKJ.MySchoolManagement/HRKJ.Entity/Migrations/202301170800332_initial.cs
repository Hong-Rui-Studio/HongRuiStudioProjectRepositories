namespace HRKJ.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Copyrights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Content = c.String(maxLength: 2000),
                        Phone = c.String(maxLength: 50),
                        Tel = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Photo = c.String(maxLength: 50),
                        Images = c.String(maxLength: 50),
                        Logo = c.String(maxLength: 50),
                        SmallLogo = c.String(maxLength: 50),
                        Remark1 = c.String(maxLength: 2000),
                        Remark2 = c.String(maxLength: 2000),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ExamDate = c.DateTime(nullable: false, storeType: "date"),
                        SubjectsId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Scores = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RealName = c.String(nullable: false, maxLength: 50),
                        BornDate = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Pwd = c.String(nullable: false, maxLength: 50),
                        QQNumber = c.String(nullable: false, maxLength: 50),
                        WeChat = c.String(nullable: false, maxLength: 50),
                        GradesId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        GradesId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 50),
                        Icons = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RealName = c.String(nullable: false, maxLength: 50),
                        BornDate = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Pwd = c.String(nullable: false, maxLength: 50),
                        QQNumber = c.String(nullable: false, maxLength: 50),
                        WeChat = c.String(nullable: false, maxLength: 50),
                        RolesId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolesId = c.Int(nullable: false),
                        MenusId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false, storeType: "date"),
                        UpdateTime = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsersPermissions");
            DropTable("dbo.Users");
            DropTable("dbo.SystemMenus");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Roles");
            DropTable("dbo.Grades");
            DropTable("dbo.ExamResults");
            DropTable("dbo.ExamInfos");
            DropTable("dbo.Copyrights");
        }
    }
}
