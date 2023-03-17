namespace HRKJ.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Copyrights", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Copyrights", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ExamInfos", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ExamInfos", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ExamResults", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ExamResults", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Grades", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Grades", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subjects", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subjects", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SystemMenus", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SystemMenus", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UsersPermissions", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UsersPermissions", "UpdateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UsersPermissions", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.UsersPermissions", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Users", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Users", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.SystemMenus", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.SystemMenus", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Subjects", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Subjects", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Students", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Students", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Roles", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Roles", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Grades", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Grades", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ExamResults", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ExamResults", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ExamInfos", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ExamInfos", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Copyrights", "UpdateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Copyrights", "CreateTime", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
