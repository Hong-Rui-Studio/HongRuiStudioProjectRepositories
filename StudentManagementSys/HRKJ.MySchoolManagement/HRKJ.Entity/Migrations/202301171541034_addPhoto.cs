namespace HRKJ.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Photo", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Images", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Images");
            DropColumn("dbo.Users", "Photo");
        }
    }
}
