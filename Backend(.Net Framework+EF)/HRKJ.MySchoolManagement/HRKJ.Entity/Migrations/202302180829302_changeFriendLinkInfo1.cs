namespace HRKJ.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFriendLinkInfo1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FriendLinks", "Link", c => c.String(nullable: false, maxLength: 2000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FriendLinks", "Link", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
