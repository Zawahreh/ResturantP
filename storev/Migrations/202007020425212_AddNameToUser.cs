namespace storev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNum", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PhoneNum");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
