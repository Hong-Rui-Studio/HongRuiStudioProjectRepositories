namespace HRKJ.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataBaseDesign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        GradesId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "ClassesId", c => c.Int(nullable: false));
            AlterColumn("dbo.ExamInfos", "SubjectsId", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Students", "GradesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "GradesId", c => c.Int(nullable: false));
            AlterColumn("dbo.ExamInfos", "SubjectsId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "ClassesId");
            DropTable("dbo.Classes");
        }
    }
}
