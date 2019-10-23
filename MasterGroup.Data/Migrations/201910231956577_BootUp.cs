namespace MasterGroup.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BootUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MasterGroup", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MasterGroup", "Username");
        }
    }
}
