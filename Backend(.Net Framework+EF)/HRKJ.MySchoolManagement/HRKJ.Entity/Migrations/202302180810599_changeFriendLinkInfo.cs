namespace HRKJ.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFriendLinkInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FriendLinks", "IsShow", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FriendLinks", "IsShow", c => c.Boolean(nullable: false));
        }
    }
}
