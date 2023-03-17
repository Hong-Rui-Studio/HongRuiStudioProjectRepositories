namespace HRKJ.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FriendLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 50),
                        IsShow = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Keyword = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false, maxLength: 2000),
                        MenusId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 50),
                        Icons = c.String(maxLength: 50),
                        ParentId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
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
                        Photo = c.String(nullable: false, maxLength: 50),
                        Images = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolesId = c.Int(nullable: false),
                        MenusId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 50),
                        Icons = c.String(maxLength: 50),
                        ParentId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebMenus");
            DropTable("dbo.UsersPermissions");
            DropTable("dbo.Users");
            DropTable("dbo.SystemMenus");
            DropTable("dbo.Seos");
            DropTable("dbo.Roles");
            DropTable("dbo.FriendLinks");
            DropTable("dbo.Copyrights");
        }
    }
}
